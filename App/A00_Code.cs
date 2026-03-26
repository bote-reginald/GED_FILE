// File:A00_Code.cs
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Media;
//using System.Numerics;
//using System.Runtime.Intrinsics.X86;
using System.Text;
//using System.Xml.Linq;
//using static System.Runtime.InteropServices.JavaScript.JSType;

class A00_Code
{
    //private static readonly List<Info> _info_list = [];
    private static readonly List<Pe> pelist = [];
    private static readonly List<Fam> famlist = [];
    private static readonly List<Event> eventList = [];
    private static readonly List<Info> _info_list = [];
    private static readonly List<Updates> updateslist = [];
    private static readonly List<Note> notelist = [];
    private static readonly List<Source> _source_list = [];
    private static readonly List<PersLine> persLinelist = [];
    private static readonly List<Album> albumlist = [];
    private static Info _info_new = new("", "", "");
    private static Event _event_new = new(0, "", "", "", "", "", "", "", "", "", "", "", "");
    private static string _info_text = "";
    //private static int _count;
    private static bool bool_nbsp;
    private static bool boolSaveSingleEntry;


    private static int _nextGoalOfLines;
    private static readonly int _slow = 0;
    private static readonly string _slow_string = "";
    //private /*static readonly*/ string _line_string = "";
    //private /*static readonly */string sourceString = "";
    //private /*static readonly */string updateString = "";
    //private /*static readonly */string entryText = "";
    //private string keyPrevious = "";
    //private string secondblankOrEnd = "";

    public string blank = "";
    private static string valueAdd = "";
    /*private static*/
    //string v0 = "";
    private static string v1 = "";
    private static string v2 = "";
    //private static string key = "";
    private static string value = "";
    private static int lastPeListIndex_DONE;
    private static string ht = " # ";
    private static string gedheadText = "";
    private static string unknownKeyText = "unknown";
    private static readonly string _newline = Environment.NewLine;
    private static bool boolCheckUnklar;
    private static readonly string _separator = ";";
    private static bool boolChecknbsp;
    private static int unknownKeyCount;
    private static bool bool_sex_u;
    private static int lastPeListIndex;

    //string writePelistCounting = "";
    //string writeFamlistCounting = "";
    //string writeSourcelistCounting = "";
    //string writeAlbumlistCounting = "";
    //string writeNotelistCounting = "";
    //DateTime _start_time_global;
    //string _deatText = "";
    //string persLineText = "";
    //string _famsText = "";
    //string _date = "";
    //string _dateString = "";
    //string _deathdateString = "";
    //string _place = "";
    //string _dio = "";
    //string _cb = "";
    //string _date_val = "";
    //string _month = "";
    //string _year = "";
    //string _kind = "";
    //string _day = "";
    //private static string[] _dateColl;
    private static readonly string _start_time_global = DateTime.Now.ToString();

    static async Task Main()
    {
        //var p = new A00_Code();
        string _path = "C:/DB/";
        string _read_file = "__ged_IN";
        string _extension = ".ged";
        DateTime _start_time;
        //DateTime _start_time_global;
        string _out_file = "C:/DB/__ged_IN-autosave.ged";
        int _nextGoalOfLines = 1000000 - 1;
        string _info_text;
        string v0 = "";
        /*private*/
        string key = "";
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
        string persLineText;
        string persLineHint;

        string _dateString;
        string _line_string = "";
        blank = "";
        List<PersLine> persLineList = [];



        List<string> _all_lines = await Task.Run(() => A01_Read_Input(_path, _read_file, _extension));


        try
        {
            _start_time = DateTime.Now;
            // run processing on background thread and get processed lines


            StreamWriter _stream_Writer = new(File.Open(_out_file, FileMode.Create), Encoding.UTF8);

            _count = -1;

            _info_text = "Output";
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
                    _info_text = "Step_1800:; " + DateTime.Now + " > " + _count.ToString() + ": _start was ;" + _start_time + ";" + " for autosave";
                    Xwrite("Step_9905", true, _info_text);

                    _nextGoalOfLines += 500000;
                }
            }
            //Debugger.Break(); return "";
            //_stream_Writer.Xwrite(_all_text);
            //Thread.Sleep(2000);

