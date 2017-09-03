using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace nametools
{
	public class AlbumDir
	{
		/* TODO: implement INotifyPropertyChanged */
		private String _OriginalDirectoryName;
		public String OriginalDirectoryName { get { return _OriginalDirectoryName; } set { _OriginalDirectoryName = value; } }

		private String _NewDirectoryName;
		public String NewDirectoryName { get { return _NewDirectoryName; } set { _NewDirectoryName = value; } }

		private String _Artist;
		public String Artist { get { return _Artist; } set { _Artist = value; NewDirectoryName = ToString(); } }

		private String _ArtistNameInNativeLang;
		public String ArtistNameInNativeLang { get { return _ArtistNameInNativeLang; } set { _ArtistNameInNativeLang = value; NewDirectoryName = ToString(); } }

		private String _Title;
		public String Title { get { return _Title; } set { _Title = value; NewDirectoryName = ToString(); } }

		private String _ReleaseDate;
		public String ReleaseDate { get { return _ReleaseDate; } set { _ReleaseDate = value; NewDirectoryName = ToString(); } }

		private List<String> _Types;
		public List<String> Types { get { return _Types; } set { _Types = value; NewDirectoryName = ToString(); } }

		private String _Language;
		public String Language { get { return _Language; } set { _Language = value; NewDirectoryName = ToString(); } }

		private String _FileFormat;
		public String FileFormat { get { return _FileFormat; } set { _FileFormat = value; NewDirectoryName = ToString(); } }

		private List<String> _Extras;
		public List<String> Extras { get { return _Extras; } set { _Extras = value; NewDirectoryName = ToString(); } }

		private TagLib.Tag _Tag;
		public TagLib.Tag Tag { get { return _Tag; } set { _Tag = value; NewDirectoryName = ToString(); } }


		public AlbumDir() { }
		public AlbumDir(string dirName)
		{
			String tmp;
			DirectoryInfo di = new DirectoryInfo(dirName);
			dirName = di.Name;

			OriginalDirectoryName = di.Name;
			Types = new List<string>();
			Extras = new List<string>();

			/* Try to find release date in name */
			Match m = Regex.Match(dirName, @"( *\[*\(*([0-9\-\.]+){4}\)*\]* *)"); /* match at least 4 numbers w/wo surrounding brackets/parens */
			if(m.Success)
			{
				dirName = dirName.Replace(m.Value, "");
				tmp = m.Value.Trim(new char[] { '[', ']', '(', ')', ' ' });
				ReleaseDate = tmp.Replace('.', '-'); /* only use dashes */
			}

			/* Find any extra designators enclosed in brackets/parens/etc. */
			MatchCollection matches = Regex.Matches(dirName, @"( *[\[\(\{].*?[\}\)\]] *)"); /* match at least 4 numbers w/wo surrounding brackets/parens */
			foreach(Match match in matches)
			{
				String trimmedMatch = match.Value.Trim(new char[] { '(', ')', '[', ']', '{', '}', ' ' });
				/* Format */
				if(trimmedMatch.ToLower().Contains("flac"))
					FileFormat = "FLAC";
				else if(trimmedMatch.ToLower().Contains("m4a"))
					FileFormat = "M4A";
				/* Language */
				else if(trimmedMatch.ToLower().Contains("jap"))
					Language = "JAP";
				/* Other */
				else if(trimmedMatch.ToLower().Contains("ep"))
					Types.Add("EP");
				else if(trimmedMatch.ToLower().Contains("limited"))
					Types.Add("Limited Edition");
				else if(trimmedMatch.ToLower().Contains("deluxe"))
					Types.Add("Deluxe Edition");
				else if(!IsStringRomanAlphabet(trimmedMatch))
					ArtistNameInNativeLang = trimmedMatch;
				else
					Extras.Add(trimmedMatch);
				dirName = dirName.Replace(match.Value, "");
			}

			/* Check if all thats left is in the format "artist - album" */
			if(dirName.Contains("-"))
			{
				String[] tokens = dirName.Split(new char[] { '-' });
				if(2 == tokens.Count()) /* Can only assume format if as described above */
				{
					tokens[0] = tokens[0].Trim();
					tokens[1] = tokens[1].Trim();
					/* Attempt to detect artist name in multiple languages */
					List<String> artistNameTokens = ParseRomanAlphabetStringFirst(tokens[0]);
					if(2 == artistNameTokens.Count)
					{
						Artist = artistNameTokens.ElementAt(0).Trim();
						ArtistNameInNativeLang = artistNameTokens.ElementAt(1).Trim();
					}
					else if(tokens[0].Length > 0)
						Artist = tokens[0];
					Title = tokens[1];
				}
			}

			/* Get ID3 tag info from mp3s in the directory if available */
			FileInfo[] fi = di.GetFiles("*.mp3");
			if(fi.Count() > 0)
			{
				TagLib.File f = TagLib.File.Create(fi[0].FullName);
				if(null != f.Tag)
				{
					Tag = f.Tag;

					/* Attempt to detect artist name in multiple languages */
					List<String> artistNameTokens = ParseRomanAlphabetStringFirst(f.Tag.FirstPerformer.Trim());
					if(2 == artistNameTokens.Count)
					{
						/* Assume the longer string is better */
						if(null == Artist || artistNameTokens.ElementAt(0).Length > Artist.Length)
							Artist = artistNameTokens.ElementAt(0);
						if(null == ArtistNameInNativeLang || artistNameTokens.ElementAt(1).Length > ArtistNameInNativeLang.Length)
							ArtistNameInNativeLang = artistNameTokens.ElementAt(1);
					}
					else if(null == Artist)
						Artist = f.Tag.FirstPerformer.Trim();
					else if(!IsStringRomanAlphabet(f.Tag.FirstPerformer.Trim()))
						ArtistNameInNativeLang = f.Tag.FirstPerformer.Trim();

					/* If no title found use the one from the ID3 tag */
					if(null == Title)
						Title = f.Tag.Album;

					/* Check if ID3 release date is better than what we found in the name */
					if(f.Tag.Year > 0)
					{
						tmp = f.Tag.Year.ToString();
						if(null == ReleaseDate || tmp.Length > ReleaseDate.Length)
							ReleaseDate = tmp;
					}
				}
			}

			//NewDirectoryName = ToString();
		}

		public override string ToString()
		{
			/* 
			 * Directory name format
			 * artist (name_in_native_lang) - album (EP) (edition) (YYYY-MM-DD) [kbps] (JAP) (FLAC) (M4A)
			 */
			String tmp = "";
			/* If we don't have at least the Artist and Title don't bother */
			if(null != Artist && null != Title && Artist.Length > 0 && Title.Length > 0)
			{
				tmp += Artist;
				if(null != ArtistNameInNativeLang && null != Artist && !Artist.Contains(ArtistNameInNativeLang))
					tmp += " (" + ArtistNameInNativeLang + ")";
				tmp += " - ";
				tmp += Title;
				foreach(String type in Types)
				{
					tmp += " (" + type + ")";
				}
				if(null != ReleaseDate)
					tmp += " (" + ReleaseDate + ")";
				if(null != Language)
					tmp += " (" + Language + ")";
				if(null != FileFormat)
					tmp += " (" + FileFormat + ")";
			}
			return tmp;
		}

		/* Determine if the string only contains characters from the Roman Alphabet */
		private bool IsStringRomanAlphabet(String s) { return Regex.IsMatch(s, @"^[ -~]+$"); }

		/* Returns tokens in string with format "xxx (xxx)" roman alphabet first */
		private List<String> ParseRomanAlphabetStringFirst(String s)
		{
			List<String> parsedStrings = new List<string>();
			char[] delims = new char[] { '(', ')' };
			String[] tokens = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);
			if(2 == tokens.Count())
			{
				tokens[0] = tokens[0].Trim();
				tokens[1] = tokens[1].Trim();
				if(IsStringRomanAlphabet(tokens[0]))
				{
					parsedStrings.Add(tokens[0]);
					parsedStrings.Add(tokens[1]);
				}
				else
				{
					parsedStrings.Add(tokens[1]);
					parsedStrings.Add(tokens[0]);
				}
			}
			else
				parsedStrings.Add(s);
			return parsedStrings;
		}
	}
}
