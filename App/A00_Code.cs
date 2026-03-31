// File:A00_Code.cs
using System.Diagnostics;
using System.Media;
//using System.Numerics;
//using System.Runtime.Intrinsics.X86;
using System.Text;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Xml.Linq;
//using static System.Runtime.InteropServices.JavaScript.JSType;

class A00_Code
{

    private static readonly string _out_file = "C:/DB/__ged_IN-autosave.ged";
    private static readonly List<Pe> _pelist = [];
    private static readonly Dictionary<string, int> _pe_index = [];
    private static readonly List<Fam> _famlist = [];
    private static readonly Dictionary<string, int> _fam_index = [];
    private static readonly List<Event> _eventList = [];
    private static readonly List<Info> _info_list = [];
    private static readonly List<Updates> _updateslist = [];
    private static readonly List<Note> _notelist = [];
    private static readonly List<Source> _source_list = [];
    private static readonly List<PersLine> _persLinelist = [];
    private static readonly List<Album> _albumlist = [];
    private static Info _info_new = new("", "", "");
    private static Event _event_new = new(0, "", "", "", "", "", "", "", "", "", "", "", "");
    //private static bool _bool_sex_u;
    //private static bool bool_nbsp;
    private static bool boolChecknbsp = false;
    //private static bool boolCheckUnklar;
    //private static bool boolSaveSingleEntry;
    private static readonly int _count = 0;
    private static int _nextGoalOfLines = -1;
    private static int lastPeListIndex_DONE = -1;
    private static readonly int _slow = 8;
    private static readonly int lastPeListIndex = -1;
    private static readonly int unknownKeyCount = 0;
    private static readonly string _newline = Environment.NewLine;
    private static readonly string _separator = ";";
    private static readonly string _slow_string = "";
    private static readonly string _start_time = DateTime.Now.ToString();
    private static readonly string _start_time_global = DateTime.Now.ToString();
    private static string _comment_inside_code = "";
    private static string _info_0_text = "";
    private static string gedheadText = "";
    private static string ht = " # ";
    private static string key = "";
    private static string unknownKeyText = "unknown";
    private static string v0 = "";
    private static string v1 = "";
    private static string v2 = "";
    private static string value = "";
    private static string valueAdd = "";
    public string blank = "";
    //private bool bool_nbsp = false;