            _stream_Writer.Close();
        }
        catch (Exception ex)
        {
            _info_text = "Step_9900:; " + DateTime.Now + " > Error: " + ex.Message;
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
            _info_list.Add(_info_new);
            Debugger.Break();
        }

        _count = 0;
        _nextGoalOfLines = 1000000;
        foreach (var _line in _all_lines)
        {
            if (_count > _nextGoalOfLines)
            {
                _count += 1;
                DoReplace_stuff(_line, out _line_string);
                Xwrite("Step_2200", true, _count + " DoReplace_stuff > " + _line_string);

                _nextGoalOfLines += 500000;


        _first = _line_string.Substring(0, 1).ToString();


        if (_line_string.Contains("DAH+"))
            sourceString = "_DAH_85244";

        if (_line_string.Contains("Jaubert Family Tree"))
            sourceString = "Sylvie";

        if (_line_string.Contains("Family Tree Builder"))
            sourceString = "FTP-Export";


        if (_line_string.Contains("UPD"))  // for header
        {
            updateString = GetUpdateString(_line_string);
        }



        if (_first != "0")
        {
            entryText += keyPrevious + ";" + _line_string + _newline;
        }


        if (_first == "0")
        {
            // Works
            //Console.WriteLine("keyPrevious {0}, entryText {1}, updateString {2}, sourceString {3}", 
            //    keyPrevious, entryText, updateString, sourceString);

            if (_slow > 8 && boolSaveSingleEntry == false)
            {
                _info_text = _slow_string + ";NO;no output for each single entry to _GED_OUT folder";
                Xwrite("Step_8900", true, _line_string);

                boolSaveSingleEntry = true;
            }
            else
            {


                if (_slow < 2 && keyPrevious != null && keyPrevious != "")
                {
                    SaveEntry(keyPrevious, entryText, updateString, sourceString);
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

                key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                key = key.Replace("@", "");
                keyPrevious = key;

                Note noteNew = new(keyPrevious, blank, blank, blank);
                notelist.Add(noteNew);
                //Console.WriteLine("adding FAM = {0}", keyPrevious);
            }

            // ALBUM
            if (_line_string.EndsWith("ALBUM"))
            {
                v0 = "A_";
                //Console.WriteLine("#### skipped 'ALBUM' = {0}", _line_string);

                key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                key = key.Replace("@", "");

                if (albumlist.FindIndex(item => item.AA_A_INDEX == key) > -1)
                {
                    key += "2";
                }

                keyPrevious = key;

                Album albumNew = new(keyPrevious, blank, blank, blank, blank);
                albumlist.Add(albumNew);
                //Console.WriteLine("adding ALBUM = {0}", keyPrevious);
            }

            if (_line_string.EndsWith("TRLR"))
            {
                v0 = "END_";
                //Console.WriteLine("___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
                _info_text = _start_time_global + "___________________________________________________start;" + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file";
                Console.WriteLine(_info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
            }

            // FAM
            if (_line_string.EndsWith("FAM"))
            {
                v0 = "F_";
                key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                key = key.Replace("@", "");
                keyPrevious = key;

                Fam famNew = new(keyPrevious
                    , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank//  // 11//
                    , blank, blank, blank, blank, blank, blank, blank, blank, blank, blank//  // 21
                    , blank, blank, blank, blank, blank, blank, blank, blank, blank//,
                    );

                famlist.Add(famNew);
                //Console.WriteLine("adding FAM = {0}", keyPrevious);
            }

            if (_line_string.EndsWith("SOUR"))  // SOUR
            {
                v0 = "S_";
                key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
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

                key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
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
                pelist.Add(peNew);
                //_pers_text_coll_global.Clear();
                //Console.WriteLine("adding = {0}", keyPrevious);
            }
            else
            {
                unknownKeyCount += 1;
                keyPrevious = key;
                //lastPeListIndex_DONE = lastPeListIndex;
                //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                //pelist.Add(peNew);
                key = "unknownKeyCount" + unknownKeyCount.ToString();

            }
        }
        // End of:  if (_first == "0")

        int pelistIndex = pelist.FindIndex(item => item.AA_I_INDEX == keyPrevious);
        int lastPeListIndex = pelistIndex;
        //int lastPeListIndex_DONE;
        int famlistIndex = famlist.FindIndex(item => item.AA_F_INDEX == keyPrevious);
        int notelistIndex = notelist.FindIndex(item => item.AA_N_INDEX == keyPrevious);
        int sourcelistIndex = _source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious);
        int albumlistIndex = albumlist.FindIndex(item => item.AA_A_INDEX == keyPrevious);
        //pelist.Add(peNew);


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
                valueAdd = _line_string.Substring(2, _line_string.Length - 2);

            if (valueAdd == "ENGA") valueAdd = "verlobt";
            if (valueAdd == "MARL") valueAdd = "StAmt";

            //else { valueAdd}
            value += CleanText(valueAdd);

            valueAdd = CleanText(valueAdd);

            switch (v1)
            {
                // FAM
                case "F_HUSB": famlist[famlistIndex].F_HUSB = CleanID(valueAdd); break;
                case "F_WIFE": famlist[famlistIndex].F_WIFE = CleanID(valueAdd); break;
                case "F_RIN": /*famlist[famlistIndex].F_RIN = valueAdd;*/ break;
                case "F__UID": /*famlist[famlistIndex].F__UID = valueAdd;*/ break;
                case "F_CHIL": famlist[famlistIndex].F_CHIL += CleanID(valueAdd) + " # "; break;
                case "F__UPD": famlist[famlistIndex].F__UPD = valueAdd; break;
                case "F_MARR": famlist[famlistIndex].F_MARR = valueAdd; break;
                case "F_MARL": famlist[famlistIndex].F_MARL = valueAdd; break;  // Hochzeit Standesamt
                case "F_DIV": famlist[famlistIndex].F_DIV = valueAdd; break;  // Divorce
                case "F_ENGA": famlist[famlistIndex].F_ENGA = valueAdd; break; // Verlobung
                case "F_ANUL": famlist[famlistIndex].F_ANUL = valueAdd; break;
                case "F_EVEN": famlist[famlistIndex].F_EVEN = valueAdd; break;

                // SOURCE
                case "S_AUTH": _source_list[sourcelistIndex].S_AUTH = valueAdd; break;
                case "S_TITL": _source_list[sourcelistIndex].S_TITL = valueAdd; break;
                case "S_PUBL": _source_list[sourcelistIndex].S_PUBL = valueAdd; break;
                case "S_TEXT": _source_list[sourcelistIndex].S_TEXT = valueAdd; break;
                case "S__TYP": _source_list[sourcelistIndex].S__TYP = valueAdd; break;
                case "S__MED": _source_list[sourcelistIndex].S__MED = valueAdd; break;

                // ALBUM = Photos
                //case "S_AUTH": albumlist[albumlistIndex].S_AUTH = valueAdd; break;
                case "A_TITL": albumlist[albumlistIndex].A_TITL = valueAdd; break;
                case "A_DESC": albumlist[albumlistIndex].A_DESC = valueAdd; break;
                //case "S_TEXT": albumlist[albumlistIndex].S_TEXT = valueAdd; break;
                case "A__UPD": albumlist[albumlistIndex].A__UPD = valueAdd; break;
                case "A_RIN": /*albumlist[albumlistIndex].A_RIN = valueAdd;*/ break;


                // INDI
                case "I_NAME": pelist[pelistIndex].I_NAME = valueAdd; break;
                //case "I_NAME": pelist[pelistIndex].I_NAME = valueAdd; break;
                //case "I_NAME": pelist[pelistIndex].I_NAME = valueAdd; break;
                //case "I_NAME": pelist[pelistIndex].I_NAME = valueAdd; break;
                case "I_SEX":
                    pelist[pelistIndex].I_SEX = valueAdd;
                    //if (_slow > 0)
                    //{
                    //    if (bool_sex_u == false && valueAdd.Contains("U"))// || valueAdd.Contains("") || valueAdd.Contains(" "))
                    //    {
                    //        errortext = blank + "SEX contains U"
                    //            + blank + pelist[pelistIndex].I_SEX
                    //            + " verh. " + pelist[pelistIndex].I_NAME_MARNM
                    //            + blank + pelist[pelistIndex].I_NAME_SURN
                    //            + blank + pelist[pelistIndex].I_NAME_GIVN
                    //            + blank + pelist[pelistIndex].AA_I_INDEX
                    //            ;
                    //        Console.WriteLine(errortext);
                    //        AddError(_count.ToString(), "SEX contains U", errortext);
                    //    }
                    //}
                    //else
                    if (bool_sex_u == false)
                    {
                        _info_text = "Step_1900:; " + _slow_string + "; NO_0009;no check for *SEX contains U*";
                        Console.WriteLine(_info_text);
                        _info_new = new("INFO;", ";", A00_Code._info_text);

                        bool_sex_u = true;
                    }
                    break;
                case "I_BIRT": pelist[pelistIndex].I_BIRT = valueAdd; break;
                case "I_DEAT":
                    pelist[pelistIndex].I_DEAT = valueAdd;
                    //if (valueAdd == "DEAT Y")
                    //    pelist[pelistIndex].I_SEX += "d";
                    //else
                    //    pelist[pelistIndex].I_SEX += "a";

                    break;

                case "I_BURI": pelist[pelistIndex].I_BURI = valueAdd; break;
                case "I_FAMS": pelist[pelistIndex].I_FAMS += valueAdd + "-"/* + ht*/; break;
                case "I_FAMC": pelist[pelistIndex].I_FAMC += valueAdd + ht; break;


                case "I_RESI": pelist[pelistIndex].I_RESI = valueAdd; break;
                case "I_ADDR": pelist[pelistIndex].I_RESI = valueAdd; break;  // same like RESI ??
                case "I_CONF": pelist[pelistIndex].I_CONF = valueAdd; break;
                case "I_RELI": pelist[pelistIndex].I_RELI = valueAdd; break;
                case "I_OCCU": pelist[pelistIndex].I_OCCU = valueAdd; break;
                case "I_CENS": pelist[pelistIndex].I_CENS = valueAdd; break;
                case "I_NOTE": pelist[pelistIndex].I_NOTE = valueAdd; break;

                case "I_RIN": /*pelist[pelistIndex].I_RIN = valueAdd;*/ break;
                case "I__UID": /*pelist[pelistIndex].I__UID = valueAdd;*/ break;

                case "S_RIN": /*_source_list[sourcelistIndex].S_RIN = valueAdd;*/ break;
                case "S__UID": /*_source_list[sourcelistIndex].S__UID = valueAdd;*/ break;

                //case "I_RIN ": pelist[pelistIndex].I_RIN = valueAdd; break;
                //case "I__RIN": pelist[pelistIndex].I_RIN = valueAdd; break;
                //case "I_UID ": pelist[pelistIndex].I_UID = valueAdd; break;

                case "I__UPD": pelist[pelistIndex].I_UPD = valueAdd; break;
                case "I_CHAN": pelist[pelistIndex].I_UPD = "### Change instead UPD ### " + valueAdd; break;
                case "N_CONC": notelist[notelistIndex].N_CONC = valueAdd; break;
                case "N_PRIN": notelist[notelistIndex].N_PRIN = valueAdd; break;
                case "N_RIN": /*notelist[notelistIndex].N_RIN = valueAdd;*/ break;

                case "I_EVEN": pelist[pelistIndex].I_EVEN = valueAdd; break;
                case "I_EMIG": pelist[pelistIndex].I_EMIG = valueAdd; break;

                case "I_NATI": /*pelist[pelistIndex].I_NATI = valueAdd;*/ break;

                case "H_DATE": gedheadText += valueAdd; break;
                case "H_GEDC": gedheadText += valueAdd; break;
                case "H_CHAR": gedheadText += valueAdd; break;
                case "H_LANG": gedheadText += valueAdd; break;
                case "H_SOUR": gedheadText += valueAdd; break;
                case "H_DEST": gedheadText += valueAdd; break;
                case "H__PRO": /*gedheadText += valueAdd;*/ break;
                case "H__EXP": /*gedheadText += valueAdd;*/ break;
                case "H_FILE": gedheadText += valueAdd; break;

                case "I_SOUR": pelist[pelistIndex].I_SOUR = valueAdd; break;

                case "I_OBJE": pelist[pelistIndex].I_OBJE = valueAdd; break;

                //case "I_MARR": pelist[famlistIndex].I_MARR = valueAdd; break;
                //case "I_DIV ": pelist[famlistIndex].I_DIV = valueAdd; break;
                //case "I_NATI": pelist[pelistIndex].I_NATI = valueAdd; break;

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
                valueAdd =
                        //v0 + v1 + _separator + "-" + v2 + _separator + // without
                        _line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + _separator;

            valueAdd = CleanText(valueAdd);

            value += valueAdd;

            string v0v1v2 = v0 + v1 + "_" + v2;

            bool boolCheckGIVEN = false;

            switch (v0v1v2)
            {
                // FAM
                case "F_F_MARR_DATE": famlist[famlistIndex].F_MARR_DATE = valueAdd; break;
                case "F_F_MARR_PLAC": famlist[famlistIndex].F_MARR_PLAC = valueAdd; break;
                case "F_F_MARR_NOTE": valueAdd = valueAdd.Replace(",", "#"); famlist[famlistIndex].F_MARR_NOTE = valueAdd; break;
                case "F_F_MARR__UID": /*famlist[famlistIndex].F_MARR__UID = valueAdd;*/ break;
                case "F_F_MARR_RIN ": /*famlist[famlistIndex].F_MARR_RIN = valueAdd;*/ break;
                case "F_F_EVEN_TYPE": famlist[famlistIndex].F_EVEN_TYPE = valueAdd; break;
                case "F_F_EVEN_DATE": famlist[famlistIndex].F_EVEN_DATE = valueAdd; break;
                case "F_F_EVEN_PLAC": famlist[famlistIndex].F_EVEN_PLAC = valueAdd; break;
                case "F_F_EVEN__UID": /*famlist[famlistIndex].F_EVEN__UID = valueAdd;*/ break;
                case "F_F_EVEN_RIN ": /*famlist[famlistIndex].F_EVEN_RIN = valueAdd;*/ break;
                case "F_F_EVEN_NOTE": famlist[famlistIndex].F_EVEN_NOTE = valueAdd; break;
                // MARL
                case "F_F_MARL_DATE": famlist[famlistIndex].F_MARL_DATE = valueAdd; break;
                case "F_F_MARL_PLAC": famlist[famlistIndex].F_MARL_PLAC = valueAdd; break;
                case "F_F_MARL_NOTE": famlist[famlistIndex].F_MARL_NOTE = valueAdd; break;
                // DIV
                case "F_F_DIV_DATE": famlist[famlistIndex].F_DIV_DATE = valueAdd; break;
                case "F_F_DIV_PLAC": famlist[famlistIndex].F_DIV_PLAC = valueAdd; break;
                case "F_F_DIV_NOTE": famlist[famlistIndex].F_DIV_NOTE = valueAdd; break;
                // ENGA
                case "F_F_ENGA_DATE": famlist[famlistIndex].F_ENGA_DATE = valueAdd; break;
                case "F_F_ENGA_PLAC": famlist[famlistIndex].F_ENGA_PLAC = valueAdd; break;
                case "F_F_ENGA_NOTE": famlist[famlistIndex].F_ENGA_NOTE = valueAdd; break;
                // ANUL
                case "F_F_ANUL_DATE": famlist[famlistIndex].F_ANUL_DATE = valueAdd; break;
                case "F_F_ANUL_PLAC": famlist[famlistIndex].F_ANUL_PLAC = valueAdd; break;
                case "F_F_ANUL_NOTE": famlist[famlistIndex].F_ANUL_NOTE = valueAdd; break;

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
                    pelist[pelistIndex].I_BIRT_DATE = valueAdd;
                    break;
                case "I_I_NAME_GIVN":
                    pelist[pelistIndex].I_NAME_GIVN = valueAdd;
                    pelist[pelistIndex].I_NAME_GIVN = valueAdd;

                    if (boolCheckGIVEN == false)
                    {
                        boolCheckGIVEN = true;
                        //if (_slow < 2)
                        //{
                        //    if (valueAdd.Contains("doppelt") || valueAdd.Contains("ein zwei") || valueAdd.Contains("die selbe"))
                        //    {
                        //        if (DontCheck_Given(pelist[pelistIndex].AA_I_INDEX) == false)
                        //        {
                        //            errortext = separator + "GIVEN contains ..."
                        //                + separator + pelist[pelistIndex].I_NAME_NSFX
                        //                + "verh.;" + pelist[pelistIndex].I_NAME_MARNM
                        //                + separator + pelist[pelistIndex].I_NAME_SURN
                        //                + separator + pelist[pelistIndex].I_NAME_GIVN
                        //                + separator + pelist[pelistIndex].AA_I_INDEX
                        //                ;
                        //            Console.WriteLine(errortext);
                        //            AddError(_count.ToString(), "CHECKING", errortext);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    _info_text = "    _slow is ;" + _slow + "; NO_0008;CheckGiven: no output for each single entry";
                        //    Console.WriteLine(_info_text);
                        //    _info_new = new("INFO;", ";", A00_Code._info_text);

                        //    //boolCheckGIVEN = true;
                        //}
                    }
                    break;
                case "I_I_NAME_NICK": pelist[pelistIndex].I_NAME_NICK = valueAdd; break;
                case "I_I_NAME__MAR": pelist[pelistIndex].I_NAME_MARNM = valueAdd; break;
                case "I_I_NAME_SURN": pelist[pelistIndex].I_NAME_SURN = valueAdd; break;

                case "I_I_NAME_NPFX": pelist[pelistIndex].I_NAME_NPFX = valueAdd; break;
                case "I_I_NAME__FOR": pelist[pelistIndex].I_NAME__FOR = valueAdd; break;

                case "I_I_BIRT_PLAC": pelist[pelistIndex].I_BIRT_PLAC = valueAdd; break;
                case "I_I_BIRT_RIN ": /*pelist[pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                case "I_I_BIRT__UID": /*pelist[pelistIndex].I_BIRT_UID = valueAdd;*/ break;
                case "I_I_BIRT_NOTE": valueAdd = valueAdd.Replace(";", "#"); pelist[pelistIndex].I_BIRT_NOTE = valueAdd; break;

                case "I_I_DEAT_DATE": pelist[pelistIndex].I_DEAT_DATE = valueAdd; break;
                case "I_I_DEAT_PLAC": pelist[pelistIndex].I_DEAT_PLAC = valueAdd; break;
                case "I_I_DEAT_CAUS": pelist[pelistIndex].I_DEAT_CAUS = valueAdd; break;
                case "I_I_DEAT_AGE ": pelist[pelistIndex].I_DEAT_AGE = valueAdd; break;
                case "I_I_DEAT__UID": /*pelist[pelistIndex].I_DEAT_UID = valueAdd;*/ break;
                case "I_I_DEAT_RIN ": /*pelist[pelistIndex].I_DEAT_RIN = valueAdd;*/ break;
                case "I_I_DEAT_NOTE": valueAdd = valueAdd.Replace(";", "#"); pelist[pelistIndex].I_DEAT_NOTE = valueAdd; break;
                case "I_I_BURI_DATE": pelist[pelistIndex].I_BURI_DATE = valueAdd; break;
                case "I_I_BURI_PLAC": pelist[pelistIndex].I_BURI_PLAC = valueAdd; break;
                case "I_I_BURI_RIN ": /*pelist[pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                case "I_I_BURI__UID": /*pelist[pelistIndex].I_BIRT_UID = valueAdd;*/ break;

                //case "I_I_DIV_DATE": pelist[pelistIndex].I_DIV_DATE = valueAdd; break;
                //case "I_I_DIV_PLAC": pelist[pelistIndex].I_DIV_PLAC = valueAdd; break;
                case "I_I_RESI_EMAI": pelist[pelistIndex].I_EMAIL = valueAdd; break;
                case "I_I_BAPM_PLAC": /*pelist[pelistIndex].I_BAPM_PLAC = valueAdd;*/ break;
                case "I_I_BAPM_DATE": /*pelist[pelistIndex].I_BAPM_DATE = valueAdd;*/ break;
                case "I_I_CONF_PLAC": pelist[pelistIndex].I_CONF_PLAC = valueAdd; break;
                case "I_I_CONF_DATE": pelist[pelistIndex].I_CONF_DATE = valueAdd; break;
                case "I_I_OCCU_PLAC": pelist[pelistIndex].I_OCCU_PLAC = valueAdd; break;
                case "I_I_OCCU_DATE": pelist[pelistIndex].I_OCCU_DATE = valueAdd; break;
                case "I_I_OCCU_AGE ": pelist[pelistIndex].I_OCCU_AGE = valueAdd; break;

                case "I_I_CENS_PLAC": pelist[pelistIndex].I_CENS_PLAC = valueAdd; break;
                //case "I_I_CENS_DATE": pelist[pelistIndex].I_CENS_DATE = valueAdd; break;
                //case "I_I_OCCU_AGE ": pelist[pelistIndex].I_OCCU_AGE = valueAdd; break;
                //case "I_I_RESI_EMAI": pelist[pelistIndex].I_EMAIL = valueAdd; break;

                case "I_I_RESI_DATE": pelist[pelistIndex].I_RESI_DATE = valueAdd; break;
                case "I_I_RESI_AGE ": pelist[pelistIndex].I_RESI_AGE = valueAdd; break;

                case "I_I_ADDR_CONT": pelist[pelistIndex].I_RESI_ADDR = "Adress available"; break; // same like RESI ?
                case "I_I_RESI_ADDR": pelist[pelistIndex].I_RESI_ADDR = valueAdd; break;

                case "I_I_RESI_PLAC": pelist[pelistIndex].I_RESI_ADDR = " ### PLACE instead Address?:" + valueAdd; break;
                case "I_I_RESI_PHON": pelist[pelistIndex].I_RESI_PHON = valueAdd; break;
                case "I_I_RESI_FAX ": /*pelist[pelistIndex].I_RESI_FAX = valueAdd;*/ break;
                case "I_I_RESI_NOTE": /*pelist[pelistIndex].I_RESI_NOTE = valueAdd;*/ break;
                case "I_I_FAMC_PEDI": pelist[pelistIndex].I_FAMC_PEDI = valueAdd; break;

                case "I_I_EVEN_DATE": pelist[pelistIndex].I_EVEN_DATE = valueAdd; break;
                case "I_I_EVEN_NOTE": pelist[pelistIndex].I_EVEN_NOTE = valueAdd; break;
                case "I_I_EVEN_AGE ": pelist[pelistIndex].I_EVEN_AGE = valueAdd; break;

                case "I_I_EVEN__UID": /*pelist[pelistIndex].I_EVEN_UID = valueAdd;*/ break;
                case "I_I_EVEN_RIN ": /*pelist[pelistIndex].I_EVEN_RIN = valueAdd;*/ break;
                case "I_I_EVEN_TYPE": pelist[pelistIndex].I_EVEN_TYPE = valueAdd; break;
                case "I_I_EVEN_PLAC": pelist[pelistIndex].I_EVEN_PLAC = valueAdd; break;

                case "I_I_EMIG_PLAC": pelist[pelistIndex].I_EMIG_PLAC = valueAdd; break;

                case "I_I_SOUR_DATA": pelist[pelistIndex].I_SOUR_DATA = valueAdd; break;
                case "I_I_SOUR_EVEN": pelist[pelistIndex].I_SOUR_EVEN = valueAdd; break;
                case "I_I_SOUR_PAGE": pelist[pelistIndex].I_SOUR_PAGE = valueAdd; break;
                case "I_I_SOUR_QUAL": pelist[pelistIndex].I_SOUR_QUAL = valueAdd; break;
                case "I_I_SOUR_QUAY": pelist[pelistIndex].I_SOUR_QUAY = valueAdd; break;
                case "I_I_SOUR_RIN ": /*pelist[pelistIndex].I_BIRT_RIN = valueAdd;*/ break;
                case "I_I_SOUR__UID": /*pelist[pelistIndex].I_BIRT_UID = valueAdd;*/ break;


                case "I_I_OBJE_FORM": /*pelist[pelistIndex].I_OBJE_FORM = valueAdd;*/ break;
                case "I_I_OBJE_FILE": pelist[pelistIndex].I_OBJE_FILE = valueAdd; break;
                case "I_I_OBJE_TITL": pelist[pelistIndex].I_OBJE_TITL = valueAdd; break;
                case "I_I_OBJE_NOTE": pelist[pelistIndex].I_OBJE_NOTE = valueAdd; break;
                case "I_I_OBJE__PRI": /*pelist[pelistIndex].I_OBJE__PRI = valueAdd;*/ break;
                case "I_I_OBJE__CUT": /*pelist[pelistIndex].I_OBJE__CUT = valueAdd;*/ break;
                case "I_I_OBJE__PAR": /*pelist[pelistIndex].I_OBJE__PAR = valueAdd;*/ break;
                case "I_I_OBJE__PER": /*pelist[pelistIndex].I_OBJE__PER = valueAdd;*/ break;
                case "I_I_OBJE__PHO": /*pelist[pelistIndex].I_OBJE__PHO = valueAdd;*/ break;
                case "I_I_OBJE__POS": /*pelist[pelistIndex].I_OBJE__POS = valueAdd;*/ break;
                case "I_I_OBJE__DAT": pelist[pelistIndex].I_OBJE__DAT = valueAdd; break;
                case "I_I_OBJE__ALB": pelist[pelistIndex].I_OBJE__ALB = valueAdd; break;
                case "I_I_OBJE__FIL": /*pelist[pelistIndex].I_OBJE__FIL = valueAdd;*/ break;  // FILESIZE
                case "I_I_OBJE__PLA": /*pelist[pelistIndex].I_OBJE__PLA = valueAdd;*/ break;  // PLACE



                case "I_I_DATE_TIME": pelist[pelistIndex].I_DATE_TIME = valueAdd; break;
                case "I_I_CHAN_DATE": pelist[pelistIndex].I_DATE_TIME = "### DATE: CHAN instead D+T: " + valueAdd; break;
                case "I_I_NOTE_CONC": pelist[pelistIndex].I_NOTE_CONC = valueAdd; break;
                //case "I_I_FILE": gedheadText += valueAdd; break;

                case "I_I_NAME_NSFX":
                    pelist[pelistIndex].I_NAME_NSFX = valueAdd;

                    //if (_slow > 0)
                    //{
                    //    if (valueAdd.Contains("unklar") || valueAdd.Contains("Klärung") || valueAdd.Contains("lebt?"))
                    //    {
                    //        if (DontCheck_NSFX(pelist[pelistIndex].AA_I_INDEX) == false)
                    //        {
                    //            _info_text = blank //+ "____________________"
                    //            + blank + pelist[pelistIndex].I_NAME_NSFX
                    //            + " verh. " + pelist[pelistIndex].I_NAME_MARNM
                    //            + blank + pelist[pelistIndex].I_NAME_SURN
                    //            + blank + pelist[pelistIndex].I_NAME_GIVN
                    //            //+ " born: " + pelist[pelistIndex].I_BIRT_DATE  // these Values are added later
                    //            //+ " marr: " + pelist[pelistIndex].I_MARR_DATE
                    //            //+ " died: " + pelist[pelistIndex].I_DEAT_DATE
                    //            + blank + pelist[pelistIndex].AA_I_INDEX
                    //            ;
                    //            Console.WriteLine(_info_text);
                    //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_text);
                    //        }
                    //    }
                    //}
                    break;

                //if (pelist[pelistIndex].I_BIRT_DATE == "")
                //{
                //    _info_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + pelist[pelistIndex].AA_I_INDEX;
                //    Console.WriteLine(_info_text);
                //    AddError("1231232", "INFO", _info_text);

                //    pelist[pelistIndex].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
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
            Xwrite("Step_2202", true, _count + _newline + " > DoReplace_stuff ");


            if (_slow < 2 && boolCheckUnklar == false)
            {
                _info_text = "Step_1900:; " + DateTime.Now + _slow_string + "; NO_0007;for unklar / Klärung / lebt";
                Console.WriteLine(_info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);


                boolCheckUnklar = true;
            }

            //if (_slow < x && lastPeListIndex_DONE > 0)  // to avoid crashes
            //{
            //    //lastPeListIndex_DONE = lastPeListIndex;

            //    string valueCheck = pelist[lastPeListIndex_DONE].I_NAME_NSFX;
            //    if (valueCheck.Contains("unklar") || valueCheck.Contains("Klärung") || valueCheck.Contains("lebt?"))
            //    {
            //        if (DontCheck_NSFX(pelist[lastPeListIndex].AA_I_INDI) == false)
            //        {
            //            errortext = blank //+ "____________________"
            //            + blank + pelist[lastPeListIndex_DONE].I_NAME_NSFX
            //            + " verh. " + pelist[lastPeListIndex_DONE].I_NAME_MARNM
            //            + blank + pelist[lastPeListIndex_DONE].I_NAME_SURN
            //            + blank + pelist[lastPeListIndex_DONE].I_NAME_GIVN
            //            + " born: " + pelist[lastPeListIndex_DONE].I_BIRT_DATE
            //            + " born_at: " + pelist[lastPeListIndex_DONE].I_BIRT_PLAC
            //            + " marr: " + pelist[lastPeListIndex_DONE].I_MARR_DATE
            //            + " died: " + pelist[lastPeListIndex_DONE].I_DEAT_DATE
            //            + " " + pelist[lastPeListIndex_DONE].AA_I_INDI
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
        }
        // end of : if (_first == "2")
        //#endregion _first = 2

        //lastPeListIndex_DONE = lastPeListIndex;

        if (_slow < 2 && boolChecknbsp == false)
        {

            _info_text = "    _slow is ;" + _slow_string + "; NO_0006;for <p>&nbsp;";
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", A00_Code._info_text);
            boolChecknbsp = true;

            if (_slow > 12 && _line_string.Contains("<p>&nbsp;"))
            {
                _info_new = new(_count.ToString(), "line contains <p>&nbsp;", _line_string);
                _info_list.Add(_info_new);

                _line_string = _line_string.Replace("&nbsp;", " ");
                _line_string = _line_string.Replace("<p>&nbsp;</p>" + _newline, " ");
            }
        }

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


        //if (pelistIndex >= 0 && pelist[pelistIndex].I_FAMS != "")
        //    SplitColl(pelist[pelistIndex].I_FAMS, ';');




        updateString = "";  // here !!




        //end while (streamReader



        // writing gedheadText
        Console.WriteLine(_newline + _newline + gedheadText + _newline);
        _info_new = new("INFO;", ";", A00_Code._info_text);
        _info_list.Add(_info_new);

        if (pelist.Count > 0)
        {
            _info_text = "PERS-Count   ;" + pelist.Count;
            Console.WriteLine(_newline + _info_text);
            _info_new = new("INFO;", ";", A00_Code._info_text);
            _info_list.Add(_info_new);

            if (famlist.Count > 0)
            {
                _info_text = "FAM-Count    ;" + famlist.Count;
                Console.WriteLine(_newline + _info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);
            }
            if (notelist.Count > 0)
            {
                _info_text = "NOTE-Count   ;" + notelist.Count;
                //+ _newline;
                Console.WriteLine(_newline + _info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);
            }
            if (albumlist.Count > 0)
            {
                _info_text = "ALBUM-Count  ;" + albumlist.Count;
                //+ _newline;
                Console.WriteLine(_newline + _info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);
            }
            if (_source_list.Count > 0)
            {
                _info_text = "SOURCE-Count ;" + _source_list.Count;
                Console.WriteLine(_newline + _info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);
            }

            bool countfor = true;
            if (countfor == true)  // Count Section
            {
                string isEmptyString = " ";
                _info_text = "";
                _info_text += ";5555555;Count for ;TOTAL      ;" + pelist.Count(a => a.I_SEX != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_BIRT_DATE;" + pelist.Count(a => a.I_BIRT_DATE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_BIRT_PLAC;" + pelist.Count(a => a.I_BIRT_PLAC != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_DEAT_DATE;" + pelist.Count(a => a.I_DEAT_DATE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_DEAT_PLAC;" + pelist.Count(a => a.I_DEAT_PLAC != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_BURI_PLAC;" + pelist.Count(a => a.I_BURI_PLAC != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_FAMS     ;" + pelist.Count(a => a.I_FAMS != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;F_HUSB     ;" + famlist.Count(a => a.F_HUSB != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;F_WIFE     ;" + famlist.Count(a => a.F_WIFE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;F_MARR_DATE;" + famlist.Count(a => a.F_MARR_DATE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;F_MARR_PLAC;" + famlist.Count(a => a.F_MARR_PLAC != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;F_MARR_NOTE;" + famlist.Count(a => a.F_MARR_NOTE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_BIRT_NOTE;" + pelist.Count(a => a.I_BIRT_NOTE != isEmptyString) + _newline; ;
                _info_text += ";5555555;Count for ;I_DEAT_NOTE;" + pelist.Count(a => a.I_DEAT_NOTE != isEmptyString) + _newline; ;

                Console.WriteLine(_newline + _newline + _info_text + _newline);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);


            }


            //streamReader.Close();
            // end of reading


            _info_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";begin of Populate PersLineList";
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", A00_Code._info_text);
            _info_list.Add(_info_new);

            ht = "_";
            for (int i = 0; i < pelist.Count; i++)
            {


                persLineHint = "";

                if (pelist[i].I_DEAT == "DEAT Y")
                    _deatText = "DEAT Y";
                else
                    _deatText = "DEAT N";

                //I_FAMS
                if (pelist[i].I_FAMS == " ")
                    _famsText = " Fxxxxxx-";
                else
                    _famsText = pelist[i].I_FAMS;

                persLineText =
                    _famsText
                + ht + pelist[i].AA_I_INDEX
                + ht + pelist[i].I_NAME_GIVN
                + ht + pelist[i].I_NAME_SURN

                + ht + pelist[i].I_NAME_MARNM
                + ht + "," + pelist[i].I_BIRT_DATE
                + ht + pelist[i].I_BIRT_PLAC
                + ht + _deatText
                + ht + "," + pelist[i].I_DEAT_DATE
                + ht + pelist[i].I_DEAT_PLAC
                + ht + pelist[i].I_BURI_PLAC
                + ht + pelist[i].I_NAME_NSFX

                + ht + pelist[i].I_DEAT_CAUS
                //+ ht + afterHashtag(pelist[i].I_DEAT_CAUS)
                + ht + pelist[i].I_FAMC
                ;


                persLineText = CleanText(persLineText);

                //AddPersLine(pelist[i].AA_I_INDEX, persLineText, persLineHint);
                //                    public void AddPersLine(string persLine, string persCategory, string persText)
                //{
                PersLine persLineNew = new(pelist[i].AA_I_INDEX, persLineText, persLineHint);
                //persLine
                //, persCategory
                //, persText
                //);
                persLineList.Add(persLineNew);
                //}

                _dateString = ";;;;;";

                //1 _UPD 15 DEC 2019
                string updString = "1 _UPD 31 DEC 9999";
                if (pelist[i].I_UPD.Length > 12)
                {
                    updString = GetUpdateString("x _UPD " + pelist[i].I_UPD);  // length must be more than 11
                }
                else
                {
                    updString = "x _UPD 31 DEC 9999";
                }

                if (updString != "0;not 4,8,10,11;;")
                {
                    //AddUpdateLine(updString, "INDI", persLineText);
                    Updates updatesNew = new(updString, "INDI", persLineText);
                    updateslist.Add(updatesNew);
                }


                //CheckBox for empty birth date - OFF
                //if (pelist[i].I_BIRT_DATE == " ")
                //{
                //    string index = pelist[i].AA_I_INDEX.Replace("I",""); 
                //    _info_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
                //        + index;
                //    Console.WriteLine(_info_text);
                //    AddError("1231232", "INFO", _info_text);
                //}

                //CheckBox for empty birth date
                if (pelist[i].I_DEAT == "DEAT Y")

                    //string index = pelist[i].AA_I_INDEX.Replace("I", "");
                    //_info_text = "    _slow is ;" + _slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
                    //    + index;
                    //Console.WriteLine(_info_text);
                    //AddError("1231232", "INFO", _info_text);
                    //if (valueAdd == "DEAT Y")
                    pelist[i].I_SEX += "d";
                else
                    pelist[i].I_SEX += "a";


                if (pelist[i].I_BIRT != " ")
                {
                    _date = "," + pelist[i].I_BIRT_DATE;
                    //_dateString = ";;;;;";
                    if (pelist[i].I_BIRT_DATE != " ")
                        _dateString = GetDateString(pelist[i].I_BIRT_DATE);
                    _place = pelist[i].I_BIRT_PLAC;
                    _dio = "";
                    _cb = pelist[i].I_BIRT_NOTE;
                    _dateColl = _dateString.Split(';');
                    _date_val = _dateColl[0];
                    if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                    _month = _dateColl[4];
                    _year = _dateColl[5];

                    _kind = "1-BIRTH";
                    _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, pelist[i].AA_I_INDEX, pelist[i].I_SEX, persLineText);
                    eventList.Add(_event_new);

                    if (pelist[i].I_DEAT != " ")
                    {
                        _date = "," + pelist[i].I_DEAT_DATE;
                        _dateString = (string)GetDateString(pelist[i].I_DEAT_DATE);

                        _deathdateString = _dateString;
                        _place = pelist[i].I_DEAT_PLAC;
                        _cb = pelist[i].I_DEAT_NOTE;
                        _dateColl = _dateString.Split(';');
                        _date_val = _dateColl[0];
                        if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                        _month = _dateColl[4];
                        _year = _dateColl[5];

                        _kind = "4-DEATH";
                        _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, pelist[i].AA_I_INDEX, pelist[i].I_SEX, persLineText);
                        eventList.Add(_event_new);
                    }

                    if (pelist[i].I_BURI != " ")
                    {
                        _date = "," + pelist[i].I_BURI_DATE;
                        _dateString = GetDateString(pelist[i].I_BURI_DATE);
                        if (_dateString == " ")
                        {
                            _dateString = _deathdateString;
                            _deathdateString = "";
                        }

                        _place = pelist[i].I_BURI_PLAC;
                        _cb = "";
                        _dateColl = _dateString.Split(';');
                        _date_val = _dateColl[0];
                        if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                        _month = _dateColl[4];
                        _year = _dateColl[5];

                        _kind = "9-buried";
                        _event_new = new(0, _day, _month, _year, _date_val, _date, _kind, _dio, _cb, _place, pelist[i].AA_I_INDEX, pelist[i].I_SEX, persLineText);
                        eventList.Add(_event_new);
                    }
                }
                ht = "#";


                _info_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";end   of Populate PersLineList: " + persLineList.Count;
                Console.WriteLine(_info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);

                _info_text = "___________________________________________________start;" + _start_time_global + ";now;" + DateTime.Now + "_slow;" + _slow + ";end   of Populate EventList: " + eventList.Count;
                Console.WriteLine(_info_text);
                _info_new = new("INFO;", ";", A00_Code._info_text);
                _info_list.Add(_info_new);



                SaveInfo(_path, "__ged_IN_info.txt");


                Do_99_PlaySound();

                Console.WriteLine(Environment.NewLine + "Press ENTER to finish !");
                _info_new = new("INFO;", ";", _info_text);
                _info_list.Add(_info_new);

                Console.ReadLine();
            }
        }
    }

    private static void Xwrite(string _v, bool _print, string _line_string)
    {
        _info_text = _v + ":; " + DateTime.Now + " > " + _line_string;
        Console.WriteLine(_info_text);
        if (_print)
        {
            _info_new = new("INFO;", ";", _info_text);
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

        String strHeaderERRORS = "E_LINE;E_INDEX;E_TEXT;E_HINT;E_EMPTY";

        //for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //{
        //    strHeaderArray += dataGridView1.Columns[i].HeaderText + _separatorstringArray;
        //}

        //strHeaderArray = strHeaderArray.TrimEnd(_separatorArray);

        streamWriterERRORS.WriteLine(strHeaderERRORS);

        //for (int j = 0; j < pelist.Count - 1; j++)
        int errorsMax = _info_list.Count;
        //errorsMax = 10; if (errorsMax > _info_list.Count) errorsMax = _info_list.Count; // limited to 50 Persone

        for (int j = 0; j < errorsMax; j++)                         // limited to 50 Persone
        {
            // Xwrite ERRORSs
            //if (_info_list[j].AA_E_INDEX.Substring(0, 1) == "N")
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

    private static void SaveEntry(string keyPrevious, string entryText, string updateString, string sourceString)
    {
        Debugger.Break();
    }

    private static string GetDateString(string i_BIRT_DATE)
    {
        Debugger.Break(); return "";
    }

    private static string CleanText(string valueAdd)
    {
        Debugger.Break(); return "";
    }

    private static string CleanID(string valueAdd)
    {
        Debugger.Break(); return "";
    }

    private static void Do_99_PlaySound()
    {
        // Sound abspielen (benötigt .wav-Datei oder Resource)
        try
        {
            using var player = new SoundPlayer(@"C:\\DB\\sound001.wav");
            player.PlaySync();
            //Console.WriteLine("\nSound abgespielt!");
        }
        catch
        {
            _info_text = "\nSound-Datei nicht gefunden.";
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
            _info_list.Add(_info_new);
            Xwrite("Step_9905", true, _info_text);

        }
    }

    private static string DoReplace_stuff(string _line_string, out string _line2)
    {
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


        _line_string = _line_string.Replace("M255-", "M.255-");

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

        _info_text = _newline + "A " + _line_string;
        Console.WriteLine(_info_text);
        _info_new = new("INFO;", ";", _info_text);
        _info_list.Add(_info_new);

        if (_line_string.Length == 0)
        {
            _info_text = _slow_string + "; NO_0099;#### line is empty;";// + _count.ToString();
            Xwrite("Step_9905", true, _line_string);

        }



        if (bool_nbsp == false && _slow > 1 && _line_string.Contains("&nbsp;"))
        {
            //AddError(_count.ToString(), "line contains &nbsp;", "");
            _info_text = "    _slow is ;" + _slow_string + "; NO_0098;line contains &nbsp;";// + _count.ToString();
            Xwrite("Step_9905", true, _line_string);

            _line_string = _line_string.Replace("&nbsp;", " ");


        }
        else if (bool_nbsp == true)
        {

        }
        else
        {
            _info_text = "    _slow is ;" + _slow_string + "; NO_0005;no output for &nbsp;";
            Xwrite("Step_9905", true, _line_string);

            bool_nbsp = true;

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
            _line_string = _introText + _line_string.Substring(_begin, secondblankOrEnd + 2);
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
            //Console.WriteLine(_newline + _text);
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

            A00_Code._info_text = "B " + _line_string;

            Xwrite("Step_9905", true, _line_string);

        }
        return _line_string;
    }
    // New: Read and process lines without UI calls
    private static List<string> A01_Read_Input(string path, string file, string extension)
    {
        var result = new List<string>();

        //string _nowREAD;
        string _info_text;// = _nowREAD;
        _info_text = DateTime.Now + " > starting >> input: " + path + file + extension;
        Console.WriteLine(_info_text);
        _info_new = new("INFO;", ";", _info_text);
        _info_list.Add(_info_new);
        //_info_new = new("INFO;", ";", A00_Code._info_text);

        DateTime _start_time = DateTime.Now;
        int lastPeListIndex = 0;
        int _count = 0;
        _nextGoalOfLines = 1000000 - 2;

        string fullPath = Path.Combine(path, file + extension);
        if (!File.Exists(fullPath))
        {
            _info_text = "Input-File not found >> " + path + file + extension;
            Console.WriteLine(_info_text);
            _info_new = new("INFO;", ";", _info_text);
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
                    _info_text = DateTime.Now + " > " + _count.ToString() + ": _start was ;" + _start_time + ";" + " for reading";
                    Console.WriteLine(_info_text);
                    _info_new = new("INFO;", ";", _info_text);
                    _info_list.Add(_info_new);
                    _nextGoalOfLines += 500000;
                }

                string? _line = _stream_Reader.ReadLine();
                if (_line == null) continue;

                //Debugger.Break(); return "";

                // perform replacements (reuse existing method)
                _line = DoReplace_Months_Days(_line);

                string key = _count.ToString();
                //db.Add(key, _line);
                result.Add(_line);

                int lastPeListIndex_DONE = lastPeListIndex - 1;
                lastPeListIndex = 1 + lastPeListIndex - 1 + 1;
            }
        }
        //#pragma warning restore SYSLIB0001 // Type or member is obsolete

        _info_text = "Step_1900:; " + DateTime.Now + " > " + _count.ToString() + ": _start was ;" + _start_time + ";" + _newline + " > reading finished";
        Console.WriteLine(_info_text);
        _info_new = new("INFO;", ";", _info_text);
        _info_list.Add(_info_new);
        //AddError("8888888", "INFO", _info_text);

        _count = 0;
        _nextGoalOfLines = 20000 + _count;

        //_places = new Dictionary<string, int>();

        return result;
    }

    public static string GetUpdateString(string line_string)
    {
        Debugger.Break(); return "";
    }

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

public class PersLine
{
    public string AA_P_INDEX;
    public string PERS_TEXT;
    //public string A__UPD;      
    public string PERS_HINT;
    //public string A_DESC;      

    public PersLine(
    string aa_p_index
    , string pers_text
    , string pers_hint
    //, string a_upd
    //, string a_desc
    )
    {
        AA_P_INDEX = aa_p_index;
        PERS_TEXT = pers_text;
        PERS_HINT = pers_hint;

    }
}

public class Source
{
    // SOUR
    public string AA_S_INDEX;
    //public string S_RIN;
    //public string S__UID;
    public string S_SOUR;
    public string S_AUTH;
    public string S_TITL;
    public string S_PUBL;
    public string S_TEXT;
    public string S_TEXT_CONC;
    public string S__TYP;
    public string S__MED;

    public string S_SOUR_CONC;




    public Source(
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

        AA_S_INDEX = aa_s_index;

        // SOURCE
        S_SOUR = s_sour;
        S_AUTH = s_auth;
        S_PUBL = s_publ;
        S__TYP = s__type;
        S__MED = s__medi;
        S_SOUR_CONC = s_sour_conc;
        S_TEXT_CONC = s_text_conc;
        S_TEXT = s_text;
        S_TITL = s_titl;
        //DATE = s_date;

    }
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