    static async Task Main()
    {
        //var p = new A00_Code();
        string _path = "C:/DB/";
        string _read_file = "__ged_IN";
        string _extension = ".ged";
        //private static 
        bool _bool_sex_u = false;
        //bool bool_nbsp = false;
        //bool boolChecknbsp = false;
        bool boolCheckUnklar = false;
        bool boolSaveSingleEntry = false;
        string blank = "";
        string _first = "";
        string updateString = ""; ;
        string sourceString = ""; ;
        string entryText = "";
        int secondblankOrEnd = 0;
        //string _secondblankOrEnd;
        string _date;
        string _place;
        string _dio = "";
        string _cb;
        //string _cb;
        //string _keyPrevious;
        string keyPrevious = "";
        string _day;
        string _month;
        string _year;
        string _kind;
        string _date_val;
        string _deathdateString = "";
        int _count = 0;
        string[] _dateColl;

        string _famsText;
        string _deatText;
        string _persLineText;
        string _persLineHint;

        string _dateString;
        //string _line_string = "";
        blank = "";
        List<PersLine> _persLineList = [];



        List<string> _all_lines = await Task.Run(() => A01_Read_Input(_path, _read_file, _extension));

        A05_DoAutosave(_all_lines);

        _count = 0;
        _nextGoalOfLines = 10000;
        foreach (var _line in _all_lines)
        {
            _count += 1;

            //_info_0_text = _count + " > Orig.Line= > " + _line;
            //Console.WriteLine(_info_0_text);


            DoReplace_stuff(_line, out string _line_string);
            //Xwrite("Step_2200", true, _count + " DoReplace_stuff > " + _line_string);

            if (_line_string.Length == 0)
            {
                _info_0_text = DateTime.Now + " > " + _count + " > Line= > " + _line_string + " IS EMPTY           > Orig.= > " + _line; ;
                //Console.WriteLine(_info_0_text);
                Trace.WriteLine(_info_0_text);
                Debugger.Break();
                continue;
            }

            _comment_inside_code = "if (_count > _nextGoalOfLines)" + _comment_inside_code + sourceString;

            if (_line_string[..1] == "0" && _count > _nextGoalOfLines)
            {
                _comment_inside_code = "Trace.WriteLine goes to Output inside VS while Console.Writeline goes to Prompt-Window";

                _info_0_text = DateTime.Now + " > Step_1400 >  " + _nextGoalOfLines / 1000 + " TSD > Line= > " + _line_string + "           > Orig.= > " + _line; ;
                //Console.WriteLine(_info_0_text);
                Trace.WriteLine(_info_0_text);
                //_info_new = new("INFO;", ";", _info_0_text);
                //_info_list.Add(_info_new);

                _nextGoalOfLines += 10000;
            }


            //_first = _line_string.[..1].ToString();
            _comment_inside_code = "SAVE TIME";

            _comment_inside_code = "here: for all lines";

            _first = _line_string[..1].ToString();


            //if (_line_string.Contains("DAH+"))
            //    sourceString = "_DAH_85244";

            //if (_line_string.Contains("Jaubert Family Tree"))
            //    sourceString = "Sylvie";

            //if (_line_string.Contains("Family Tree Builder"))
            //    sourceString = "FTP-Export";


            if (_line_string.Contains("UPD"))  // for header
            {
                updateString = GetUpdateString(_line_string);
            }



            if (_first != "0")
            {
                entryText += keyPrevious + ";" + _line_string + _newline;
            }

            _info_0_text = "firstchar=0";
            if (_first == "0")
            {
                // Works
                //Console.WriteLine("keyPrevious {0}, entryText {1}, updateString {2}, sourceString {3}", 
                //    keyPrevious, entryText, updateString, sourceString);

                if (_slow > 8 && boolSaveSingleEntry == false)
                {
                    _info_0_text = _slow_string + ";NO;no output for each single entry to _GED_OUT folder";
                    Xwrite("Step_8900", true, _line_string);

                    boolSaveSingleEntry = true;
                }
                else
                {


                    if (_slow < 2 && keyPrevious != null && keyPrevious != "")
                    {
                        _info_0_text = "SaveEntry = eine Datei je ID-Nummer";
                        //SaveEntry(keyPrevious, entryText, updateString, sourceString); // ein 
                        boolSaveSingleEntry = true;
                    }
                }



                entryText = "";

            }
            int firstblank = 0;


            // firstblank
            // Replace this unsafe block:
            // if (_line_string.Contains(' ')) firstblank = _line_string.IndexOf(' ');
            // int start = firstblank + 1;
            // int stopp = _line_string.Length - start - 1;
            // secondblankOrEnd = _line_string.Substring(start, stopp).IndexOf(' ') + 2;
            // if (secondblankOrEnd < 2)
            //     secondblankOrEnd = _line_string.Length - 2;

            // With this safe code:
            if (_line_string.Contains(' '))
            {
                firstblank = _line_string.IndexOf(' ');
            }
            else
            {
                firstblank = -1;
            }

            // Find second space index robustly
            int secondSpaceIndex = -1;
            if (firstblank >= 0 && firstblank + 1 < _line_string.Length)
            {
                secondSpaceIndex = _line_string.IndexOf(' ', firstblank + 1);
            }

            // Use line end when second space not found
            if (secondSpaceIndex == -1)
            {
                // no second space -> treat as end of line
                secondblankOrEnd = _line_string.Length;
            }
            else
            {
                secondblankOrEnd = secondSpaceIndex;
            }
            //if (SecondBlankOrEnd == 4 )  // only e.g. BIRT, nothing more
            //    SecondBlankOrEnd = 0;
            //Console.WriteLine("firstblank = {0}, = {1}, {2}", firstblank, secondblankOrEnd, _line_string);


            // Example
            // 0123456789
            // 2 DATE 9 DEC 1939
            // 1 SEX M


            // _first == "0"
            if (_first == "0")
            {
                if (_line_string.Substring(2, 4).ToString() == "HEAD")
                {
                    v0 = "H_";
                    key = "HEAD";
                    keyPrevious = key;
                }

                if (_line_string.Substring(2, 2).ToString() == @"@U")
                {
                    v0 = "U_";
                    Console.WriteLine("#### skipped 'U' = {0}", _line_string);
                }

                // NOTE
                if (_line_string.EndsWith("NOTE"))
                {
                    v0 = "N_";
                    //Console.WriteLine("#### skipped 'NOTE' = {0}", _line_string);

                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    key = key.Replace("@", "");
                    keyPrevious = key;

                    Note noteNew = new(keyPrevious, blank, blank, blank);
                    _notelist.Add(noteNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                }

                // ALBUM
                if (_line_string.EndsWith("ALBUM"))
                {
                    v0 = "A_";
                    //Console.WriteLine("#### skipped 'ALBUM' = {0}", _line_string);

                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    key = key.Replace("@", "");

                    if (_albumlist.FindIndex(item => item.AA_A_INDEX == key) > -1)
                    {
                        key += "2";
                    }

                    keyPrevious = key;

                    Album albumNew = new(keyPrevious, blank, blank, blank, blank);
                    _albumlist.Add(albumNew);
                    //Console.WriteLine("adding ALBUM = {0}", keyPrevious);
                }

                if (_line_string.EndsWith("TRLR"))
                {
                    v0 = "END_";
                    //Console.WriteLine("___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
                    _info_0_text = " > TRLR = End of file";
                    Xwrite("Step_9985", true, _info_0_text);
                }

                // FAM
                _comment_inside_code = "ab hier families";
                if (_line_string.EndsWith("FAM"))
                {
                    v0 = "F_";
                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    key = key.Replace("@", "");
                    keyPrevious = key;

                    Fam famNew = new(keyPrevious
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank//  // 11//
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank//  // 21
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank//,
                        );

                    _famlist.Add(famNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                }

                if (_line_string.EndsWith("SOUR"))  // SOUR
                {
                    v0 = "S_";
                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    key = key.Replace("@", "");
                    keyPrevious = key;

                    Source sourceNew = new(keyPrevious, blank, blank, blank, blank, blank, blank, blank, blank, blank);
                    _source_list.Add(sourceNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                }

                // INDI
                if (_line_string.EndsWith("INDI"))  // not TRLR = each entry
                {
                    v0 = "I_";

                    //key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    key = key.Replace("@", "");
                    keyPrevious = key;

                    Pe peNew = new(keyPrevious
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 11
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 21
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 31
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 41
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 51
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank  // 61
                        , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank//, blank, blank, blank   70//
                        , blank, blank, blank, blank, blank
                        );
                    _pelist.Add(peNew);
                    //_pers_text_coll_global.Clear();
                    //Console.WriteLine("adding = {0}", keyPrevious);
                }
                //else
                //{
                //    unknownKeyCount += 1;
                //    keyPrevious = key;
                //    //lastPeListIndex_DONE = lastPeListIndex;
                //    //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                //    //_pelist.Add(peNew);
                //    key = "unknownKeyCount" + unknownKeyCount.ToString();

                //}
            }
            _info_0_text = "End of:  if (_first == 0";



            int _pelistIndex = _pelist.FindIndex(item => item.AA_I_INDEX == keyPrevious);
            //_pe_index.Add(_pelist[_pelistIndex].AA_I_INDEX, _pelistIndex);
            int lastPeListIndex = _pelistIndex;
            //int lastPeListIndex_DONE;
            int _famlistIndex = _famlist.FindIndex(item => item.AA_F_INDEX == keyPrevious);
            //_fam_index.Add(_famlist[_pelistIndex].AA_F_INDEX, _pelistIndex);
            int notelistIndex = _notelist.FindIndex(item => item.AA_N_INDEX == keyPrevious);
            int sourcelistIndex = _source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious);
            int albumlistIndex = _albumlist.FindIndex(item => item.AA_A_INDEX == keyPrevious);
            //_pelist.Add(peNew);


            //#region _first == "1"
            if (_first == "1")
            {
                if (_line_string.Length > 5)
                    v1 = v0 + _line_string.Substring(2, 4).Trim(); // + _separator;
                else v1 = v0 + _line_string.Substring(2, 3).Trim(); // + _separator;

                valueAdd = "";
                //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                //if (_line_string.Length != v1.Length + 2)
                //{
                //valueAdd =
                //v1 + _separator +  // without
                //_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + _separator;
                //v1.Substring(secondblankOrEnd + 1, v1.Length - secondblankOrEnd - 1) + _separator;
                //}
                if (valueAdd.Length < 3)
                {
                    //valueAdd = _line_string.Substring(2, _line_string.Length - 2);
                    valueAdd = _line_string[2..];
                }

                if (valueAdd == "ENGA") valueAdd = "verlobt";
                if (valueAdd == "MARL") valueAdd = "StAmt";

                //else { valueAdd}
                //value += CleanText(valueAdd);
                value += valueAdd;

                //valueAdd = CleanText(valueAdd);
                //valueAdd = CleanText(valueAdd);

                switch (v1)
                {
                    // FAM
                    case "F_HUSB": _famlist[_famlistIndex].F_HUSB = CleanID(valueAdd); break;
                    case "F_WIFE": _famlist[_famlistIndex].F_WIFE = CleanID(valueAdd); break;
                    case "F_RIN": /*_famlist[_famlistIndex].F_RIN = valueAdd;*/ break;
                    case "F__UID": /*_famlist[_famlistIndex].F__UID = valueAdd;*/ break;
                    case "F_CHIL": _famlist[_famlistIndex].F_CHIL += CleanID(valueAdd) + " # "; break;
                    case "F__UPD": _famlist[_famlistIndex].F__UPD = valueAdd; break;
                    case "F_MARR": _famlist[_famlistIndex].F_MARR = valueAdd; break;
                    case "F_MARL": _famlist[_famlistIndex].F_MARL = valueAdd; break;  // Hochzeit Standesamt
                    case "F_DIV": _famlist[_famlistIndex].F_DIV = valueAdd; break;  // Divorce
                    case "F_ENGA": _famlist[_famlistIndex].F_ENGA = valueAdd; break; // Verlobung
                    case "F_ANUL": _famlist[_famlistIndex].F_ANUL = valueAdd; break;
                    case "F_EVEN": _famlist[_famlistIndex].F_EVEN = valueAdd; break;

                    // SOURCE
                    case "S_AUTH": _source_list[sourcelistIndex].S_AUTH = valueAdd; break;
                    case "S_TITL": _source_list[sourcelistIndex].S_TITL = valueAdd; break;
                    case "S_PUBL": _source_list[sourcelistIndex].S_PUBL = valueAdd; break;
                    case "S_TEXT": _source_list[sourcelistIndex].S_TEXT = valueAdd; break;
                    case "S__TYP": _source_list[sourcelistIndex].S__TYP = valueAdd; break;
                    case "S__MED": _source_list[sourcelistIndex].S__MED = valueAdd; break;

                    // ALBUM = Photos
                    //case "S_AUTH": _albumlist[albumlistIndex].S_AUTH = valueAdd; break;
                    case "A_TITL": _albumlist[albumlistIndex].A_TITL = valueAdd; break;
                    case "A_DESC": _albumlist[albumlistIndex].A_DESC = valueAdd; break;
                    //case "S_TEXT": _albumlist[albumlistIndex].S_TEXT = valueAdd; break;
                    case "A__UPD": _albumlist[albumlistIndex].A__UPD = valueAdd; break;
                    case "A_RIN": /*_albumlist[albumlistIndex].A_RIN = valueAdd;*/ break;


                    // INDI
                    case "I_NAME": _pelist[_pelistIndex].I_NAME = valueAdd; break;
                    //case "I_NAME": _pelist[_pelistIndex].I_NAME = valueAdd; break;
                    //case "I_NAME": _pelist[_pelistIndex].I_NAME = valueAdd; break;
                    //case "I_NAME": _pelist[_pelistIndex].I_NAME = valueAdd; break;
                    case "I_SEX":
                        _pelist[_pelistIndex].I_SEX = valueAdd;
                        //if (_slow > 0)
                        //{
                        //    if (_bool_sex_u == false && valueAdd.Contains("U"))// || valueAdd.Contains("") || valueAdd.Contains(" "))
                        //    {
                        //        errortext = blank + "SEX contains U"
                        //            + blank + _pelist[_pelistIndex].I_SEX
                        //            + " verh. " + _pelist[_pelistIndex].I_NAME_MARNM
                        //            + blank + _pelist[_pelistIndex].I_NAME_SURN
                        //            + blank + _pelist[_pelistIndex].I_NAME_GIVN
                        //            + blank + _pelist[_pelistIndex].AA_I_INDEX
                        //            ;
                        //        Console.WriteLine(errortext);
                        //        AddError(_count.ToString(), "SEX contains U", errortext);
                        //    }
                        //}
                        //else
                        if (_slow == 0 && _bool_sex_u == false)
                        {
                            _info_0_text = _slow_string + "; NO_0009;no check for *SEX contains U*";
                            Xwrite("Step_9905", true, _info_0_text);

                            _bool_sex_u = true;
                        }
                        break;
                    case "I_BIRT": _pelist[_pelistIndex].I_BIRT = valueAdd; break;
                    case "I_DEAT":
                        _pelist[_pelistIndex].I_DEAT = valueAdd;
                        //if (valueAdd == "DEAT Y")
                        //    _pelist[_pelistIndex].I_SEX += "d";
                        //else
                        //    _pelist[_pelistIndex].I_SEX += "a";

                        break;

                    case "I_BURI": _pelist[_pelistIndex].I_BURI = valueAdd; break;
                    case "I_FAMS": _pelist[_pelistIndex].I_FAMS += valueAdd + "-"/* + ht*/; break;
                    case "I_FAMC": _pelist[_pelistIndex].I_FAMC += valueAdd + ht; break;


                    case "I_RESI": _pelist[_pelistIndex].I_RESI = valueAdd; break;
                    case "I_ADDR": _pelist[_pelistIndex].I_RESI = valueAdd; break;  // same like RESI ??
                    case "I_CONF": _pelist[_pelistIndex].I_CONF = valueAdd; break;
                    case "I_RELI": _pelist[_pelistIndex].I_RELI = valueAdd; break;
                    case "I_OCCU": _pelist[_pelistIndex].I_OCCU = valueAdd; break;
                    case "I_CENS": _pelist[_pelistIndex].I_CENS = valueAdd; break;
                    case "I_NOTE": _pelist[_pelistIndex].I_NOTE = valueAdd; break;

                    case "I_RIN": /*_pelist[_pelistIndex].I_RIN = valueAdd;*/ break;
                    case "I__UID": /*_pelist[_pelistIndex].I__UID = valueAdd;*/ break;

                    case "S_RIN": /*_source_list[sourcelistIndex].S_RIN = valueAdd;*/ break;
                    case "S__UID": /*_source_list[sourcelistIndex].S__UID = valueAdd;*/ break;

                    //case "I_RIN ": _pelist[_pelistIndex].I_RIN = valueAdd; break;
                    //case "I__RIN": _pelist[_pelistIndex].I_RIN = valueAdd; break;
                    //case "I_UID ": _pelist[_pelistIndex].I_UID = valueAdd; break;

                    case "I__UPD": _pelist[_pelistIndex].I_UPD = valueAdd; break;
                    case "I_CHAN": _pelist[_pelistIndex].I_UPD = "### Change instead UPD ### " + valueAdd; break;
                    case "N_CONC": _notelist[notelistIndex].N_CONC = valueAdd; break;
                    case "N_PRIN": _notelist[notelistIndex].N_PRIN = valueAdd; break;
                    case "N_RIN": /*_notelist[notelistIndex].N_RIN = valueAdd;*/ break;

                    case "I_EVEN": _pelist[_pelistIndex].I_EVEN = valueAdd; break;
                    case "I_EMIG": _pelist[_pelistIndex].I_EMIG = valueAdd; break;

                    case "I_NATI": /*_pelist[_pelistIndex].I_NATI = valueAdd;*/ break;

                    case "H_DATE": gedheadText += valueAdd; break;
                    case "H_GEDC": gedheadText += valueAdd; break;
                    case "H_CHAR": gedheadText += valueAdd; break;
                    case "H_LANG": gedheadText += valueAdd; break;
                    case "H_SOUR": gedheadText += valueAdd; break;
                    case "H_DEST": gedheadText += valueAdd; break;
                    case "H__PRO": /*gedheadText += valueAdd;*/ break;
                    case "H__EXP": /*gedheadText += valueAdd;*/ break;
                    case "H_FILE": gedheadText += valueAdd; break;

                    case "I_SOUR": _pelist[_pelistIndex].I_SOUR = valueAdd; break;

                    case "I_OBJE": _pelist[_pelistIndex].I_OBJE = valueAdd; break;

                    //case "I_MARR": _pelist[_famlistIndex].I_MARR = valueAdd; break;
                    //case "I_DIV ": _pelist[_famlistIndex].I_DIV = valueAdd; break;
                    //case "I_NATI": _pelist[_pelistIndex].I_NATI = valueAdd; break;

                    default:
                        //MessageBox.Show("Unknown key at v2 = {0}", v1);

                        // these are used by Ahnenblatt
                        //if (v1 != "S__UPD" || v1 != "H_SUBM" || v1 != "H__NAV" || v1 != "H__HOM" || v1 != "H_NAME" || v1 != "F__STA" || v1 != "F__MAR")
                        //{
                        //    Console.WriteLine(_newline + "Unknown key at v1 = {0}", v1);
                        //}
                        unknownKeyText = _newline + "key not used at v1 = " + v1 + " at line: " + _count.ToString() + ": value = " + valueAdd;
                        Console.WriteLine(/*_newline + */"key not used at v1     = " + v1 + "        at line: " + _count.ToString() + ": value = " + valueAdd);

                        // V1 ignored:


                        if (v1 == "H_SUBM") unknownKeyText = ""; // 1 SUBM @U1@
                        if (v1 == "H_SUB") unknownKeyText = "";  // 1 SUBM @U1@
                        if (v1 == "H__NAV") unknownKeyText = "";
                        if (v1 == "H__RIN") unknownKeyText = ""; // 1 _RINS I1228,F76,N11316,M0,R0,S22,U1,L0,P0,Q0,IF251248,FF36635
                        if (v1 == "H__UID") unknownKeyText = ""; // 1 _UID VWD90D6C-E63C-4C36-8689-3A304C67E28D
                        if (v1 == "H__DES") unknownKeyText = ""; // 1 _DESCRIPTION_AWARE Y
                        if (v1 == "H_DES") unknownKeyText = "";  // 1 DEST MYHERITAGE
                        if (v1 == "H__USE") unknownKeyText = ""; // 1 _USERNAME r.r
                        if (v1 == "H__DIS") unknownKeyText = ""; // 
                        if (v1 == "H__FAC") unknownKeyText = ""; // 1 _FACTS_DEFRAGGED Y
                        if (v1 == "H__HOM") unknownKeyText = "";
                        if (v1 == "H_NAME") unknownKeyText = "";
                        if (v1 == "H_CHA") unknownKeyText = "";  // 1 CHAR UTF-8
                        if (v1 == "H_LAN") unknownKeyText = "";  // 1 LANG German
                        if (v1 == "H_SOU") unknownKeyText = "";  // 1 SOUR MYHERITAGE
                        if (v1 == "F__STA") unknownKeyText = "";
                        if (v1 == "F__MAR") unknownKeyText = "";
                        if (v1 == "S__UPD") unknownKeyText = "";
                        if (v1 == "U_RIN") unknownKeyText = "";
                        if (v1 == "I_BAPM") unknownKeyText = ""; // Taufpaten
                        if (v1 == "I__MTT") unknownKeyText = ""; // MTTAG

                        if (unknownKeyText != "")
                            Console.WriteLine(v1 + " ignored: value = " + valueAdd);

                        break;
                }
                valueAdd = "";
            }
            // end of : if (_first == "1")
            //#endregion _first = 1

            //#region _first = 2
            //_first == "2"
            if (_first == "2")
            {
                v2 = _line_string.Substring(2, 4);

                valueAdd = "";
                //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                if (_line_string.Length > 6)
                {
                    //valueAdd =_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + _separator;
                    valueAdd = string.Concat(_line_string.AsSpan(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1), _separator);
                    //v0 + v1 + _separator + "-" + v2 + _separator + // without
                }


                //valueAdd = CleanText(valueAdd);
                //valueAdd = CleanText(valueAdd);

                //value += valueAdd;
                value += valueAdd;

                string v0v1v2 = v0 + v1 + "_" + v2;

                bool boolCheckGIVEN = false;

                switch (v0v1v2)
                {
                    // FAM
                    case "F_F_MARR_DATE": _famlist[_famlistIndex].F_MARR_DATE = valueAdd; break;
                    case "F_F_MARR_PLAC": _famlist[_famlistIndex].F_MARR_PLAC = valueAdd; break;
                    case "F_F_MARR_NOTE": valueAdd = valueAdd.Replace(",", "#"); _famlist[_famlistIndex].F_MARR_NOTE = valueAdd; break;
                    case "F_F_MARR__UID": /*_famlist[_famlistIndex].F_MARR__UID = valueAdd;*/ break;
                    case "F_F_MARR_RIN ": /*_famlist[_famlistIndex].F_MARR_RIN = valueAdd;*/ break;
                    case "F_F_EVEN_TYPE": _famlist[_famlistIndex].F_EVEN_TYPE = valueAdd; break;
                    case "F_F_EVEN_DATE": _famlist[_famlistIndex].F_EVEN_DATE = valueAdd; break;
                    case "F_F_EVEN_PLAC": _famlist[_famlistIndex].F_EVEN_PLAC = valueAdd; break;
                    case "F_F_EVEN__UID": /*_famlist[_famlistIndex].F_EVEN__UID = valueAdd;*/ break;
                    case "F_F_EVEN_RIN ": /*_famlist[_famlistIndex].F_EVEN_RIN = valueAdd;*/ break;
                    case "F_F_EVEN_NOTE": _famlist[_famlistIndex].F_EVEN_NOTE = valueAdd; break;
                    // MARL
                    case "F_F_MARL_DATE": _famlist[_famlistIndex].F_MARL_DATE = valueAdd; break;
                    case "F_F_MARL_PLAC": _famlist[_famlistIndex].F_MARL_PLAC = valueAdd; break;
                    case "F_F_MARL_NOTE": _famlist[_famlistIndex].F_MARL_NOTE = valueAdd; break;
                    // DIV
                    case "F_F_DIV_DATE": _famlist[_famlistIndex].F_DIV_DATE = valueAdd; break;
                    case "F_F_DIV_PLAC": _famlist[_famlistIndex].F_DIV_PLAC = valueAdd; break;
                    case "F_F_DIV_NOTE": _famlist[_famlistIndex].F_DIV_NOTE = valueAdd; break;
                    // ENGA
                    case "F_F_ENGA_DATE": _famlist[_famlistIndex].F_ENGA_DATE = valueAdd; break;
                    case "F_F_ENGA_PLAC": _famlist[_famlistIndex].F_ENGA_PLAC = valueAdd; break;
                    case "F_F_ENGA_NOTE": _famlist[_famlistIndex].F_ENGA_NOTE = valueAdd; break;
                    // ANUL
                    case "F_F_ANUL_DATE": _famlist[_famlistIndex].F_ANUL_DATE = valueAdd; break;
                    case "F_F_ANUL_PLAC": _famlist[_famlistIndex].F_ANUL_PLAC = valueAdd; break;
                    case "F_F_ANUL_NOTE": _famlist[_famlistIndex].F_ANUL_NOTE = valueAdd; break;

                    //    // SOUR

                    case "S_S_SOUR_CONC": _source_list[sourcelistIndex].S_SOUR_CONC = valueAdd; break;
                    case "S_S_TEXT_CONC": _source_list[sourcelistIndex].S_TEXT_CONC = valueAdd; break;


                    // HEADER
                    case "H_H_GEDC_VERS": gedheadText += valueAdd; break;
                    case "H_H_GEDC_FORM": gedheadText += valueAdd; break;
                    case "H_H_SOUR_NAME": gedheadText += valueAdd; break;
                    case "H_H_SOUR_VERS": gedheadText += valueAdd; break;
                    case "H_H_SOUR__RTL": gedheadText += valueAdd; break;
                    case "H_H_SOUR_CORP": gedheadText += valueAdd; break;

                    case "H_H_DEST": gedheadText += valueAdd; break;
                    case "H_H__PRO": gedheadText += valueAdd; break;



                    // ALBUM
                    //case "H_H_GEDC_VERS": gedheadText += valueAdd; break;
                    //case "H_H_GEDC_FORM": gedheadText += valueAdd; break;
                    //case "H_H_SOUR_NAME": gedheadText += valueAdd; break;
                    //case "H_H_SOUR_VERS": gedheadText += valueAdd; break;
                    //case "H_H_SOUR__RTL": gedheadText += valueAdd; break;
                    //case "H_H_SOUR_CORP": gedheadText += valueAdd; break;




                    case "I_I_BIRT_DATE":
                        _pelist[_pelistIndex].I_BIRT_DATE = valueAdd;
                        break;
                    case "I_I_NAME_GIVN":
                        _pelist[_pelistIndex].I_NAME_GIVN = valueAdd;
                        _pelist[_pelistIndex].I_NAME_GIVN = valueAdd;

                        if (boolCheckGIVEN == false)
                        {
                            boolCheckGIVEN = true;
                            //if (_slow < 2)
                            //{
                            //    if (valueAdd.Contains("doppelt") || valueAdd.Contains("ein zwei") || valueAdd.Contains("die selbe"))
                            //    {
                            //        if (DontCheck_Given(_pelist[_pelistIndex].AA_I_INDEX) == false)
                            //        {
                            //            errortext = separator + "GIVEN contains ..."
                            //                + separator + _pelist[_pelistIndex].I_NAME_NSFX
                            //                + "verh.;" + _pelist[_pelistIndex].I_NAME_MARNM
                            //                + separator + _pelist[_pelistIndex].I_NAME_SURN
                            //                + separator + _pelist[_pelistIndex].I_NAME_GIVN
                            //                + separator + _pelist[_pelistIndex].AA_I_INDEX
                            //                ;
                            //            Console.WriteLine(errortext);
                            //            AddError(_count.ToString(), "CHECKING", errortext);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    _info_0_text = "    _slow is ;" + _slow + "; NO_0008;CheckGiven: no output for each single entry";
                            //    Console.WriteLine(_info_0_text);
                            //    _info_new = new("INFO;", ";", _info_0_text);

                            //    //boolCheckGIVEN = true;
                            //}
                        }
                        break;
                    case "I_I_NAME_NICK": _pelist[_pelistIndex].I_NAME_NICK = valueAdd; break;
                    case "I_I_NAME__MAR": _pelist[_pelistIndex].I_NAME_MARNM = valueAdd; break;
                    case "I_I_NAME_SURN": _pelist[_pelistIndex].I_NAME_SURN = valueAdd; break;

                    case "I_I_NAME_NPFX": _pelist[_pelistIndex].I_NAME_NPFX = valueAdd; break;
                    case "I_I_NAME__FOR": _pelist[_pelistIndex].I_NAME__FOR = valueAdd; break;

                    case "I_I_BIRT_PLAC": _pelist[_pelistIndex].I_BIRT_PLAC = valueAdd; break;
                    case "I_I_BIRT_RIN ": /*_pelist[_pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                    case "I_I_BIRT__UID": /*_pelist[_pelistIndex].I_BIRT_UID = valueAdd;*/ break;
                    case "I_I_BIRT_NOTE": valueAdd = valueAdd.Replace(";", "#"); _pelist[_pelistIndex].I_BIRT_NOTE = valueAdd; break;

                    case "I_I_DEAT_DATE": _pelist[_pelistIndex].I_DEAT_DATE = valueAdd; break;
                    case "I_I_DEAT_PLAC": _pelist[_pelistIndex].I_DEAT_PLAC = valueAdd; break;
                    case "I_I_DEAT_CAUS": _pelist[_pelistIndex].I_DEAT_CAUS = valueAdd; break;
                    case "I_I_DEAT_AGE ": _pelist[_pelistIndex].I_DEAT_AGE = valueAdd; break;
                    case "I_I_DEAT__UID": /*_pelist[_pelistIndex].I_DEAT_UID = valueAdd;*/ break;
                    case "I_I_DEAT_RIN ": /*_pelist[_pelistIndex].I_DEAT_RIN = valueAdd;*/ break;
                    case "I_I_DEAT_NOTE": valueAdd = valueAdd.Replace(";", "#"); _pelist[_pelistIndex].I_DEAT_NOTE = valueAdd; break;
                    case "I_I_BURI_DATE": _pelist[_pelistIndex].I_BURI_DATE = valueAdd; break;
                    case "I_I_BURI_PLAC": _pelist[_pelistIndex].I_BURI_PLAC = valueAdd; break;
                    case "I_I_BURI_RIN ": /*_pelist[_pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                    case "I_I_BURI__UID": /*_pelist[_pelistIndex].I_BIRT_UID = valueAdd;*/ break;

                    //case "I_I_DIV_DATE": _pelist[_pelistIndex].I_DIV_DATE = valueAdd; break;
                    //case "I_I_DIV_PLAC": _pelist[_pelistIndex].I_DIV_PLAC = valueAdd; break;
                    case "I_I_RESI_EMAI": _pelist[_pelistIndex].I_EMAIL = valueAdd; break;
                    case "I_I_BAPM_PLAC": /*_pelist[_pelistIndex].I_BAPM_PLAC = valueAdd;*/ break;
                    case "I_I_BAPM_DATE": /*_pelist[_pelistIndex].I_BAPM_DATE = valueAdd;*/ break;
                    case "I_I_CONF_PLAC": _pelist[_pelistIndex].I_CONF_PLAC = valueAdd; break;
                    case "I_I_CONF_DATE": _pelist[_pelistIndex].I_CONF_DATE = valueAdd; break;
                    case "I_I_OCCU_PLAC": _pelist[_pelistIndex].I_OCCU_PLAC = valueAdd; break;
                    case "I_I_OCCU_DATE": _pelist[_pelistIndex].I_OCCU_DATE = valueAdd; break;
                    case "I_I_OCCU_AGE ": _pelist[_pelistIndex].I_OCCU_AGE = valueAdd; break;

                    case "I_I_CENS_PLAC": _pelist[_pelistIndex].I_CENS_PLAC = valueAdd; break;
                    //case "I_I_CENS_DATE": _pelist[_pelistIndex].I_CENS_DATE = valueAdd; break;
                    //case "I_I_OCCU_AGE ": _pelist[_pelistIndex].I_OCCU_AGE = valueAdd; break;
                    //case "I_I_RESI_EMAI": _pelist[_pelistIndex].I_EMAIL = valueAdd; break;

                    case "I_I_RESI_DATE": _pelist[_pelistIndex].I_RESI_DATE = valueAdd; break;
                    case "I_I_RESI_AGE ": _pelist[_pelistIndex].I_RESI_AGE = valueAdd; break;

                    case "I_I_ADDR_CONT": _pelist[_pelistIndex].I_RESI_ADDR = "Adress available"; break; // same like RESI ?
                    case "I_I_RESI_ADDR": _pelist[_pelistIndex].I_RESI_ADDR = valueAdd; break;

                    case "I_I_RESI_PLAC": _pelist[_pelistIndex].I_RESI_ADDR = " ### PLACE instead Address?:" + valueAdd; break;
                    case "I_I_RESI_PHON": _pelist[_pelistIndex].I_RESI_PHON = valueAdd; break;
                    case "I_I_RESI_FAX ": /*_pelist[_pelistIndex].I_RESI_FAX = valueAdd;*/ break;
                    case "I_I_RESI_NOTE": /*_pelist[_pelistIndex].I_RESI_NOTE = valueAdd;*/ break;
                    case "I_I_FAMC_PEDI": _pelist[_pelistIndex].I_FAMC_PEDI = valueAdd; break;

                    case "I_I_EVEN_DATE": _pelist[_pelistIndex].I_EVEN_DATE = valueAdd; break;
                    case "I_I_EVEN_NOTE": _pelist[_pelistIndex].I_EVEN_NOTE = valueAdd; break;
                    case "I_I_EVEN_AGE ": _pelist[_pelistIndex].I_EVEN_AGE = valueAdd; break;

                    case "I_I_EVEN__UID": /*_pelist[_pelistIndex].I_EVEN_UID = valueAdd;*/ break;
                    case "I_I_EVEN_RIN ": /*_pelist[_pelistIndex].I_EVEN_RIN = valueAdd;*/ break;
                    case "I_I_EVEN_TYPE": _pelist[_pelistIndex].I_EVEN_TYPE = valueAdd; break;
                    case "I_I_EVEN_PLAC": _pelist[_pelistIndex].I_EVEN_PLAC = valueAdd; break;

                    case "I_I_EMIG_PLAC": _pelist[_pelistIndex].I_EMIG_PLAC = valueAdd; break;

                    case "I_I_SOUR_DATA": _pelist[_pelistIndex].I_SOUR_DATA = valueAdd; break;
                    case "I_I_SOUR_EVEN": _pelist[_pelistIndex].I_SOUR_EVEN = valueAdd; break;
                    case "I_I_SOUR_PAGE": _pelist[_pelistIndex].I_SOUR_PAGE = valueAdd; break;
                    case "I_I_SOUR_QUAL": _pelist[_pelistIndex].I_SOUR_QUAL = valueAdd; break;
                    case "I_I_SOUR_QUAY": _pelist[_pelistIndex].I_SOUR_QUAY = valueAdd; break;
                    case "I_I_SOUR_RIN ": /*_pelist[_pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                    case "I_I_SOUR__UID": /*_pelist[_pelistIndex].I_BIRT_UID = valueAdd;*/ break;


                    case "I_I_OBJE_FORM": /*_pelist[_pelistIndex].I_OBJE_FORM = valueAdd;*/ break;
                    case "I_I_OBJE_FILE": _pelist[_pelistIndex].I_OBJE_FILE = valueAdd; break;
                    case "I_I_OBJE_TITL": _pelist[_pelistIndex].I_OBJE_TITL = valueAdd; break;
                    case "I_I_OBJE_NOTE": _pelist[_pelistIndex].I_OBJE_NOTE = valueAdd; break;
                    case "I_I_OBJE__PRI": /*_pelist[_pelistIndex].I_OBJE__PRI = valueAdd;*/ break;
                    case "I_I_OBJE__CUT": /*_pelist[_pelistIndex].I_OBJE__CUT = valueAdd;*/ break;
                    case "I_I_OBJE__PAR": /*_pelist[_pelistIndex].I_OBJE__PAR = valueAdd;*/ break;
                    case "I_I_OBJE__PER": /*_pelist[_pelistIndex].I_OBJE__PER = valueAdd;*/ break;
                    case "I_I_OBJE__PHO": /*_pelist[_pelistIndex].I_OBJE__PHO = valueAdd;*/ break;
                    case "I_I_OBJE__POS": /*_pelist[_pelistIndex].I_OBJE__POS = valueAdd;*/ break;
                    case "I_I_OBJE__DAT": _pelist[_pelistIndex].I_OBJE__DAT = valueAdd; break;
                    case "I_I_OBJE__ALB": _pelist[_pelistIndex].I_OBJE__ALB = valueAdd; break;
                    case "I_I_OBJE__FIL": /*_pelist[_pelistIndex].I_OBJE__FIL = valueAdd;*/ break;  // FILESIZE
                    case "I_I_OBJE__PLA": /*_pelist[_pelistIndex].I_OBJE__PLA = valueAdd;*/ break;  // PLACE



                    case "I_I_DATE_TIME": _pelist[_pelistIndex].I_DATE_TIME = valueAdd; break;
                    case "I_I_CHAN_DATE": _pelist[_pelistIndex].I_DATE_TIME = "### DATE: CHAN instead D+T: " + valueAdd; break;
                    case "I_I_NOTE_CONC": _pelist[_pelistIndex].I_NOTE_CONC = valueAdd; break;
                    //case "I_I_FILE": gedheadText += valueAdd; break;

                    case "I_I_NAME_NSFX":
                        _pelist[_pelistIndex].I_NAME_NSFX = valueAdd;

                        //if (_slow > 0)
                        //{
                        //    if (valueAdd.Contains("unklar") || valueAdd.Contains("Klärung") || valueAdd.Contains("lebt?"))
                        //    {
                        //        if (DontCheck_NSFX(_pelist[_pelistIndex].AA_I_INDEX) == false)
                        //        {
                        //            _info_0_text = blank //+ "____________________"
                        //            + blank + _pelist[_pelistIndex].I_NAME_NSFX
                        //            + " verh. " + _pelist[_pelistIndex].I_NAME_MARNM
                        //            + blank + _pelist[_pelistIndex].I_NAME_SURN
                        //            + blank + _pelist[_pelistIndex].I_NAME_GIVN
                        //            //+ " born: " + _pelist[_pelistIndex].I_BIRT_DATE  // these Values are added later
                        //            //+ " marr: " + _pelist[_pelistIndex].I_MARR_DATE
                        //            //+ " died: " + _pelist[_pelistIndex].I_DEAT_DATE
                        //            + blank + _pelist[_pelistIndex].AA_I_INDEX
                        //            ;
                        //            Console.WriteLine(_info_0_text);
                        //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
                        //        }
                        //    }
                        //}
                        break;

                    //if (_pelist[_pelistIndex].I_BIRT_DATE == "")
                    //{
                    //    _info_0_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pelist[_pelistIndex].AA_I_INDEX;
                    //    Console.WriteLine(_info_0_text);
                    //    AddError("1231232", "INFO", _info_0_text);

                    //    _pelist[_pelistIndex].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
                    //}


                    default:
                        //MessageBox.Show("Unknown key at v2 = {0}", v1);
                        //if (v0v1v2 != "F_F_MARR_ADDR" || v0v1v2 != "H_H__NAV__NAV" || v0v1v2 != "H_H_DATE_TIME")
                        unknownKeyText = _newline + "key not used at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": value = " + valueAdd;
                        Console.WriteLine(/*_newline + */"key not used at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": value = " + valueAdd);
                        //   >> message below

                        // v2 ignored

                        if (v0v1v2 == "H_H_DATE_TIME") unknownKeyText = "";
                        if (v0v1v2 == "H_H_DATE__TIM") unknownKeyText = "";
                        if (v0v1v2 == "H_H_SOUR__TRE") unknownKeyText = "";
                        if (v0v1v2 == "H_H__NAV__NAV") unknownKeyText = "";
                        if (v0v1v2 == "F_F_MARR_ADDR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_OCCU__UID") unknownKeyText = "";
                        if (v0v1v2 == "I_I_OCCU_RIN ") unknownKeyText = "";
                        if (v0v1v2 == "I_I_RESI__UID") unknownKeyText = "";
                        if (v0v1v2 == "I_I_RESI_RIN ") unknownKeyText = "";
                        if (v0v1v2 == "I_I_RESI_TYPE") unknownKeyText = "";
                        if (v0v1v2 == "I_I_RESI_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_NAME_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_BIRT_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_BAPM_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_DEAT_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "I_I_BURI_SOUR") unknownKeyText = "";
                        if (v0v1v2 == "F_F_DIV__UID") unknownKeyText = "";
                        if (v0v1v2 == "F_F_DIV_RIN ") unknownKeyText = "";
                        if (v0v1v2 == "F_F_ENGA__UID") unknownKeyText = "";
                        if (v0v1v2 == "F_F_ENGA_RIN ") unknownKeyText = "";
                        if (v0v1v2 == "F_F_MARL__UID") unknownKeyText = "";
                        if (v0v1v2 == "F_F_MARL_RIN ") unknownKeyText = "";

                        if (unknownKeyText != "")
                            Console.WriteLine(/*_newline + */"Unknown key at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": value = " + valueAdd);

                        break;

                }


                valueAdd = "";

            }
        }



        if (_slow < 2 && boolCheckUnklar == false)
        {
            _info_0_text = _slow_string + "; NO_0007;for unklar / Klärung / lebt";
            Xwrite("Step_9905", true, _info_0_text);


            boolCheckUnklar = true;
        }

        //if (_slow < x && lastPeListIndex_DONE > 0)  // to avoid crashes
        //{
        //    //lastPeListIndex_DONE = lastPeListIndex;

        //    string valueCheck = _pelist[lastPeListIndex_DONE].I_NAME_NSFX;
        //    if (valueCheck.Contains("unklar") || valueCheck.Contains("Klärung") || valueCheck.Contains("lebt?"))
        //    {
        //        if (DontCheck_NSFX(_pelist[lastPeListIndex].AA_I_INDI) == false)
        //        {
        //            errortext = blank //+ "____________________"
        //            + blank + _pelist[lastPeListIndex_DONE].I_NAME_NSFX
        //            + " verh. " + _pelist[lastPeListIndex_DONE].I_NAME_MARNM
        //            + blank + _pelist[lastPeListIndex_DONE].I_NAME_SURN
        //            + blank + _pelist[lastPeListIndex_DONE].I_NAME_GIVN
        //            + " born: " + _pelist[lastPeListIndex_DONE].I_BIRT_DATE
        //            + " born_at: " + _pelist[lastPeListIndex_DONE].I_BIRT_PLAC
        //            + " marr: " + _pelist[lastPeListIndex_DONE].I_MARR_DATE
        //            + " died: " + _pelist[lastPeListIndex_DONE].I_DEAT_DATE
        //            + " " + _pelist[lastPeListIndex_DONE].AA_I_INDI
        //            ;
        //            errortext = errortext.Replace("=", " = ");

        //            if (lastPeListIndex > lastPeListIndex_DONE)
        //            {
        //                Console.WriteLine(errortext);
        //                AddError(_count.ToString(), "Suffix contains 'unklar'", errortext);
        //                lastPeListIndex_DONE += 1;
        //            }
        //            //lastPeListIndex_DONE = lastPeListIndex;
        //        }
        //    }
        //    valueCheck = "";
        //}

        // STOPP
        //if (_CountLines > 30000)
        //    Console.WriteLine("Stopp at 30.000");


        //lastPeListIndex_DONE = lastPeListIndex;

        // end of : if (_first == "2")
        //#endregion _first = 2

        //lastPeListIndex_DONE = lastPeListIndex;



        if (_first == "0")
        {
            value = value.Replace("=-", "-");
            //Console.Xwrite("adding keyPrevious = {0}: {1}" + _newline, keyPrevious, value);
            //Console.Xwrite("adding keyPrevious = {0}" + _newline, keyPrevious);
            //_db.Add(keyPrevious, value);
            //dataGridView1.Rows.Add(keyPrevious, value);
            value = "";
            lastPeListIndex_DONE = lastPeListIndex - 1;
        }
        //lastPeListIndex_DONE = lastPeListIndex;


        //if (_pelistIndex >= 0 && _pelist[_pelistIndex].I_FAMS != "")
        //    SplitColl(_pelist[_pelistIndex].I_FAMS, ';');




        updateString = "";  // here !!




        //end while (streamReader



        // writing gedheadText
        _info_0_text = _newline + _newline + gedheadText + _newline;
        Console.WriteLine(_newline + _newline + gedheadText + _newline);
        _info_new = new("INFO;", ";", _info_0_text);
        _info_list.Add(_info_new);

        if (_pelist.Count > 0)
        {
            _info_0_text = "PERS-Count   ;" + _pelist.Count;
            Console.WriteLine(_newline + _info_0_text);
            _info_new = new("INFO;", ";", _info_0_text);
            _info_list.Add(_info_new);

            if (_famlist.Count > 0)
            {
                _info_0_text = "FAM-Count    ;" + _famlist.Count;
                Console.WriteLine(_newline + _info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);
            }
            if (_notelist.Count > 0)
            {
                _info_0_text = "NOTE-Count   ;" + _notelist.Count;
                //+ _newline;
                Console.WriteLine(_newline + _info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);
            }
            if (_albumlist.Count > 0)
            {
                _info_0_text = "ALBUM-Count  ;" + _albumlist.Count;
                //+ _newline;
                Console.WriteLine(_newline + _info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);
            }
            if (_source_list.Count > 0)
            {
                _info_0_text = "SOURCE-Count ;" + _source_list.Count;
                Console.WriteLine(_newline + _info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);
            }

            bool countfor = true;
            if (countfor == true)  // Count Section
            {
                string isEmptyString = " ";
                _info_0_text = "";
                _info_0_text += ";5555555;Count for ;TOTAL      ;" + _pelist.Count(a => a.I_SEX != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_BIRT_DATE;" + _pelist.Count(a => a.I_BIRT_DATE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_BIRT_PLAC;" + _pelist.Count(a => a.I_BIRT_PLAC != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_DEAT_DATE;" + _pelist.Count(a => a.I_DEAT_DATE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_DEAT_PLAC;" + _pelist.Count(a => a.I_DEAT_PLAC != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_BURI_PLAC;" + _pelist.Count(a => a.I_BURI_PLAC != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_FAMS     ;" + _pelist.Count(a => a.I_FAMS != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;F_HUSB     ;" + _famlist.Count(a => a.F_HUSB != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;F_WIFE     ;" + _famlist.Count(a => a.F_WIFE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;F_MARR_DATE;" + _famlist.Count(a => a.F_MARR_DATE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;F_MARR_PLAC;" + _famlist.Count(a => a.F_MARR_PLAC != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;F_MARR_NOTE;" + _famlist.Count(a => a.F_MARR_NOTE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_BIRT_NOTE;" + _pelist.Count(a => a.I_BIRT_NOTE != isEmptyString) + _newline; ;
                _info_0_text += ";5555555;Count for ;I_DEAT_NOTE;" + _pelist.Count(a => a.I_DEAT_NOTE != isEmptyString) + _newline; ;

                Console.WriteLine(_newline + _newline + _info_0_text + _newline);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);


            }


            //streamReader.Close();
            // end of reading


            _info_0_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";begin of Populate PersLineList";
            Console.WriteLine(_info_0_text);
            _info_new = new("INFO;", ";", _info_0_text);
            _info_list.Add(_info_new);

            ht = "_";
            for (int i = 0; i < _pelist.Count; i++)
            {


                _persLineHint = "";

                if (_pelist[i].I_DEAT == "DEAT Y")
                    _deatText = "DEAT Y";
                else
                    _deatText = "DEAT N";

                //I_FAMS
                if (_pelist[i].I_FAMS == " ")
                    _famsText = " Fxxxxxx-";
                else
                    _famsText = _pelist[i].I_FAMS;

                _persLineText =
                    _famsText
                + ht + _pelist[i].AA_I_INDEX
                + ht + _pelist[i].I_NAME_GIVN
                + ht + _pelist[i].I_NAME_SURN

                + ht + _pelist[i].I_NAME_MARNM
                + ht + "," + _pelist[i].I_BIRT_DATE
                + ht + _pelist[i].I_BIRT_PLAC
                + ht + _deatText
                + ht + "," + _pelist[i].I_DEAT_DATE
                + ht + _pelist[i].I_DEAT_PLAC
                + ht + _pelist[i].I_BURI_PLAC
                + ht + _pelist[i].I_NAME_NSFX

                + ht + _pelist[i].I_DEAT_CAUS
                //+ ht + afterHashtag(_pelist[i].I_DEAT_CAUS)
                + ht + _pelist[i].I_FAMC
                ;


                //_persLineText = CleanText(_persLineText);

                //AddPersLine(_pelist[i].AA_I_INDEX, _persLineText, _persLineHint);
                //                    public void AddPersLine(string persLine, string persCategory, string persText)
                //{
                PersLine persLineNew = new(_pelist[i].AA_I_INDEX, _persLineText, _persLineHint);
                //persLine
                //, persCategory
                //, persText
                //);
                _persLineList.Add(persLineNew);
                //}

                _dateString = ";;;;;";

                //1 _UPD 15 DEC 2019
                string updString = "1 _UPD 31 DEC 9999";
                if (_pelist[i].I_UPD.Length > 12)
                {
                    updString = GetUpdateString("x _UPD " + _pelist[i].I_UPD);  // length must be more than 11
                }
                else
                {
                    updString = "x _UPD 31 DEC 9999";
                }

                if (updString != "0;not 4,8,10,11;;")
                {
                    //AddUpdateLine(updString, "INDI", _persLineText);
                    Updates updatesNew = new(updString, "INDI", _persLineText);
                    _updateslist.Add(updatesNew);
                }


                //CheckBox for empty birth date - OFF
                //if (_pelist[i].I_BIRT_DATE == " ")
                //{
                //    string index = _pelist[i].AA_I_INDEX.Replace("I",""); 
                //    _info_0_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
                //        + index;
                //    Console.WriteLine(_info_0_text);
                //    AddError("1231232", "INFO", _info_0_text);
                //}

                //CheckBox for empty birth date
                if (_pelist[i].I_DEAT == "DEAT Y")

                    //string index = _pelist[i].AA_I_INDEX.Replace("I", "");
                    //_info_0_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
                    //    + index;
                    //Console.WriteLine(_info_0_text);
                    //AddError("1231232", "INFO", _info_0_text);
                    //if (valueAdd == "DEAT Y")
                    _pelist[i].I_SEX += "d";
                else
                    _pelist[i].I_SEX += "a";


                if (_pelist[i].I_BIRT != " ")
                {
                    _date = "," + _pelist[i].I_BIRT_DATE;
                    //_dateString = ";;;;;";
                    if (_pelist[i].I_BIRT_DATE != " ")
                        _dateString = GetDateString(_pelist[i].I_BIRT_DATE);
                    _place = _pelist[i].I_BIRT_PLAC;
                    _dio = "";
                    _cb = _pelist[i].I_BIRT_NOTE;
                    _dateColl = _dateString.Split(';');
                    _date_val = _dateColl[0];
                    if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                    _month = _dateColl[4];
                    _year = _dateColl[5];

                    _kind = "1-BIRTH";
                    _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, _pelist[i].AA_I_INDEX, _pelist[i].I_SEX, _persLineText);
                    _eventList.Add(_event_new);

                    if (_pelist[i].I_DEAT != " ")
                    {
                        _date = "," + _pelist[i].I_DEAT_DATE;
                        _dateString = (string)GetDateString(_pelist[i].I_DEAT_DATE);

                        _deathdateString = _dateString;
                        _place = _pelist[i].I_DEAT_PLAC;
                        _cb = _pelist[i].I_DEAT_NOTE;
                        _dateColl = _dateString.Split(';');
                        _date_val = _dateColl[0];
                        if (_dateColl.Length > 3)
                        {
                            if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                            _month = _dateColl[4];
                            _year = _dateColl[5];
                        }
                        else
                        {
                            Debugger.Break();
                        }



                        _kind = "4-DEATH";
                        _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, _pelist[i].AA_I_INDEX, _pelist[i].I_SEX, _persLineText);
                        _eventList.Add(_event_new);
                    }

                    if (_pelist[i].I_BURI != " ")
                    {
                        _date = "," + _pelist[i].I_BURI_DATE;
                        _dateString = GetDateString(_pelist[i].I_BURI_DATE);
                        if (_dateString == " ")
                        {
                            _dateString = _deathdateString;
                            _deathdateString = "";
                        }

                        _place = _pelist[i].I_BURI_PLAC;
                        _cb = "";
                        _dateColl = _dateString.Split(';');
                        _date_val = _dateColl[0];

                        if (_dateColl.Length > 3)
                        {
                            if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                            _month = _dateColl[4];
                            _year = _dateColl[5];
                        }
                        else
                        {
                            Debugger.Break();
                        }

                        _kind = "9-buried";
                        _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, _pelist[i].AA_I_INDEX, _pelist[i].I_SEX, _persLineText);
                        _eventList.Add(_event_new);
                    }
                }
                ht = "#";


                _info_0_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";end   of Populate PersLineList: " + _persLineList.Count;
                Console.WriteLine(_info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);

                _info_0_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";end   of Populate EventList: " + _eventList.Count;
                Console.WriteLine(_info_0_text);
                _info_new = new("INFO;", ";", _info_0_text);
                _info_list.Add(_info_new);

            }
            Xwrite("Step_2202", true, _count + _newline + " > DoReplace_stuff ");

            SaveInfo(_path, "__ged_IN_info.txt");


            Do_99_PlaySound();

            Console.WriteLine(Environment.NewLine + "Press ENTER to finish !");
            _info_new = new("INFO;", ";", _info_0_text);
            _info_list.Add(_info_new);

            Console.ReadLine();
        }
        _info_0_text = "endofMain";
    }



    private static void A05_DoAutosave(List<string> _all_lines)
    {
        //Debugger.Break();
        //try
        //{
        //_start_time = DateTime.Now;
        // run processing on background thread and get processed lines


        StreamWriter _stream_Writer = new(File.Open(_out_file, FileMode.Create), Encoding.UTF8);

        int _count = -1;
        _nextGoalOfLines = 1000000;

        _info_0_text = "Output";
        //string _all_text = "";
        foreach (var _line in _all_lines)
        {
            _count += 1;

            //string _all_text = DoReplace_Months_Days(_line);
            //_all_text += Environment.NewLine + _line;
            //Debugger.Break(); return "";

            _stream_Writer.WriteLine(_line);

            if (_count > _nextGoalOfLines)
            {
                _info_0_text = " autosav > " + _count.ToString() + ":_start=;" + _start_time;
                Xwrite("Step_1800", true, _info_0_text);

                _nextGoalOfLines += 1000000;
            }
        }
        //Debugger.Break(); return "";
        //_stream_Writer.Xwrite(_all_text);
        //Thread.Sleep(2000);

        _stream_Writer.Close();
        _info_0_text = " autosav > " + _count.ToString() + " > FINISHED ";
        Xwrite("Step_1900", true, _info_0_text);
        //}
        //catch (Exception ex)
        //{
        //    _info_0_text = DateTime.Now + " > Error: " + ex.Message;
        //    Xwrite("Step_9900", true, _count + _newline + " > DoReplace_stuff ");
        //    Debugger.Break();
        //}
    }


    private static void Xwrite(string _v, bool _print, string _line_string)
    {
        _info_0_text = _v + ":; " + DateTime.Now + " > " + _line_string;
        //Console.WriteLine(_info_0_text);
        Trace.WriteLine(_info_0_text);
        if (_print)
        {
            _info_new = new("INFO;", ";", _info_0_text);
            _info_list.Add(_info_new);
        }

    }

    public static void SaveInfo(string path, string file)
    {
        char _separatorArray = ';';
        //string arrayline;// = "";
        string _newline = Environment.NewLine;
        string txt = ".txt";
        //Console.WriteLine(_newline + _newline + "##### Errors:" + _newline);

        string arrayFileERRORS = path + file + "__ERRORS_out" + txt;
        //////if (vout == true)  // always
        //////{
        //////    arrayFileERRORS = "V:/" + file + "__ERRORS_out.txt";
        //////    infoText = "    _____start;" + _start_time_global + ";now;" + DateTime.Now + ";_slow_1;" + arrayFileERRORS;
        //////    Console.WriteLine(infoText);
        //////    AddError("8888888", "INFO", infoText);
        //////}
        //////else
        //////{
        //infoText = "    start;" + _start_time_global + ";now;" + DateTime.Now + ";_slow;" + _slow + ";" + arrayFileERRORS;
        //Console.WriteLine(infoText);
        //AddError("8888888", "INFO", infoText);
        //////}

        StreamWriter streamWriterERRORS = new(File.Open(arrayFileERRORS, FileMode.Create), Encoding.UTF8);
        //Console.WriteLine("___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + ";BEGIN;streamWriterERRORS = _ERRORS_out" + txt);

        string strHeaderERRORS = "E_LINE;E_INDEX;E_TEXT;E_HINT;E_EMPTY";

        //for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //{
        //    strHeaderArray += dataGridView1.Columns[i].HeaderText + _separatorstringArray;
        //}

        //strHeaderArray = strHeaderArray.TrimEnd(_separatorArray);

        streamWriterERRORS.WriteLine(strHeaderERRORS);

        //for (int j = 0; j < _pelist.Count - 1; j++)
        int errorsMax = _info_list.Count;
        //errorsMax = 10; if (errorsMax > _info_list.Count) errorsMax = _info_list.Count; // limited to 50 Persone

        for (int j = 0; j < errorsMax; j++)                         // limited to 50 Persone
        {
            // Xwrite ERRORSs
            //if (_info_list[j].AA_E_INDEX.[..1] == "N")
            //{

            string arrayline = //{0} + {1} {2} {3} {4} {5} {6}"
                _separatorArray + _info_list[j].AA_E_INDEX
                + _separatorArray + _info_list[j].E_TEXT
                + _separatorArray + _info_list[j].E_HINT
                ;

            // arrayline = CleanText(arrayline);   // not for errors

            //Console.WriteLine(arrayline);

            streamWriterERRORS.WriteLine(arrayline);
            //arrayline = "";
            //}



        }
        streamWriterERRORS.WriteLine(_newline + "#######   maybe not finished ... this is __Errors_Out.txt - it is now: " + DateTime.Now + _newline + _newline);
        streamWriterERRORS.Close();
        //Console.WriteLine("___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + ";END  ;streamWriterERRORS = _ERRORS_out" + txt);
        //#endregion End write ERRORS
    }

    //private static void SaveEntry(string keyPrevious, string entryText, string updateString, string sourceString)
    //{
    //    Debugger.Break();
    //}

    private static string GetDateString(string dateIN)
    {
        int _slow = 8;
        int _count = 0;
        bool bool_getDateValue = false;
        string _info_text;// = "";
        string ValDateString = "0";
        //if (dateIN.Contains("x")) //-TURNEDOFF"))
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        string dateIN_old = dateIN;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        //if (dateIN_old == "xyz") dateIN_old = "z";

        //if (dateIN == "ca. Jul 1615")
        //    dateIN = dateIN.Replace("=", "");

        if (dateIN.Contains("x-TURNEDOFF"))
        {
            _info_text = _count.ToString() + "date contains 'x';" + dateIN;
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
            _info_list.Add(_info_new);

            _info_text = _count.ToString() + "date contains 'x';" + dateIN;
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
            _info_list.Add(_info_new);
            //AddError(_count.ToString(), "date contains 'x';", dateIN);
            //_lineString = _lineString.Replace("&nbsp;", " ");
        }
        if (dateIN.Length > 0 && dateIN[..1] != "u")
            bool_getDateValue = true;

        string day = "";
        string month = "";
        string year = "";
        //string 
        string dateOUT = ";;";
        string separator = ";";
        dateIN = dateIN.Replace("ABT ", "");
        dateIN = dateIN.Replace("BEF ", "");
        dateIN = dateIN.Replace("CALC ", "");
        dateIN = dateIN.Replace("=", "");
        dateIN = dateIN.Replace("ca. ", "");
        dateIN = dateIN.Replace("ca.", "");

        dateIN = dateIN.Replace(" Januar ", " JAN ");
        dateIN = dateIN.Replace(" Februar ", " FEB ");
        dateIN = dateIN.Replace(" März ", " MAR ");
        dateIN = dateIN.Replace(" April ", " APR ");
        dateIN = dateIN.Replace(" Mai ", " MAY ");
        dateIN = dateIN.Replace(" Juni ", " JUN ");
        dateIN = dateIN.Replace(" Juli ", " JUL ");
        dateIN = dateIN.Replace(" August ", " AUG ");
        dateIN = dateIN.Replace(" September ", " SEP ");
        dateIN = dateIN.Replace(" Oktober ", " OCT ");
        dateIN = dateIN.Replace(" November ", " NOV ");
        dateIN = dateIN.Replace(" Dezember ", " DEC ");



        //int dateIN_Length = dateIN.Length;

        switch (dateIN.Length.ToString())
        {
            case "0": break; // Empty

            case "12":
                // for some tasks the date comes with leading '0' and leading character e.g. u for _UPD
                dateIN = dateIN.Substring(1, 11);
                year = dateIN.Substring(7, 4); month = GetMonthNumeric(dateIN.Substring(3, 3));
                //day = dateIN.Substring(0, 2);
                day = dateIN[..2];
                dateOUT = day + separator + month + separator + year;
                break;

            case "11":
                //if (dateIN.Length == 11)
                //{
                year = dateIN.Substring(7, 4); month = GetMonthNumeric(dateIN.Substring(3, 3));
                //day = dateIN.Substring(0, 2);
                day = dateIN[..2];
                dateOUT = day + separator + month + separator + year;
                //if (day[..1].Contains("0"))
                if (day[..1].Contains('0'))
                {
                    _info_text = "day contains leading '0';" + dateIN;
                    Console.WriteLine(_info_text);
                    _info_new = new("INFO;", ";", _info_text);
                    _info_list.Add(_info_new);
                    //_lineString = _lineString.Replace("&nbsp;", " ");
                    day = "";
                }
                ;
                //}
                break;

            case "10":
                //if (dateIN.Length == 10)
                //{
                year = dateIN.Substring(6, 4); month = GetMonthNumeric(dateIN.Substring(2, 3)); day = dateIN[..1];
                dateOUT = day + separator + month + separator + year;
                //}
                break;

            case "9":
                if (dateIN == "unbekannt" || dateIN == "unbekannt=")
                    dateOUT = "unbekannt";
                break;
            //{


            case "8":
                //if (dateIN.Length == 8)
                //{
                year = dateIN.Substring(4, 4);
                //month = GetMonthNumeric(dateIN.Substring(0, 3)); 
                month = GetMonthNumeric(dateIN[..3]); //day = dateIN.[..1];
                dateOUT = /*day + */separator + month + separator + year;
                //}
                break;

            case "4":
                //if (dateIN.Length == 4)
                //{
                //year = dateIN.Substring(0, 4); 
                year = dateIN[..4];
                dateOUT = /*day +*/ separator + /*month +*/ separator + year;
                //}
                break;
            default:
                dateOUT = "not 4,8,10,11;;";
                //Console.WriteLine(dateOUT + dateIN_old); 
                //dateOUT = ";;";
                break;
        }

        if (_slow > 12 && dateOUT.Contains("not"))
        {
            _info_text = "dateOUT contains 'not';" + dateIN;
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
            _info_list.Add(_info_new);
            //_lineString = _lineString.Replace("&nbsp;", " ");
        }


        if (bool_getDateValue == true && _slow > 0 && year != "")
            try
            {
                float valYear = 0f;
                float valDay = 0f;
                float valMonth = 0f;
                float valDate = 0f;
                ValDateString = "0;;";

                if (year != "") valYear = float.Parse(year);

                if (day != "") valDay = float.Parse(day);

                //float valMonth = 0;
                valMonth = month switch
                {
                    "01" => 0f,
                    "02" => 31f,
                    "03" => 59.25f,
                    "04" => 90.25f,
                    "05" => 120.25f,
                    "06" => 151.25f,
                    "07" => 181.25f,
                    "08" => 212.25f,
                    "09" => 243.25f,
                    "10" => 273.25f,
                    "11" => 304.25f,
                    "12" => 334.25f,
                    _ => 0f,
                };
                if (valYear < 1900f) valYear += 2000f;

                valDate = ((valYear - 1900f) * 365.24219f) + 1 + valMonth + valDay;  // Excel 1.1.1900 = 1

                if (float.Parse(year) < 1900f)
                    valDate -= 730486.5f;



                if (valDate != 0f)
                {
                    ValDateString =
                        "" + ((int)valDate / 1).ToString()
                        + ";" + ((int)valDate / 10).ToString()
                        + ";" + ((int)valDate / 100).ToString()
                        + ""
                        ;
                }
            }
            catch
            {
                ValDateString = "nv;nv;nv";
            }

        return /*separator + */ValDateString + separator + dateOUT;
    }

    public static string GetMonthNumeric(string month)
    {
        month = month switch
        {
            "JAN" => "01",
            "FEB" => "02",
            "MAR" => "03",
            "APR" => "04",
            "MAY" => "05",
            "JUN" => "06",
            "JUL" => "07",
            "AUG" => "08",
            "SEP" => "09",
            "OCT" => "10",
            "NOV" => "11",
            "DEC" => "12",
            _ => "",
        };
        return month;
    }

    //private static string CleanText(string valueAdd)
    //{
    //    //Debugger.Break(); return "";
    //}

    private static string CleanID(string id)
    {
        id = id.Replace("@", "");
        id = id.Replace("=", "");
        id = id.Replace(";", "");
        id = id.Replace(" ", "");
        id = id.Replace("#", "");
        return id;
    }

    private static void Do_99_PlaySound()
    {
        // Sound abspielen (benötigt .wav-Datei oder Resource)
        try
        {

#pragma warning disable CA1416 // Validate platform compatibility > only Windows supports System.Media.SoundPlayer, no other OS

            using var player = new SoundPlayer(@"C:\\DB\\sound001.wav");
            player.PlaySync();
#pragma warning restore CA1416 // Validate platform compatibility
            //Console.WriteLine("\nSound abgespielt!");
        }
        catch
        {
            _info_0_text = "\nSound-Datei nicht gefunden.";
            //Console.WriteLine(_info_0_text);
            //_info_new = new("INFO;", ";", _info_0_text);
            //_info_list.Add(_info_new);
            Xwrite("Step_9909", true, _info_0_text);
        }
    }

    private static string DoReplace_stuff(string _line_string, out string _line2)
    {
        //bool boolChecknbsp = false;

        _line_string = _line_string.Replace(@"/ Sr.M.", "# Sr.M.");
        //_line_string = _line_string.Replace("\"", "");

        //_line_string = _line_string.Replace(" /", " > ");  // inside FullName
        //_line_string = _line_string.Replace("/", "");

        _line_string = _line_string.Replace("&gt;", ">");
        _line_string = _line_string.Replace("&auml;", "ä");
        _line_string = _line_string.Replace("&ouml;", "ö");
        _line_string = _line_string.Replace("&uuml;", "ü");
        _line_string = _line_string.Replace("&szlig;", "ß");
        _line_string = _line_string.Replace("&amp;", "=");

        _line_string = _line_string.Replace(";;;;;", " - ");
        _line_string = _line_string.Replace("=", "");
        _line_string = _line_string.Replace("https://", "");
        _line_string = _line_string.Replace("http://", "");
        _line_string = _line_string.Replace("<p># ", "");
        _line_string = _line_string.Replace(" GMT -0500", "");

        _line_string = _line_string.Replace("<a href", "");
        _line_string = _line_string.Replace("</a>", "");
        _line_string = _line_string.Replace("</p>", "");
        _line_string = _line_string.Replace("@;", ";");
        _line_string = _line_string.Replace("@", "");
        _line_string = _line_string.Replace("*", "");
        _line_string = _line_string.Replace(" # ;", ";");
        _line_string = _line_string.Replace("\";\"", ";");
        _line_string = _line_string.Replace("MH:I", "");
        _line_string = _line_string.Replace("\"", "");
        _line_string = _line_string.Replace("\";\"", ";");


        _line_string = _line_string.Replace("M255-", "M.255-");

        if (_slow < 2 && boolChecknbsp == false)
        {

            _info_0_text = "    _slow is ;" + _slow_string + "; NO_0006;for <p>&nbsp;";
            Console.WriteLine(_info_0_text);
            _info_new = new("INFO;", ";", _info_0_text);
            boolChecknbsp = true;

            if (_slow > 12 && _line_string.Contains("<p>&nbsp;"))
            {
                _info_new = new(_count.ToString(), "line contains <p>&nbsp;", _line_string);
                _info_list.Add(_info_new);

                _line_string = _line_string.Replace("&nbsp;", " ");
                _line_string = _line_string.Replace("<p>&nbsp;</p>" + _newline, " ");
            }
        }

        _line2 = _line_string;
        return _line2;
    }

    private static string DoReplace_Months_Days(string lineString)
    {
        //_line_string = _in;

        lineString = lineString.Replace(" JAN ", ".01.");
        lineString = lineString.Replace(" FEB ", ".02.");
        lineString = lineString.Replace(" MAR ", ".03.");
        lineString = lineString.Replace(" APR ", ".04.");
        lineString = lineString.Replace(" MAY ", ".05.");
        lineString = lineString.Replace(" JUN ", ".06.");
        lineString = lineString.Replace(" JUL ", ".07.");
        lineString = lineString.Replace(" AUG ", ".08.");
        lineString = lineString.Replace(" SEP ", ".09.");
        lineString = lineString.Replace(" OCT ", ".10.");
        lineString = lineString.Replace(" NOV ", ".11.");
        lineString = lineString.Replace(" DEC ", ".12.");

        //_line_string = _line_string.Replace(". JAN ", ".01.");
        //_line_string = _line_string.Replace(". FEB ", ".02.");
        //_line_string = _line_string.Replace(". MAR ", ".03.");
        //_line_string = _line_string.Replace(". APR ", ".04.");
        //_line_string = _line_string.Replace(". MAY ", ".05.");
        //_line_string = _line_string.Replace(". JUN ", ".06.");
        //_line_string = _line_string.Replace(". JUL ", ".07.");
        //_line_string = _line_string.Replace(". AUG ", ".08.");
        //_line_string = _line_string.Replace(". SEP ", ".09.");
        //_line_string = _line_string.Replace(". OCT ", ".10.");
        //_line_string = _line_string.Replace(". NOV ", ".11.");
        //_line_string = _line_string.Replace(". DEC ", ".12.");

        lineString = lineString.Replace("\t1.", "\t01.");
        lineString = lineString.Replace("\t2.", "\t02.");
        lineString = lineString.Replace("\t3.", "\t03.");
        lineString = lineString.Replace("\t4.", "\t04.");
        lineString = lineString.Replace("\t5.", "\t05.");
        lineString = lineString.Replace("\t6.", "\t06.");
        lineString = lineString.Replace("\t7.", "\t07.");
        lineString = lineString.Replace("\t8.", "\t08.");
        lineString = lineString.Replace("\t9.", "\t09.");

        lineString = lineString.Replace("\"1.", "\"01.");
        lineString = lineString.Replace("\"2.", "\"02.");
        lineString = lineString.Replace("\"3.", "\"03.");
        lineString = lineString.Replace("\"4.", "\"04.");
        lineString = lineString.Replace("\"5.", "\"05.");
        lineString = lineString.Replace("\"6.", "\"06.");
        lineString = lineString.Replace("\"7.", "\"07.");
        lineString = lineString.Replace("\"8.", "\"08.");
        lineString = lineString.Replace("\"9.", "\"09.");

        lineString = lineString.Replace("F,1.", "F,01.");
        lineString = lineString.Replace("F,2.", "F,02.");
        lineString = lineString.Replace("F,3.", "F,03.");
        lineString = lineString.Replace("F,4.", "F,04.");
        lineString = lineString.Replace("F,5.", "F,05.");
        lineString = lineString.Replace("F,6.", "F,06.");
        lineString = lineString.Replace("F,7.", "F,07.");
        lineString = lineString.Replace("F,8.", "F,08.");
        lineString = lineString.Replace("F,9.", "F,09.");

        lineString = lineString.Replace("M,1.", "M,01.");
        lineString = lineString.Replace("M,2.", "M,02.");
        lineString = lineString.Replace("M,3.", "M,03.");
        lineString = lineString.Replace("M,4.", "M,04.");
        lineString = lineString.Replace("M,5.", "M,05.");
        lineString = lineString.Replace("M,6.", "M,06.");
        lineString = lineString.Replace("M,7.", "M,07.");
        lineString = lineString.Replace("M,8.", "M,08.");
        lineString = lineString.Replace("M,9.", "M,09.");


        return lineString;
    }

#pragma warning disable CA1822 // Mark members as static
    private string DoReplace_DIV(string _line_string)
#pragma warning restore CA1822 // Mark members as static
    {
        //Console.WriteLine(_br);
        //Console.WriteLine("reading= ;" + _line_string);
        //_line_string = _in;
        string _br = " <br>";
        string _newline = Environment.NewLine;
        //int _count = 0;

        //_line_string = _line_string.Replace("\"", "");
        _line_string = _line_string.Replace(@"/ Sr.M.", "# Sr.M.");
        _line_string = _line_string.Replace("&gt;", ">");
        _line_string = _line_string.Replace("&Auml;", "Ä");
        _line_string = _line_string.Replace("&auml;", "ä");
        _line_string = _line_string.Replace("&Ouml;", "Ö");
        _line_string = _line_string.Replace("&ouml;", "ö");
        _line_string = _line_string.Replace("&Uuml;", "Ü");
        _line_string = _line_string.Replace("&uuml;", "ü");
        _line_string = _line_string.Replace("&szlig;", "ß");
        //_line_string = _line_string.Replace("&auml;", "ä");
        //_line_string = _line_string.Replace("&ouml;", "ö");
        //_line_string = _line_string.Replace("&uuml;", "ü");
        //_line_string = _line_string.Replace("&szlig;", "ß");
        _line_string = _line_string.Replace("&amp;", "=");
        //_line_string = _line_string.Replace("\",\"", ";");
        //_line_string = _line_string.Replace("\"", "");
        //_line_string = _line_string.Replace("\\", "");
        _line_string = _line_string.Replace("?", "");
        //_line_string = _line_string.Replace("+ ", "& ");
        //_line_string = _line_string.Replace("* ", "");
        _line_string = _line_string.Replace("...", "");


        //_line_string = _line_string.Replace("um.  .", "ABT ");
        //_line_string = _line_string.Replace("ca.  .", "ABT ");
        //_line_string = _line_string.Replace("ca. ", "ABT ");
        //_line_string = _line_string.Replace("ca.", "ABT ");
        //_line_string = _line_string.Replace("in.", "ABT ");
        //_line_string = _line_string.Replace(".  .", "ABT ");
        //_line_string = _line_string.Replace(" .", "ABT ");

        _line_string = _line_string.Replace("Kiening: Genealogie  <h1>", "Kiening: Genealogie  <h1> RR ");
        _line_string = _line_string.Replace("Kiening: Genealogie  <h1> RR RR ", "Kiening: Genealogie  <h1> RR ");
        _line_string = _line_string.Replace("<meta name=\"robots\" content=\"nofollow\">"
            , "<meta name=\"robots\" content=\"nofollow\">\r\n<meta http-equiv=Content-Type content=\"text/html; charset=unicode\">");
        _line_string = _line_string.Replace("<body>", _br + "<body>" + _br);
        _line_string = _line_string.Replace("</title> ", /*_br + */"</title> " + _br);

        _line_string = _line_string.Replace("<a name=\"", "{");

        _info_0_text = _newline + "A " + _line_string;
        Console.WriteLine(_info_0_text);
        _info_new = new("INFO;", ";", _info_0_text);
        _info_list.Add(_info_new);

        if (_line_string.Length == 0)
        {
            _info_0_text = _slow_string + "; NO_0099;#### line is empty;";// + _count.ToString();
            Xwrite("Step_1205", true, _line_string);

        }



        if (boolChecknbsp == false && _slow > 1 && _line_string.Contains("&nbsp;"))
        {
            //AddError(_count.ToString(), "line contains &nbsp;", "");
            _info_0_text = "    _slow is ;" + _slow_string + "; NO_0098;line contains &nbsp;";// + _count.ToString();
            Xwrite("Step_1215", true, _line_string);

            _line_string = _line_string.Replace("&nbsp;", " ");


        }
        else if (boolChecknbsp == true)
        {

        }
        else
        {
            _info_0_text = "    _slow is ;" + _slow_string + "; NO_0005;no output for &nbsp;";
            Xwrite("Step_1235", true, _line_string);

            boolChecknbsp = true;

        }


        return _line_string;
    }

    private static string DoReplace_aname(string _line_string)
    {
        //_line_string = _in;
        string _newline = Environment.NewLine;
        string _text;

        string aname = "{";
        string anameString;
        string _nr;// = "";
        int _length;
        int _length1;
        int _begin = 0;
        int _count = 0;

        if (_line_string.Contains(aname))
        {
            //Console.WriteLine(_newline + "A " + _line_string);
            //_info_new = new(_newline + "A " + _line_string);
            //_info_list.Add(_info_new);

            string _introText = _line_string.Substring(0, _begin);
            //string errortext; = "";
            int firstblank = 0;
            int secondblankOrEnd;
            int thirdblankOrEnd;

            //_line_string = _line_string.Replace(", ", "");

            if (_line_string.Contains('{')) firstblank = _line_string.IndexOf('{');

            // SecondBlankOrEnd
            int start = firstblank + 1;
            int stopp = _line_string.Length - start - 1;
            if (stopp < 1) { stopp = 0; }
            secondblankOrEnd = _line_string.Substring(start, stopp).IndexOf('{');

            anameString = _line_string.Substring(firstblank, _line_string.Length - start/* - 1*/);
            _length = anameString.IndexOf('"') - 1;

            _nr = _line_string.Substring(firstblank + 1, _length);

            // 3rd
            start = firstblank + secondblankOrEnd + 2;
            stopp = _line_string.Length - start - 1;
            thirdblankOrEnd = _line_string.Substring(start, stopp).IndexOf('{');
            if (thirdblankOrEnd == -1) { thirdblankOrEnd = 0; }

            if (secondblankOrEnd < 2)
                secondblankOrEnd = _line_string.Length - 2;

            //#pragma warning disable CA1845 // Use span-based 'string.Concat'
            //_line_string = _introText + _line_string.Substring(_begin, secondblankOrEnd + 2);
            _line_string = string.Concat(_introText, _line_string.AsSpan(_begin, secondblankOrEnd + 2));
            //#pragma warning restore CA1845 // Use span-based 'string.Concat'

            _line_string = _line_string.Replace("{", "  K" + _nr + " <a name=\"");

            //_line_string = _line_string.Replace("_", " ");
            _text =
                _count + " > "
                + "firstblank =" + firstblank
                + ", =" + secondblankOrEnd
                + ", =" + thirdblankOrEnd + _newline
                + ", " + _line_string
                //+ ", " + _line_string
                ;
            Console.WriteLine(_newline + _text);
            //Console.WriteLine(_newline + _introText);



            //Console.WriteLine("A " + _line_string);
            _length1 = _line_string.IndexOf('{');

            if (_line_string.Length < _length1)
                anameString = _line_string.Substring(1, _length1);

            _length = anameString.IndexOf('"');
            _nr = anameString.Substring(0, _length);
            _line_string = _line_string.Replace("{", "Kxx" + _nr /*+ _br + _newline*/ + " " + aname);

            //_line_string = _line_string + "K" + _nr + _br;
            _line_string = _line_string.Replace("{", "<a name=\"");
            _line_string = _line_string.Replace("Kxx", "K");

            _info_0_text = "B " + _line_string;

            Xwrite("Step_1245", true, _line_string);

        }
        return _line_string;
    }

    // New: Read and process lines without UI calls
    private static List<string> A01_Read_Input(string path, string file, string extension)
    {
        var result = new List<string>();

        //string _nowREAD;
        //string _info_0_text;// = _nowREAD;
        //string _comment_inside_code = "";
        _info_0_text = DateTime.Now + " > starting >> input: " + path + file + extension;
        Console.WriteLine(_info_0_text);
        _info_new = new("INFO;", ";", _info_0_text);
        _info_list.Add(_info_new);
        //_info_new = new("INFO;", ";", _info_0_text);

        DateTime _start_time = DateTime.Now;
        int lastPeListIndex = 0;
        int _count = 0;
        _nextGoalOfLines = 1000000 - 2;

        string fullPath = Path.Combine(path, file + extension);
        if (!File.Exists(fullPath))
        {
            _info_0_text = "Input-File not found >> " + path + file + extension;
            Console.WriteLine(_info_0_text);
            _info_new = new("INFO;", ";", _info_0_text);
            _info_list.Add(_info_new);
            //_ = MessageBox.Show("Input-File not found", "BEWARE", MessageBoxButtons.OK);
            //return result;
        }

        //db = new Dictionary<string, string>();

        //#pragma warning disable SYSLIB0001 // Type or member is obsolete
        //using (StreamReader _stream_Reader = new(fullPath, Encoding.UTF7))
        using (StreamReader _stream_Reader = new(fullPath, Encoding.UTF8))
        {
            _count = 0;
            _nextGoalOfLines = 1000000 - 1;
            while (_stream_Reader.Peek() != -1)
            {
                _count++;
                if (_count > _nextGoalOfLines)
                {
                    _info_0_text = " reading > " + _count.ToString() + ":_start=;" + _start_time;
                    Xwrite("Step_1100", true, _info_0_text);
                    _nextGoalOfLines += 1000000;
                }

                string? _line = _stream_Reader.ReadLine();
                if (_line == null) continue;

                //Debugger.Break(); return "";

                // perform replacements (reuse existing method)


                _comment_inside_code = "NOT HERE _line = DoReplace_Months_Days(_line);";

                string key = _count.ToString();
                //db.Add(key, _line);
                result.Add(_line);

                int lastPeListIndex_DONE = lastPeListIndex - 1;
                lastPeListIndex = 1 + lastPeListIndex - 1 + 1;
            }
        }
        //#pragma warning restore SYSLIB0001 // Type or member is obsolete

        _info_0_text = " reading > " + _count.ToString() + " > FINISHED ";
        Xwrite("Step_1200", true, _info_0_text);

        _count = 0;
        _nextGoalOfLines = 20000 + _count;

        //_places = new Dictionary<string, int>();

        return result;
    }

    public static string GetUpdateString(string _upd)
    {
        //string updOriginal = _upd;
        //string _text;// = "";
        //_text = updOriginal;
        //_text = "";
        //Console.WriteLine(updOriginal);

        _upd = _upd.Replace("_UPD 1 ", "_UPD 01 ");
        _upd = _upd.Replace("_UPD 2 ", "_UPD 02 ");
        _upd = _upd.Replace("_UPD 3 ", "_UPD 03 ");
        _upd = _upd.Replace("_UPD 4 ", "_UPD 04 ");
        _upd = _upd.Replace("_UPD 5 ", "_UPD 05 ");
        _upd = _upd.Replace("_UPD 6 ", "_UPD 06 ");
        _upd = _upd.Replace("_UPD 7 ", "_UPD 07 ");
        _upd = _upd.Replace("_UPD 8 ", "_UPD 08 ");
        _upd = _upd.Replace("_UPD 9 ", "_UPD 09 ");


        // 1 _UPD 15 DEC 2019 07:05:18 GMT+1
        //_upd = "u" + _upd.Substring(7, 11);  // add u before GetDate to avoid contains leading '0'  // yxc
        _upd = string.Concat("u", _upd.AsSpan(7, 11));  // add u before GetDate to avoid contains leading '0'  // yxc
        _upd = GetDateString(_upd);
        //_upd = _upd.Substring(1, _upd.Length - 1);
        _upd = _upd[1..];
        //int sEnd = _upd.Length;
        //Console.WriteLine(sEnd);
        int sStart = _upd.LastIndexOf(";20");
        string sYear = _upd.Substring(sStart + 1, 4);
        string sMonth = "00";
        if (sStart + 1 - 3 > -1)
            sMonth = _upd.Substring(sStart + 1 - 3, 2);
        string sDay = "00";
        if (sStart + 1 - 6 > -1)
            sDay = _upd.Substring(sStart + 1 - 6, 2);
        //Console.WriteLine("sEnd= {0} sStart= {1} year= {2} year= {3} year= {4}", sEnd, sStart, sYear, sMonth, sDay);

        return sYear + "-" + sMonth + "-" + sDay;
    }





    public class Fam(
        string aa_f_index
            //, string f_rin
            //, string f__uid
            , string f_husb
            , string f_wife
            , string f_chil
            , string f_marr
            //, string f_marr_rin
            //, string f_marr__uid
            , string f_marr_date
            , string f_marr_plac
            , string f_marr_note

            , string f_marl
            , string f_marl_date
            , string f_marl_plac
            , string f_marl_note

            , string f_div
            , string f_div_date
            , string f_div_plac
            , string f_div_note

            , string f_enga
            , string f_enga_date
            , string f_enga_plac
            , string f_enga_note

            , string f_anul
            , string f_anul_date
            , string f_anul_plac
            , string f_anul_note

            , string f_even
            //, string f_even_rin
            //, string f_even__uid
            , string f_even_type
            , string f_even_date
            , string f_even_plac
            , string f_even_note
            , string f__upd
            )
    {
        public string AA_F_INDEX = aa_f_index;
        //public string F_RIN;
        //public string F__UID;
        public string F_HUSB = f_husb;
        public string F_WIFE = f_wife;
        public string F_CHIL = f_chil;

        public string F_MARR = f_marr;
        //public string F_MARR__UID;
        //public string F_MARR_RIN;
        public string F_MARR_DATE = f_marr_date;
        public string F_MARR_PLAC = f_marr_plac;
        public string F_MARR_NOTE = f_marr_note;
        //public string F_EVEN_RIN;
        //public string F_EVEN__UID;
        public string F_EVEN_TYPE = f_even_type;
        public string F_EVEN_DATE = f_even_date;
        public string F_EVEN_PLAC = f_even_plac;
        public string F_EVEN = f_even;
        public string F_EVEN_NOTE = f_even_note;
        public string F__UPD = f__upd;

        public string F_MARL = f_marl;
        public string F_MARL_DATE = f_marl_date;
        public string F_MARL_PLAC = f_marl_plac;
        public string F_MARL_NOTE = f_marl_note;

        public string F_DIV = f_div;
        public string F_DIV_DATE = f_div_date;
        public string F_DIV_PLAC = f_div_plac;
        public string F_DIV_NOTE = f_div_note;

        public string F_ENGA = f_enga;
        public string F_ENGA_DATE = f_enga_date;
        public string F_ENGA_PLAC = f_enga_plac;
        public string F_ENGA_NOTE = f_enga_note;

        public string F_ANUL = f_anul;
        public string F_ANUL_DATE = f_anul_date;
        public string F_ANUL_PLAC = f_anul_plac;
        public string F_ANUL_NOTE = f_anul_note;
    }



    public class Pe(
        string aa_i_index
            //, string i_rin
            //, string i__uid
            , string i__upd
            , string i_fullname
            , string i_name_givn
            , string i_name_nick
            , string i_name_surn
            , string i_name_marn
            , string i_name_nsfx
            , string i_name_npfx
            , string i_name__for
            , string i_sex
            , string i_birt
            //, string i_birt_uid
            //, string i_birt_rin
            , string i_birt_date
            , string i_birt_plac
            , string i_birt_note
            , string i_deat
            //, string i_deat_uid
            //, string i_deat_rin
            , string i_deat_date      //     20
            , string i_deat_plac
            , string i_deat_age
            , string i_deat_caus
            , string i_deat_note
            //, string i_deat_rin
            , string i_buri
            , string i_buri_plac
            , string i_buri_date
            , string i_fams
            , string i_famc
            , string i_famc_pedi      //     30
                                      //, string f_husb
                                      //, string f_wife
                                      //, string f_chil
            , string i_marr
            , string i_husb
            , string i_wife
            , string i_marr_date
            , string i_marr_plac
            , string i_marr_note
            //, string i_marr_uid
            //, string i_marr_rin
            , string i_div          //     40
            , string i_div_date
            , string i_div_plac
            , string i_occu
            , string i_occu_plac
            , string i_occu_date
            , string i_occu_age

            , string i_cens
            , string i_cens_plac
            //, string i_cens_date
            //, string i_cens_age

            , string i_emig
            , string i_emig_plac

            , string i_even
            , string i_even_date      //     50
            , string i_even_note
            , string i_even_age
            , string i_even_type
            , string i_even_plac
            //, string i_even_uid
            //, string i_even_rin
            , string i_note
            , string i_conc
            , string i_reli
            , string i_conf
            , string i_conf_date
            //, string i_conc_plac

            , string i_resi   // Residence
            , string i_resi_date
            , string i_resi_age
            , string i_resi_addr
            , string i_resi_phon
            , string i_email

            , string i_sour
            , string i_sour_page      //     60
            , string i_sour_quay
            , string i_sour_even
            , string i_sour_qual
            , string i_sour_data
            //, string i_note
            , string i_note_conc
            , string i_date_time
            , string i_prin
            //, string i_nati

            , string i_obje
            //, string i_obje_form
            , string i_obje_file
            , string i_obje_titl
            , string i_obje_note
            //, string i_obje__prim
            //, string i_obje__cutout
            //, string i_obje__parentrin
            //, string i_obje__personalphoto
            //, string i_obje__photo_rin
            //, string i_obje__position
            , string i_obje__dat
            , string i_obje__alb
    //, string i_obje__alb
    // 70

    )
    {
        // For the sake of simplicity I kept the variables public, it's best advice to add properties. 
        public string AA_I_INDEX = aa_i_index;         // 0
                                                       //public string I_RIN;          // 1
                                                       //public string I__UID;         // 1
        public string I_UPD = i__upd;         // 1
        public string I_PRIN = i_prin;         // 1

        public string I_NAME = i_fullname;         // 1
        public string I_NAME_GIVN = i_name_givn;
        public string I_NAME_NICK = i_name_nick;
        public string I_NAME_SURN = i_name_surn;
        public string I_NAME_MARNM = i_name_marn;
        public string I_NAME_NSFX = i_name_nsfx;
        public string I_NAME_NPFX = i_name_npfx;
        public string I_NAME__FOR = i_name__for;

        public string I_SEX = i_sex;

        public string I_BIRT = i_birt;
        //public string I_BIRT_UID;
        //public string I_BIRT_RIN;
        public string I_BIRT_DATE = i_birt_date;
        public string I_BIRT_PLAC = i_birt_plac;
        public string I_BIRT_NOTE = i_birt_note;

        public string I_DEAT = i_deat;
        //public string I_DEAT_UID;
        //public string I_DEAT_RIN;
        public string I_DEAT_DATE = i_deat_date;
        public string I_DEAT_PLAC = i_deat_plac;
        public string I_DEAT_AGE = i_deat_age;
        public string I_DEAT_CAUS = i_deat_caus;
        public string I_DEAT_NOTE = i_deat_note;
        //public string I_DEAT_RIN;      

        public string I_BURI = i_buri;
        public string I_BURI_PLAC = i_buri_plac;
        public string I_BURI_DATE = i_buri_date;

        public string I_FAMS = i_fams;
        public string I_FAMC = i_famc;
        public string I_FAMC_PEDI = i_famc_pedi;
        //public string F_CHIL;      

        public string I_EMIG = i_emig;
        public string I_EMIG_PLAC = i_emig_plac;

        public string I_OCCU = i_occu;
        public string I_OCCU_PLAC = i_occu_plac;
        public string I_OCCU_DATE = i_occu_date;
        public string I_OCCU_AGE = i_occu_age;

        public string I_CENS = i_cens;
        public string I_CENS_PLAC = i_cens_plac;
        //public string I_CENS_DATE;      
        //public string I_CENS_AGE;      

        public string I_EVEN = i_even;
        public string I_EVEN_DATE = i_even_date;
        public string I_EVEN_NOTE = i_even_note;
        public string I_EVEN_AGE = i_even_age;
        public string I_EVEN_TYPE = i_even_type;
        public string I_EVEN_PLAC = i_even_plac;
        //public string I_EVEN_UID;
        //public string I_EVEN_RIN;

        public string I_SOUR_PAGE = i_sour_page;
        public string I_SOUR_QUAY = i_sour_quay;
        public string I_SOUR_QUAL = i_sour_qual;
        public string I_SOUR_DATA = i_sour_data;
        public string I_SOUR_EVEN = i_sour_even;


        public string I_MARR = i_marr;
        public string I_HUSB = i_husb;
        public string I_WIFE = i_wife;
        public string I_MARR_PLAC = i_marr_plac;
        public string I_MARR_NOTE = i_marr_note;
        public string I_MARR_DATE = i_marr_date;
        //public string I_MARR_UID;
        //public string I_MARR_RIN;

        public string I_DIV = i_div;             //divorce
        public string I_DIV_PLAC = i_div_plac;
        public string I_DIV_DATE = i_div_date;

        public string I_SOUR = i_sour;
        public string I_NOTE = i_note;
        public string I_NOTE_CONC = i_note_conc;
        public string I_CONC = i_conc;
        public string I_DATE_TIME = i_date_time;
        public string I_RELI = i_reli;
        public string I_CONF = i_conf;
        public string I_CONF_DATE = i_conf_date;
        public string I_CONF_PLAC = i_conf;
        public string I_RESI = i_resi;
        public string I_RESI_ADDR = i_resi_addr;
        public string I_RESI_DATE = i_resi_date;
        public string I_RESI_AGE = i_resi_age;
        public string I_RESI_PHON = i_resi_phon;
        public string I_EMAIL = i_email;
        //public string I_NATI;
        public string I_OBJE = i_obje;
        //public string I_OBJE_FORM;
        public string I_OBJE_FILE = i_obje_file;
        public string I_OBJE_TITL = i_obje_titl;
        public string I_OBJE_NOTE = i_obje_note;
        //public string I_OBJE__PRI;
        //public string I_OBJE__CUT;
        //public string I_OBJE__PAR;
        //public string I_OBJE__PER;
        //public string I_OBJE__PHO;
        //public string I_OBJE__POS;
        public string I_OBJE__DAT = i_obje__dat;
        public string I_OBJE__ALB = i_obje__alb;
    }

    public class Event(
    int aa_ev_index
        , string ev_day
        , string ev_month
        , string ev_year
        , string ev_date_val
        , string ev_date
        , string ev_kind
        , string ev_dio
        , string ev_cb
        , string ev_place
        , string ev_p_index
        , string ev_sex
        , string ev_p_line

        )
    {
        public int AA_EV_INDEX = aa_ev_index;
        public string EV_DAY = ev_day;
        public string EV_MONTH = ev_month;
        public string EV_YEAR = ev_year;
        public string EV_DATE_VAL = ev_date_val;
        public string EV_DATE = ev_date;
        public string EV_KIND = ev_kind;
        public string EV_DIO = ev_dio;
        public string EV_CB = ev_cb;
        public string EV_PLACE = ev_place;
        public string EV_P_INDEX = ev_p_index;
        public string EV_SEX = ev_sex;
        public string EV_P_LINE = ev_p_line;
    }

    public class Info(
    string aa_e_index
        , string e_text
        , string e_hint
        //, string a_upd
        //, string a_desc
        )
    {
        public string AA_E_INDEX = aa_e_index;
        public string E_TEXT = e_text;
        //public string A__UPD;      
        public string E_HINT = e_hint;
    }



    public class Note(
    string aa_n_index
        , string n_rin
        , string n_prin
        , string n_conc
        )
    {
        public string AA_N_INDEX = aa_n_index;
        public string N_RIN = n_rin;
        public string N_PRIN = n_prin;
        public string N_CONC = n_conc;
    }


    public class Album(
    string aa_a_index
        , string a_rin
        , string a_titl
        , string a_upd
        , string a_desc
        )
    {
        public string AA_A_INDEX = aa_a_index;
        public string A_TITL = a_titl;
        public string A__UPD = a_upd;
        public string A_RIN = a_rin;
        public string A_DESC = a_desc;
    }

    //public string Blank(string blank)
    //{
    //    blank = @"'"; //HEAD", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
    //    blank = blank.Replace("'", @"""");
    //    blank = blank.Replace(@"\", "");
    //    return blank;
    //}

    public class PersLine(
    string aa_p_index
        , string pers_text
        , string pers_hint
        //, string a_upd
        //, string a_desc
        )
    {
        public string AA_P_INDEX = aa_p_index;
        public string PERS_TEXT = pers_text;
        //public string A__UPD;      
        public string PERS_HINT = pers_hint;
    }

    public class Source(
            string aa_s_index
                //, string s_rin
                //, string s__uid
                , string s_sour
                , string s_auth
                , string s_titl
                , string s_publ
                , string s_text
                , string s_text_conc
                , string s_sour_conc
                , string s__type
                , string s__medi
                )
    {
        // SOUR
        public string AA_S_INDEX = aa_s_index;
        //public string S_RIN;
        //public string S__UID;
        public string S_SOUR = s_sour;
        public string S_AUTH = s_auth;
        public string S_TITL = s_titl;
        public string S_PUBL = s_publ;
        public string S_TEXT = s_text;
        public string S_TEXT_CONC = s_text_conc;
        public string S__TYP = s__type;
        public string S__MED = s__medi;

        public string S_SOUR_CONC = s_sour_conc;
    }

    public class Updates(
    string aa_u_index
        , string u_text
        , string u_hint
        //, string a_upd
        //, string a_desc
        )
    {
        public string AA_U_INDEX = aa_u_index;
        public string U_TEXT = u_text;
        //public string A__UPD;      
        public string U_HINT = u_hint;
    }
}




