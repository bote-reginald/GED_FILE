// File:A00_Code.cs

using System.Diagnostics;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
//using System.Windows;
//using System.Windows.Forms;

class A00_Code
{
    //private static readonly string z_in_file = "C:/DB/__ged_IN.ged";
    private static readonly string z_INDI_IN_file = "C:/DB/_3_INDI_IN.ged";
    private static readonly string z_FAM_IN_file = "C:/DB/_3_FAM_IN.ged";

    private static readonly string z_out_file = "C:/DB/__ged_IN-autosave.ged";
    private static readonly string z_out_file_PersLine = "C:/DB/_PersLine-out.txt";
    private static readonly string z_out_file_birth_list = "C:/DB/_Birth+NOTE-out.txt";
    private static readonly string z_out_file_death_list = "C:/DB/_Death+Buri-out.txt";
    private static readonly string z_out_file_info_list = "C:/DB/_Info-out.txt";
    private static readonly string z_out_file_FamLine = "C:/DB/_FamLine-out.txt";
    //private static readonly string z_out_file_AlbumLine = "C:/DB/_AlbumLine-out.txt";
    //private static readonly string z_out_file_SourceLine = "C:/DB/_SourceLine-out.txt";
    //private static readonly string z_out_file_NoteLine = "C:/DB/_NoteLine-out.txt";

    private static readonly Dictionary<string, int> _pe1_index = [];
    private static readonly Dictionary<string, int> _pe2_index = [];
    private static readonly Dictionary<string, int> _pe3_index = [];
    private static readonly Dictionary<string, int> _pe4_index = [];
    private static readonly Dictionary<string, int> _fam_index = [];


    private static readonly List<Pe> _pe1_list = [];
    private static readonly List<Pe> _pe2_list = [];
    private static readonly List<Pe> _pe3_list = [];
    private static readonly List<Pe> _pe4_list = [];
    private static readonly List<Pe> _pe5_list = [];
    private static readonly List<Pe> _pe6_list = [];
    private static readonly List<Pe> _pe7_list = [];
    private static readonly List<Pe> _pe8_list = [];
    private static readonly List<Pe> _pe9_list = [];
    private static readonly List<Fam> _fam_list = [];
    private static readonly List<Album> z_album_list = [];
    private static readonly List<Info> z_birth_list = [];
    private static readonly List<Event> z_event_marr_list = [];
    private static readonly List<Info> z_death_list = [];
    private static readonly List<Event> z_event_buri_list = [];
    private static readonly List<Note> z_note_list = [];
    private static readonly List<Source> z_source_list = [];
    private static readonly List<Updates> z_updates_list = [];
    private static readonly List<Obj> z_obj_list = [];


    private static readonly List<Info> _fam_line_list = [];
    private static readonly List<Info> _pers_line_list = [];
    //private static readonly List<Info> _birth_list = [];
    //private static readonly List<Info> _death_list = [];
    private static readonly List<Info> z_album_line_list = [];
    private static readonly List<Info> z_info_list = [];
    private static readonly List<Info> z_list = [];
    private static readonly List<Info> z_note_line_list = [];
    private static readonly List<Info> z_source_line_list = [];
    private static readonly List<Info> z_updates_line_list = [];
    private static readonly List<Info> z_obj_line_list = [];

    private static Info z_info_new = new("", "", "");
    private static readonly Event z_event_new = new(0, "", "", "", "", "", "", "", "", "", "", "", "");
    //private static bool _bool_sex_u;
    //private static bool bool_nbsp;
    //private static bool boolChecknbsp = false;
    //private static bool boolCheckUnklar;
    //private static bool boolSaveSingleEntry;
    private static int _count;
    private static int z_nextGoalOfLines = -1;

    private static readonly int z_slow = 8;

    private static readonly int z_lastPeListIndex = -1;
    private static int z_lastPeListIndex_DONE = -1;
    //private static readonly int unknownKeyCount = 0;
    private static readonly string z_newline = Environment.NewLine;
    private static readonly string z_separator = ";";
    //private static readonly string z_slow = "";
    //private static readonly string z_start_time_global = DateTime.Now.ToString();
    private static readonly string z_start_time_global = DateTime.Now.ToString();
    private static string _comment_inside_code = "";
    private static string _info_0_text = "";
    private static string z_gedheadText = "";
    //private static readonly string z_ht = " # ";
    private static readonly string z_tab = "\t";
    private static readonly string z_semicolon = ";";
    private static string z_key = "";
    //private static string unknownKeyText = "unknown";
    //private static string z_0 = "";
    //private static string z_1 = "";
    //private static string z_2 = "";
    private static string z_value = "";
    //private static string _valueAdd = "";
    private static string z_blank = " ";
//#pragma warning disable IDE0044 // Add readonly modifier
    private static bool bool_event_yes = false;
    private static StringBuilder sb = new(200);

    //#pragma warning restore IDE0044 // Add readonly modifier

    // Precompiled replacements to speed up Replace_stuff
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "SYSLIB1045:Convert to 'GeneratedRegexAttribute'.", Justification = "<Pending>")]
    private static readonly Regex z_replaceRegex = new(@"(&gt;|&auml;|&ouml;|&uuml;|&szlig;|&amp;|;;;;;|https://|http://|<p># |</a>|</p>|@;|@|\*| # ;|"";""|""|M255-)", RegexOptions.Compiled);
    private static readonly Dictionary<string, string> z_replMap = new()
    {
        {"&gt;", ">"}
        , {"&auml;", "ä"}
        , {"&ouml;", "ö"}
        , {"&uuml;", "ü"}
        , {"&szlig;", "ß"}
        , {"&amp;", "="}
        , {";;;;;", " - "}

        , {"https://", ""}
        , {"http://", ""}
        , {"<p># ", ""}
        , {"</a>", ""}
        , {"</p>", ""}
        , {"@;", ";"}

        , {"@", ""}
        , {"*", ""}
        , {" # ;", ";"}
        , {"\";\"", ";"}
        , {"\"", ""}
        , {"M255-", "M.255-"}
    };

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "SYSLIB1045:Convert to 'GeneratedRegexAttribute'.", Justification = "<Pending>")]
    private static readonly Regex z_replaceRegex_Dat =
        new(@"(DATE.
| JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC 
|F,1.|F,2.|F,3.|F,4.|F,5.|F,6.|F,7.|F,8.|F,9.
|M,1.|M,2.|M,3.|M,4.|M,5.|M,6.|M,7.|M,8.|M,9.
)", RegexOptions.Compiled);
    //|\t1.|\t2.|\t3.|\t4.|\t5.|\t6.|\t7.|\t8.|\t9.
    //|1.|2.|3.|4.|5.|6.|7.|8.|9.

    private static readonly Dictionary<string, string> z_replMap_Dat = new()
    {
        { "DATE.", "DATE ."}

        , {" JAN ", ".01."}
        , {" FEB ", ".02."}
        , {" MAR ", ".03."}
        , {" APR ", ".04."}
        , {" MAY ", ".05."}
        , {" JUN ", ".06."}
        , {" JUL ", ".07."}
        , {" AUG ", ".08."}
        , {" SEP ", ".09."}
        , {" OCT ", ".10."}
        , {" NOV ", ".11."}
        , {" DEC ", ".12."}

        //, {"\t1.", "\t01."}
        //, {"\t2.", "\t02."}
        //, {"\t3.", "\t03."}
        //, {"\t4.", "\t04."}
        //, {"\t5.", "\t05."}
        //, {"\t6.", "\t06."}
        //, {"\t7.", "\t07."}
        //, {"\t8.", "\t08."}
        //, {"\t9.", "\t09."}

        //, {"\"1.", "\"01."}
        //, {"\"2.", "\"02."}
        //, {"\"3.", "\"03."}
        //, {"\"4.", "\"04."}
        //, {"\"5.", "\"05."}
        //, {"\"6.", "\"06."}
        //, {"\"7.", "\"07."}
        //, {"\"8.", "\"08."}
        //, {"\"9.", "\"09."}

        , {"F,1.", "F,01."}
        , {"F,2.", "F,02."}
        , {"F,3.", "F,03."}
        , {"F,4.", "F,04."}
        , {"F,5.", "F,05."}
        , {"F,6.", "F,06."}
        , {"F,7.", "F,07."}
        , {"F,8.", "F,08."}
        , {"F,9.", "F,09."}

        , {"M,1.", "M,01."}
        , {"M,2.", "M,02."}
        , {"M,3.", "M,03."}
        , {"M,4.", "M,04."}
        , {"M,5.", "M,05."}
        , {"M,6.", "M,06."}
        , {"M,7.", "M,07."}
        , {"M,8.", "M,08."}
        , {"M,9.", "M,09."}
            };

    //    if (_line_string.Contains("DATE."))
    //_line_string = _line_string.Replace("DATE.", "DATE .");

    //_line_string = _line_string.Replace(" JAN ", ".01.");
    //_line_string = _line_string.Replace(" FEB ", ".02.");
    //_line_string = _line_string.Replace(" MAR ", ".03.");
    //_line_string = _line_string.Replace(" APR ", ".04.");
    //_line_string = _line_string.Replace(" MAY ", ".05.");
    //_line_string = _line_string.Replace(" JUN ", ".06.");
    //_line_string = _line_string.Replace(" JUL ", ".07.");
    //_line_string = _line_string.Replace(" AUG ", ".08.");
    //_line_string = _line_string.Replace(" SEP ", ".09.");
    //_line_string = _line_string.Replace(" OCT ", ".10.");
    //_line_string = _line_string.Replace(" NOV ", ".11.");
    //_line_string = _line_string.Replace(" DEC ", ".12.");




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

    //_line_string = _line_string.Replace("\t1.", "\t01.");
    //_line_string = _line_string.Replace("\t2.", "\t02.");
    //_line_string = _line_string.Replace("\t3.", "\t03.");
    //_line_string = _line_string.Replace("\t4.", "\t04.");
    //_line_string = _line_string.Replace("\t5.", "\t05.");
    //_line_string = _line_string.Replace("\t6.", "\t06.");
    //_line_string = _line_string.Replace("\t7.", "\t07.");
    //_line_string = _line_string.Replace("\t8.", "\t08.");
    //_line_string = _line_string.Replace("\t9.", "\t09.");

    //_line_string = _line_string.Replace("\"1.", "\"01.");
    //_line_string = _line_string.Replace("\"2.", "\"02.");
    //_line_string = _line_string.Replace("\"3.", "\"03.");
    //_line_string = _line_string.Replace("\"4.", "\"04.");
    //_line_string = _line_string.Replace("\"5.", "\"05.");
    //_line_string = _line_string.Replace("\"6.", "\"06.");
    //_line_string = _line_string.Replace("\"7.", "\"07.");
    //_line_string = _line_string.Replace("\"8.", "\"08.");
    //_line_string = _line_string.Replace("\"9.", "\"09.");

    //_line_string = _line_string.Replace("F,1.", "F,01.");
    //_line_string = _line_string.Replace("F,2.", "F,02.");
    //_line_string = _line_string.Replace("F,3.", "F,03.");
    //_line_string = _line_string.Replace("F,4.", "F,04.");
    //_line_string = _line_string.Replace("F,5.", "F,05.");
    //_line_string = _line_string.Replace("F,6.", "F,06.");
    //_line_string = _line_string.Replace("F,7.", "F,07.");
    //_line_string = _line_string.Replace("F,8.", "F,08.");
    //_line_string = _line_string.Replace("F,9.", "F,09.");

    //    _line_string = _line_string.Replace("M,1.", "M,01.");
    //    _line_string = _line_string.Replace("M,2.", "M,02.");
    //    _line_string = _line_string.Replace("M,3.", "M,03.");
    //    _line_string = _line_string.Replace("M,4.", "M,04.");
    //    _line_string = _line_string.Replace("M,5.", "M,05.");
    //    _line_string = _line_string.Replace("M,6.", "M,06.");
    //    _line_string = _line_string.Replace("M,7.", "M,07.");
    //    _line_string = _line_string.Replace("M,8.", "M,08.");
    //    _line_string = _line_string.Replace("M,9.", "M,09.");
    //};


    //private bool bool_nbsp = false;



    private static int N72_Get_2nd_blank(int _first_blank, string _line_string)
    {
        int secondSpaceIndex = -1;
        int secondblankOrEnd;
        //if (_line_string == "2 AGE 74")
        //{
        //    Debugger.Break();
        //}
        if (/*_first_blank >= 0 &&*/ _first_blank + 1 < _line_string.Length)
        {
            secondSpaceIndex = _line_string.IndexOf(' ', _first_blank + 1);
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
        return secondblankOrEnd;
    }


    private static void N11_Save(string v, List<Info> _list, string _out_file)
    {
        StreamWriter _stream_Writer = new(File.Open(_out_file, FileMode.Create), Encoding.UTF8);

        //z_nextGoalOfLines = _count;
        _count = -1;
        z_nextGoalOfLines = 50000;

        while (v.Length < 20)
        {
            v = " " + v;
        }

        _info_0_text = "Output > " + v;
        string _out_text = _out_file switch
        {
            "C:/DB/_PersLine-out.txt" => "LINE\tI_INDI_NR\tNAME\tGIVN\tMARR-NAME\tBIRT_DATE\tBIRT_PLAC\tDEAT_DATE\tDEAT_PLAC\tI_SEX_DEAT\tI_BURI_PLAC\tNAME_NSFX\tFAMC\tFAMS",// + z_newline,
            "C:/DB/_FamLine-out.txt" => "LINE\tI_INDI\tHUSB\tWIFE\tMARR_DATE\tMARR_PLAC",// + z_newline, + z_newline,

            "C:/DB/_Birth+NOTE-out.txt" => "DATE\tWHAT\tI_INDI_NR\tNAME\tGIVN\tMARR-NAME\tBIRT_DATE\tBIRT_PLAC\tDEAT_DATE\tDEAT_PLAC\tI_SEX_DEAT\tI_BURI_PLAC\tNAME_NSFX\tFAMC\tFAMS"
                                        +  "\tBIRT_NOTE\tBIO",// + z_newline, + z_newline,
            "C:/DB/_Death+Buri-out.txt" => "DATE\tWHAT\tI_INDI_NR\tNAME\tGIVN\tMARR-NAME\tBIRT_DATE\tBIRT_PLAC\tDEAT_DATE\tDEAT_PLAC\tI_SEX_DEAT\tI_BURI_PLAC\tNAME_NSFX\tFAMC\tFAMS"
            + "\tDEAT_NOTE\tDEAT_CAUS\tBURI",// + z_newline, + z_newline,
            "C:/DB/_AlbumLine-out.txt" => "I_INDI_NR\tHUSB\tWIFE\tMARR_DATE\tMARR_PLAC",// + z_newline, + z_newline,
            _ => "I_INDI_NR\tNAME\tGIVN\tMARR-NAME\tBIRT_DATE\tBIRT_PLAC\tDEAT_DATE\tDEAT_PLAC\tI_SEX_DEAT\tI_BURI_PLAC\tNAME_NSFX\tFAMC\tFAMS\ta\tb\tc\td\te",// + z_newline, + z_newline,//case "C:/DB/_PersLine-out.txt":
        };
        _out_text += z_newline;

        //string _all_text = "";
        foreach (var _line in _list)
        {
            _count += 1;

            //string _all_text = Replace_Months_Days(_line);
            //_all_text += Environment.NewLine + _line;
            //Debugger.Break(); return "";

            _out_text += _line.AA_E_INDEX + z_tab + _line.E_TEXT + z_tab + _line.E_HINT +  z_newline;

            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = " save > " + _count.ToString() + ":_start=;" + z_start_time_global;
                Xwrite("Step_1800", true, _info_0_text);

                z_nextGoalOfLines += 50000;

                _stream_Writer.WriteLine(_out_text);
                _out_text = "";
            }
        }
        //Debugger.Break(); return "";
        //_stream_Writer.Xwrite(_all_text);
        //Thread.Sleep(2000);

        _stream_Writer.WriteLine(_out_text);

        _stream_Writer.Close();

        string _count_text = _list.Count.ToString();
        while (_count_text.Length < 6)
        {
            _count_text = " " + _count_text;
        }

        _info_0_text = " _out_text " + v + " > " + _count_text + " > FINISHED ";
        Xwrite("Step_2500:; (N11_Save) > ", true, _info_0_text);

        _comment_inside_code = "back to Main()";
    }

    private static void N05_DoAutosave(List<string> _all_lines)
    {
        //Debugger.Break();
        //try
        //{
        //z_start_time_global = DateTime.Now;
        // run processing on background thread and get processed lines


        StreamWriter _stream_Writer = new(File.Open(z_out_file, FileMode.Create), Encoding.UTF8);

        _count = -1;
        z_nextGoalOfLines = 1000000;

        _info_0_text = "Output";
        //string _all_text = "";
        foreach (var _line in _all_lines)
        {
            _count += 1;

            //string _all_text = Replace_Months_Days(_line);
            //_all_text += Environment.NewLine + _line;
            //Debugger.Break(); return "";

            _stream_Writer.WriteLine(_line);

            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = " autosav > " + _count.ToString() + ":_start=;" + z_start_time_global;
                Xwrite("Step_1800", true, _info_0_text);

                z_nextGoalOfLines += 1000000;
            }
        }
        //Debugger.Break(); return "";
        //_stream_Writer.Xwrite(_all_text);
        //Thread.Sleep(2000);

        _stream_Writer.Close();
        _info_0_text = "autosav > " + _count.ToString() + " > FINISHED ";
        Xwrite("Step_1500", true, _info_0_text);
        //}
        //catch (Exception ex)
        //{
        //    _info_0_text = " > Error: " + ex.Message;
        //    Xwrite("Step_9900", true, _count + z_newline + " > Replace_stuff ");
        //    Debugger.Break();
        //}
    }


    private static void Xwrite(string _v, bool _print, string _line_string)
    {
        _info_0_text = _v + ":; " + DateTime.Now + " > " + _line_string;
        Console.WriteLine(_info_0_text);
        Trace.WriteLine(_info_0_text);
        if (_print)
        {
            z_info_new = new("INFO;", ";", _info_0_text);
            z_info_list.Add(z_info_new);
        }

    }

    public static void SaveInfo(string path, string file)
    {
        char _separatorArray = ';';
        //string arrayline;// = "";
        string z_newline = Environment.NewLine;
        string txt = ".txt";
        //Console.WriteLine(z_newline + z_newline + "##### Errors:" + z_newline);

        string arrayFileERRORS = path + file + "__INFO_out" + txt;
        //////if (vout == true)  // always
        //////{
        //////    arrayFileERRORS = "V:/" + file + "__ERRORS_out.txt";
        //////    infoText = "    _____start;" + z_start_time_global + ";now;" + DateTime.Now + ";_slow_1;" + arrayFileERRORS;
        //////    Console.WriteLine(infoText);
        //////    AddError("8888888", "INFO", infoText);
        //////}
        //////else
        //////{
        //infoText = "    start;" + z_start_time_global + ";now;" + DateTime.Now + ";z_slow;" + z_slow + ";" + arrayFileERRORS;
        //Console.WriteLine(infoText);
        //AddError("8888888", "INFO", infoText);
        //////}

        StreamWriter streamWriterERRORS = new(File.Open(arrayFileERRORS, FileMode.Create), Encoding.UTF8);
        //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";BEGIN;streamWriterERRORS = _ERRORS_out" + txt);

        string strHeaderERRORS = "E_LINE;E_INDEX;E_TEXT;E_HINT;E_EMPTY";

        //for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //{
        //    strHeaderArray += dataGridView1.Columns[i].HeaderText + _separatorstringArray;
        //}

        //strHeaderArray = strHeaderArray.TrimEnd(_separatorArray);

        streamWriterERRORS.WriteLine(strHeaderERRORS);

        //for (int j = 0; j < _pe1_list.Count - 1; j++)
        int errorsMax = z_info_list.Count;
        //errorsMax = 10; if (errorsMax > z_info_list.Count) errorsMax = z_info_list.Count; // limited to 50 Persone

        for (int j = 0; j < errorsMax; j++)                         // limited to 50 Persone
        {
            // Xwrite ERRORSs
            //if (z_info_list[j].AA_E_INDEX.[..1] == "N")
            //{

            string arrayline = //{0} + {1} {2} {3} {4} {5} {6}"
                _separatorArray + z_info_list[j].AA_E_INDEX
                + _separatorArray + z_info_list[j].E_TEXT
                + _separatorArray + z_info_list[j].E_HINT
                ;

            // arrayline = CleanText(arrayline);   // not for errors

            //Console.WriteLine(arrayline);

            streamWriterERRORS.WriteLine(arrayline);
            //arrayline = "";
            //}



        }
        streamWriterERRORS.WriteLine(z_newline + "#######   maybe not finished ... this is __INFO_Out.txt - it is now: " + DateTime.Now + z_newline + z_newline);
        streamWriterERRORS.Close();
        //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;streamWriterERRORS = _ERRORS_out" + txt);
        //#endregion End write ERRORS
    }

    //private static void SaveEntry(string keyPrevious, string _entry_text, string _update_string, string _source_string)
    //{
    //    Debugger.Break();
    //}

    private static string N60_GetDateString(string _dateIN)
    {
        //int z_slow = 8;

        //if (dateIN_old == "xyz") dateIN_old = "z";

        //if (_dateIN == "ca. Jul 1615")
        //    _dateIN = _dateIN.Replace("=", "");

        _comment_inside_code = "x-TURNEDOFF";
        //if (_dateIN.Contains("x-TURNEDOFF"))
        //{
        //    _info_0_text = _count.ToString() + "date contains 'x';" + _dateIN;
        //    Xwrite("Step_1103", true, _count + _info_0_text);
        //    //Console.WriteLine(_info_0_text);
        //    //z_info_new = new("INFO;", ";", _info_0_text);
        //    //z_info_list.Add(z_info_new);

        //    _info_0_text = _count.ToString() + "date contains 'x';" + _dateIN;
        //    Xwrite("Step_1104", true, _count + _info_0_text);
        //    //Console.WriteLine(_info_0_text);
        //    //z_info_new = new("INFO;", ";", _info_0_text);
        //    //z_info_list.Add(z_info_new);
        //    //AddError(_count.ToString(), "date contains 'x';", _dateIN);
        //    //_lineString = _lineString.Replace("&nbsp;", " ");
        //}
        //if (_dateIN.Length > 0 && _dateIN[..1] != "u")
        //    bool_getDateValue = true;

        _comment_inside_code = "_dateIN is e.g. 29.03.1969;";
        _count = 0;
        //bool bool_getDateValue = false;
        string ValDateString;
        string _date_YYYYMMDD_string;
        //if (_dateIN.Contains("x")) //-TURNEDOFF"))


        string day;
        string month;
        string year;
        string _minus_string = "-";

#pragma warning disable IDE0059 // Unnecessary assignment of a z_value
        string dateIN_old = _dateIN;
#pragma warning restore IDE0059 // Unnecessary assignment of a z_value

        string dateOUT = ";;";
        //string separator = ";";
        _dateIN = _dateIN.Replace(" DEC ", ".12.");
        _dateIN = _dateIN.Replace("ABT ", "");
        _dateIN = _dateIN.Replace("BEF ", "");
        _dateIN = _dateIN.Replace("CALC ", "");
        _dateIN = _dateIN.Replace("=", "");
        _dateIN = _dateIN.Replace("ca. ", "");
        _dateIN = _dateIN.Replace("ca.", "");

        _date_YYYYMMDD_string = ",nv-nv-nv";

        //_dateIN = _dateIN.Replace(" Januar ", " JAN ");
        //_dateIN = _dateIN.Replace(" Februar ", " FEB ");
        //_dateIN = _dateIN.Replace(" März ", " MAR ");
        //_dateIN = _dateIN.Replace(" April ", " APR ");
        //_dateIN = _dateIN.Replace(" Mai ", " MAY ");
        //_dateIN = _dateIN.Replace(" Juni ", " JUN ");
        //_dateIN = _dateIN.Replace(" Juli ", " JUL ");
        //_dateIN = _dateIN.Replace(" August ", " AUG ");
        //_dateIN = _dateIN.Replace(" September ", " SEP ");
        //_dateIN = _dateIN.Replace(" Oktober ", " OCT ");
        //_dateIN = _dateIN.Replace(" November ", " NOV ");
        //_dateIN = _dateIN.Replace(" Dezember ", " DEC ");

        //int dateIN_Length = _dateIN.Length;

        _comment_inside_code = "Xwrite(\"Step_1702\", true, _info_0_text);" + _date_YYYYMMDD_string;
        //_info_0_text = "Length= " + _dateIN.Length + ", _dateIN= " + _dateIN;
        //Xwrite("Step_1702", true, _info_0_text);

        switch (_dateIN.Length)//.ToString())
        {
            //case "0": break; // Empty
            case 0: break; // Empty

            //case "11":
            case 11:
                // for some tasks the date comes with leading '0' and leading character e.g. u for _UPD
                //_dateIN = _dateIN.Substring(1, 10);
                year = _dateIN.Substring(7, 4);
                month = _dateIN.Substring(4, 2);
                //day = _dateIN.Substring(0, 2);
                day = _dateIN.Substring(1, 2);
                dateOUT = day + z_separator + month + z_separator + year;
                _date_YYYYMMDD_string = year + _minus_string + month + _minus_string + day;

                break;

            //case "10":
            case 10:
                _comment_inside_code = "e.g. 1.07.1970";
                //if (_dateIN.Length == 11)
                //{
                year = _dateIN.Substring(6, 4);
                //month = N76_not_used_GetMonthNumeric(_dateIN.Substring(3, 3));
                month = _dateIN.Substring(3, 2);
                //day = _dateIN.Substring(0, 2);
                day = string.Concat("0", _dateIN.AsSpan(1, 1));
                dateOUT = day + z_separator + month + z_separator + year;
                _date_YYYYMMDD_string = year + _minus_string + month + _minus_string + day;
                //if (day[..1].Contains("0"))

                //_comment_inside_code = "day contains leading '0'";
                //if (day[..1].Contains('0'))
                //{
                //    _info_0_text = "day contains leading '0';" + _dateIN;
                //    Console.WriteLine(_info_0_text);
                //    z_info_new = new("INFO;", ";", _info_0_text);
                //    z_info_list.Add(z_info_new);
                //    //_lineString = _lineString.Replace("&nbsp;", " ");
                //    day = "";
                //}
                //;
                //}eventl
                break;

            //case "9":
            case 9:
                _comment_inside_code = "e.g. ,1.07.1970 or > ,AFT 1856";

                if (_dateIN.Contains("AFT") || _dateIN.Contains("BEF") || _dateIN.Contains("ABT"))
                {
                    year = _dateIN.Substring(5, 4);
                    month = _dateIN.Substring(1, 2); //day = dateIN.[..1];
                    day = "00";
                    dateOUT = /*day + */z_separator + month + z_separator + year;
                    _date_YYYYMMDD_string = year + _minus_string + month + _minus_string + day;
                    //}
                    break;

                }
                else
                {
                    _comment_inside_code = "e.g. 1.07.1970";

                    year = _dateIN.Substring(5, 4);
                    month = _dateIN.Substring(3, 2);
                    day = "0" + _dateIN[..1];
                    dateOUT = day + z_separator + month + z_separator + year;
                    _date_YYYYMMDD_string = year + _minus_string + month + _minus_string + day;
                    break;
                }
            //month = N76_not_used_GetMonthNumeric(_dateIN.Substring(2, 3)); day = _dateIN[..1];

            //case "8":
            case 8:
                if (_dateIN == "unbekannt" || _dateIN == "unbekannt=")
                    dateOUT = "unbekannt";
                break;
            //{


            //case "7":
            case 7:
                //if (_dateIN.Length == 8)
                //{
                year = _dateIN.Substring(4, 4);
                //month = N76_not_used_GetMonthNumeric(_dateIN.Substring(0, 3)); 
                month = _dateIN[..3]; //day = _dateIN.[..1];
                dateOUT = /*day + */z_separator + month + z_separator + year;
                day = "00";
                _date_YYYYMMDD_string = year + _minus_string + month + _minus_string + day;
                //}
                break;

            //case "4":
            case 5:
                _comment_inside_code = "e.g. ,1964";
                //if (_dateIN.Length == 4)
                //{
                //year = _dateIN.Substring(0, 4); 
                year = _dateIN.Substring(1, 4);
                dateOUT = /*day +*/ z_separator + /*month +*/ z_separator + year;
                _date_YYYYMMDD_string = year + "-00-00";
                //}
                break;
            default:
                dateOUT = "not 4,8,10,11;;";
                //Console.WriteLine(dateOUT + dateIN_old); 
                //dateOUT = ";;";
                break;
        }

        //if (z_slow > 12 && dateOUT.Contains("not"))
        //{
        //    _info_0_text = "dateOUT contains 'not';" + _dateIN;
        //    Xwrite("Step_1502", true, _count + _info_0_text);
        //    //_lineString = _lineString.Replace("&nbsp;", " ");
        //}

        _comment_inside_code = "getDateValue";
        //if (bool_getDateValue == true && z_slow > 9 && year != "")
        //    try
        //    {
        //        float valYear = 0f;
        //        float valDay = 0f;
        //        float valMonth = 0f;
        //        float valDate = 0f;
        //        ValDateString = "0;;";

        //        if (year != "") valYear = float.Parse(year);

        //        if (day != "") valDay = float.Parse(day);

        //        //float valMonth = 0;
        //        valMonth = month switch
        //        {
        //            "01" => 0f,
        //            "02" => 31f,
        //            "03" => 59.25f,
        //            "04" => 90.25f,
        //            "05" => 120.25f,
        //            "06" => 151.25f,
        //            "07" => 181.25f,
        //            "08" => 212.25f,
        //            "09" => 243.25f,
        //            "10" => 273.25f,
        //            "11" => 304.25f,
        //            "12" => 334.25f,
        //            _ => 0f,
        //        };
        //        if (valYear < 1900f) valYear += 2000f;

        //        valDate = ((valYear - 1900f) * 365.24219f) + 1 + valMonth + valDay;  // Excel 1.1.1900 = 1

        //        if (float.Parse(year) < 1900f)
        //            valDate -= 730486.5f;



        //        if (valDate != 0f)
        //        {
        //            ValDateString =
        //                "" + ((int)valDate / 1).ToString()
        //                + ";" + ((int)valDate / 10).ToString()
        //                + ";" + ((int)valDate / 100).ToString()
        //                + ""
        //                ;
        //        }
        //    }
        //    catch
        //    {
        //        ValDateString = "nv;nv;nv";
        //    }

        //if (ValDateString == "0")
        //{
        //    ValDateString = "nv;nv;nv";
        //}
        ValDateString = "," + _date_YYYYMMDD_string + ";;";

        return /*separator + */ValDateString + z_separator + dateOUT;
    }

    public static string N76_not_used_GetMonthNumeric(string month)
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

    //private static string CleanText(string _valueAdd)
    //{
    //    //Debugger.Break(); return "";
    //}

    private static string N61_CleanID(string id)
    {
        id = id.Replace("@", "");
        //id = id.Replace("=", "");
        //id = id.Replace(";", "");
        //id = id.Replace(" ", "");
        //id = id.Replace("#", "");
        switch (id.Length)
        {
            case 1: id = "00000" + id; break;
            case 2: id = "0000" + id; break;
            case 3: id = "000" + id; break;
            case 4: id = "00" + id; break;
            case 5: id = "0" + id; break;
        }

        return id;
    }

    private static void PlaySound()
    {
        // Sound abspielen (benötigt .wav-Datei oder Resource)
        try
        {

            //#pragma warning disable CA1416 // Validate platform compatibility > only Windows supports System.Media.SoundPlayer, no other OS

            using var player = new SoundPlayer(@"C:\\DB\\sound001.wav");
            player.PlaySync();
            //#pragma warning restore CA1416 // Validate platform compatibility
            //Console.WriteLine("\nSound abgespielt!");
        }
        catch
        {
            _info_0_text = "\nSound-Datei nicht gefunden.";
            //Console.WriteLine(_info_0_text);
            //z_info_new = new("INFO;", ";", _info_0_text);
            //z_info_list.Add(z_info_new);
            Xwrite("Step_9909", true, _info_0_text);
        }
    }

    private static string Replace_stuff(string _line_string, out string _line2)
    {
        if (string.IsNullOrEmpty(_line_string))
        {
            _line2 = _line_string ?? string.Empty;
            return _line2;
        }

        // quick special-case for this common token
        if (_line_string.Contains("/ Sr.M."))
            _line_string = _line_string.Replace("/ Sr.M.", "# Sr.M.");

        if (_line_string.Contains('='))
            _line_string = _line_string.Replace("=", "");

        if (_line_string.Contains("<a href"))
            _line_string = _line_string.Replace("<a href", "");

        // Use regex to find candidates and then replace from map to reduce allocations
        _line_string = z_replaceRegex.Replace(_line_string, m =>
        {
            var key = m.Value;
            if (z_replMap.TryGetValue(key, out var rep))
            {
                return rep;
            }
            else
            {
                return _line_string;
            }
        });

        // additional cleanup

        _line2 = _line_string;
        return _line_string;
    }

    private static string Replace_Months_Days(string _line_string)
    {
        _comment_inside_code = "add missing z_blank after DATE for e.g. ABT 10.1984";

        string _line2_string = z_replaceRegex_Dat.Replace(_line_string, m =>
        {
            var key = m.Value;
            if (z_replMap_Dat.TryGetValue(key, out string? rep))
            {
                return rep;
            }
            else
            {
                return _line_string;
            }
        });

        //if (_line_string.Contains("DATE."))
        //    _line_string = _line_string.Replace("DATE.", "DATE .");

        //_line_string = _line_string.Replace(" JAN ", ".01.");
        //_line_string = _line_string.Replace(" FEB ", ".02.");
        //_line_string = _line_string.Replace(" MAR ", ".03.");
        //_line_string = _line_string.Replace(" APR ", ".04.");
        //_line_string = _line_string.Replace(" MAY ", ".05.");
        //_line_string = _line_string.Replace(" JUN ", ".06.");
        //_line_string = _line_string.Replace(" JUL ", ".07.");
        //_line_string = _line_string.Replace(" AUG ", ".08.");
        //_line_string = _line_string.Replace(" SEP ", ".09.");
        //_line_string = _line_string.Replace(" OCT ", ".10.");
        //_line_string = _line_string.Replace(" NOV ", ".11.");
        _line_string = _line_string.Replace(" DEC ", ".12.");




        ////_line_string = _line_string.Replace(". JAN ", ".01.");
        ////_line_string = _line_string.Replace(". FEB ", ".02.");
        ////_line_string = _line_string.Replace(". MAR ", ".03.");
        ////_line_string = _line_string.Replace(". APR ", ".04.");
        ////_line_string = _line_string.Replace(". MAY ", ".05.");
        ////_line_string = _line_string.Replace(". JUN ", ".06.");
        ////_line_string = _line_string.Replace(". JUL ", ".07.");
        ////_line_string = _line_string.Replace(". AUG ", ".08.");
        ////_line_string = _line_string.Replace(". SEP ", ".09.");
        ////_line_string = _line_string.Replace(". OCT ", ".10.");
        ////_line_string = _line_string.Replace(". NOV ", ".11.");
        ////_line_string = _line_string.Replace(". DEC ", ".12.");

        _line_string = _line_string.Replace("\t1.", "\t01.");
        _line_string = _line_string.Replace("\t2.", "\t02.");
        _line_string = _line_string.Replace("\t3.", "\t03.");
        _line_string = _line_string.Replace("\t4.", "\t04.");
        _line_string = _line_string.Replace("\t5.", "\t05.");
        _line_string = _line_string.Replace("\t6.", "\t06.");
        _line_string = _line_string.Replace("\t7.", "\t07.");
        _line_string = _line_string.Replace("\t8.", "\t08.");
        _line_string = _line_string.Replace("\t9.", "\t09.");

        _line_string = _line_string.Replace("\"1.", "\"01.");
        _line_string = _line_string.Replace("\"2.", "\"02.");
        _line_string = _line_string.Replace("\"3.", "\"03.");
        _line_string = _line_string.Replace("\"4.", "\"04.");
        _line_string = _line_string.Replace("\"5.", "\"05.");
        _line_string = _line_string.Replace("\"6.", "\"06.");
        _line_string = _line_string.Replace("\"7.", "\"07.");
        _line_string = _line_string.Replace("\"8.", "\"08.");
        _line_string = _line_string.Replace("\"9.", "\"09.");

        //_line_string = _line_string.Replace("F,1.", "F,01.");
        //_line_string = _line_string.Replace("F,2.", "F,02.");
        //_line_string = _line_string.Replace("F,3.", "F,03.");
        //_line_string = _line_string.Replace("F,4.", "F,04.");
        //_line_string = _line_string.Replace("F,5.", "F,05.");
        //_line_string = _line_string.Replace("F,6.", "F,06.");
        //_line_string = _line_string.Replace("F,7.", "F,07.");
        //_line_string = _line_string.Replace("F,8.", "F,08.");
        //_line_string = _line_string.Replace("F,9.", "F,09.");

        //_line_string = _line_string.Replace("M,1.", "M,01.");
        //_line_string = _line_string.Replace("M,2.", "M,02.");
        //_line_string = _line_string.Replace("M,3.", "M,03.");
        //_line_string = _line_string.Replace("M,4.", "M,04.");
        //_line_string = _line_string.Replace("M,5.", "M,05.");
        //_line_string = _line_string.Replace("M,6.", "M,06.");
        //_line_string = _line_string.Replace("M,7.", "M,07.");
        //_line_string = _line_string.Replace("M,8.", "M,08.");
        //_line_string = _line_string.Replace("M,9.", "M,09.");


        return _line2_string;
    }

#pragma warning disable CA1822 // Mark members as static
    private string Replace_DIV(string _line_string)
#pragma warning restore CA1822 // Mark members as static
    {
        //Console.WriteLine(_br);
        //Console.WriteLine("reading= ;" + _line_string);
        //_line_string = _in;
        string _br = " <br>";
        string z_newline = Environment.NewLine;
        //_count = 0;

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

        _info_0_text = z_newline + "A " + _line_string;
        Console.WriteLine(_info_0_text);
        z_info_new = new("INFO;", ";", _info_0_text);
        z_info_list.Add(z_info_new);

        if (_line_string.Length == 0)
        {
            _info_0_text = z_slow + "; NO_0099;#### line is empty;";// + _count.ToString();
            Xwrite("Step_1205", true, _line_string);

        }

        _comment_inside_code = "check for &nbsp; and replace with z_blank if found, otherwise add error if z_slow > 1";
        //bool boolChecknbsp = false;

        //if (boolChecknbsp == false && z_slow > 1 && _line_string.Contains("&nbsp;"))
        //{
        //    //AddError(_count.ToString(), "line contains &nbsp;", "");
        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0098;line contains &nbsp;";// + _count.ToString();
        //    Xwrite("Step_1215", true, _line_string);

        //    _line_string = _line_string.Replace("&nbsp;", " ");


        //}
        //else if (boolChecknbsp == true)
        //{

        //}
        //else
        //{
        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0005;no output for &nbsp;";
        //    Xwrite("Step_1235", true, _line_string);

        //    boolChecknbsp = true;

        //}


        return _line_string;
    }

    private static string Replace_aname(string _line_string)
    {
        //_line_string = _in;
        string z_newline = Environment.NewLine;
        string _text;

        string aname = "{";
        string anameString;
        string _nr;// = "";
        int _length;
        int _length1;
        int _begin = 0;
        _count = 0;

        if (_line_string.Contains(aname))
        {
            //Console.WriteLine(z_newline + "A " + _line_string);
            //z_info_new = new(z_newline + "A " + _line_string);
            //z_info_list.Add(z_info_new);

            string _introText = _line_string[.._begin];
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
                + "_first_blank =" + firstblank
                + ", =" + secondblankOrEnd
                + ", =" + thirdblankOrEnd + z_newline
                + ", " + _line_string
                //+ ", " + _line_string
                ;
            Console.WriteLine(z_newline + _text);
            //Console.WriteLine(z_newline + _introText);



            //Console.WriteLine("A " + _line_string);
            _length1 = _line_string.IndexOf('{');

            if (_line_string.Length < _length1)
                anameString = _line_string.Substring(1, _length1);

            _length = anameString.IndexOf('"');
            _nr = anameString[.._length];
            _line_string = _line_string.Replace("{", "Kxx" + _nr /*+ _br + z_newline*/ + " " + aname);

            //_line_string = _line_string + "K" + _nr + _br;
            _line_string = _line_string.Replace("{", "<a name=\"");
            _line_string = _line_string.Replace("Kxx", "K");

            _info_0_text = "B " + _line_string;

            Xwrite("Step_1245", true, _line_string);

        }
        return _line_string;
    }

    // New: Read and process lines without UI calls
    private static List<string> N01_Read_Input(/*string path,*/ string file/*, string extension*/)
    {
        var _result = new List<string>();

        _info_0_text = "starting >>>>>>>>>>>>>> input: " /*+ path*/ + file /*+ extension*/;
        Xwrite("Step_1202", true, _info_0_text);

        //DateTime z_start_time_global = DateTime.Now;
        int lastPeListIndex = 0;
        _count = 0;
        z_nextGoalOfLines = 1000000 - 2;

        string fullPath = Path.Combine(/*path,*/ file /* +extension*/);
        if (!File.Exists(fullPath))
        {
            _info_0_text = "Input-File not found >> " /*+ path + */ + file /*+ extension*/;
            Xwrite("Step_1111", true, _count + _info_0_text);
            //_ = MessageBox.Show("Input-File not found", "BEWARE", MessageBoxButtons.OK);
            //return _result;
        }

        //db = new Dictionary<string, string>();

        //#pragma warning disable SYSLIB0001 // Type or member is obsolete
        //using (StreamReader _stream_reader = new(fullPath, Encoding.UTF7))
        using (StreamReader _stream_reader = new(fullPath, Encoding.UTF8))
        {
            _count = 0;
            z_nextGoalOfLines = 1000000 - 1;
            string? _line = "";

            while (_stream_reader.Peek() != -1)
            {
                _count++;
                if (_count > z_nextGoalOfLines)
                {
                    _info_0_text = " reading > " + _count.ToString() + ": _start=; " + z_start_time_global;
                    Xwrite("Step_1100", true, _info_0_text);
                    z_nextGoalOfLines += 1000000;
                }

                //_line = "";
                _line = _stream_reader.ReadLine();
                if (_line == null || _line == "")
                {
                    Debugger.Break();
                    continue;
                }
                else
                {
                    _line = N62_CleanPlace(_line, out _line);

                }



                //Debugger.Break(); return "";

                // perform replacements (reuse existing method)


                _comment_inside_code = "NOT HERE _line = Replace_Months_Days(_line);";

                string key = _count.ToString();
                //db.Add(z_key, _line);
                _result.Add(_line);

                int lastPeListIndex_DONE = lastPeListIndex - 1;
                lastPeListIndex = 1 + lastPeListIndex - 1 + 1;
            }
        }
        //#pragma warning restore SYSLIB0001 // Type or member is obsolete

        _info_0_text = "reading > " + _count.ToString() + " > FINISHED ";
        Xwrite("Step_1200", true, _info_0_text);

        _count = 0;
        z_nextGoalOfLines = 20000 + _count;

        //_places = new Dictionary<string, int>();

        return _result;
    }

    public static string N78_not_used_GetUpdateString(string _upd)
    {
        _comment_inside_code = "Xwrite(\"Step_1706\", true, _info_0_text);";
        //_info_0_text = "Length= " + _upd.Length + ", _upd= " + _upd;
        //Xwrite("Step_1706", true, _info_0_text);

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
        _upd = N60_GetDateString(_upd);
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
            //, string i_fullname
            , string i_name_givn
            , string i_name_nick
            , string i_name_surn
            , string i_name_marn
            , string i_name_nsfx
            , string i_name_npfx
            , string i_name__for
            , string i_sex
            //, string i_birt
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
            //, string i_deat_age
            , string i_deat_caus
            , string i_deat_note
            //, string i_deat_rin
            //, string i_buri
            , string i_buri_plac
            //, string i_buri_date
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
            //, string i_occu_age

            //, string i_cens
            //, string i_cens_plac
            //, string i_cens_date
            //, string i_cens_age

            , string i_emig
            , string i_emig_plac

            , string i_immi
            , string i_immi_plac

            //, string i_even
            , string i_even_date      //     50
            , string i_even_note
            //, string i_even_age
            , string i_even_type
            , string i_even_plac
            //, string i_even_uid
            //, string i_even_rin
            , string i_note
            , string i_conc
            , string i_reli
            //, string i_conf
            //, string i_conf_date
            //, string i_conc_plac

            //, string i_resi   // Residence
            //, string i_resi_date
            //, string i_resi_age
            //, string i_resi_addr
            //, string i_resi_phon
            //, string i_email


            , string i_sour
            //, string i_sour_page      //     60
            //, string i_sour_quay
            //, string i_sour_even
            //, string i_sour_qual
            //, string i_sour_data
            //, string i_note
            , string i_note_conc
            , string i_date_time
            , string i_prin
            //, string i_nati

            //, string i_obje
            //, string i_obje_form
            , string i_obje_file
    //, string i_obje_titl
    //, string i_obje_note
    //, string i_obje__prim
    //, string i_obje__cutout
    //, string i_obje__parentrin
    //, string i_obje__personalphoto
    //, string i_obje__photo_rin
    //, string i_obje__position
    //, string i_obje__dat
    //, string i_obje__alb
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

        //public string I_NAME = i_fullname;         // 1
        public string I_NAME_GIVN = i_name_givn;
        public string I_NAME_NICK = i_name_nick;
        public string I_NAME_SURN = i_name_surn;
        public string I_NAME_MARNM = i_name_marn;
        public string I_NAME_NSFX = i_name_nsfx;
        public string I_NAME_NPFX = i_name_npfx;
        public string I_NAME__FOR = i_name__for;

        public string I_SEX = i_sex;

        //public string I_BIRT = i_birt;
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
        //public string I_DEAT_AGE = i_deat_age;
        public string I_DEAT_CAUS = i_deat_caus;
        public string I_DEAT_NOTE = i_deat_note;
        //public string I_DEAT_RIN;      

        //public string I_BURI = i_buri;
        public string I_BURI_PLAC = i_buri_plac;
        //public string I_BURI_DATE = i_buri_date;

        public string I_FAMS = i_fams;
        public string I_FAMC = i_famc;
        public string I_FAMC_PEDI = i_famc_pedi;
        //public string F_CHIL;      

        public string I_EMIG = i_emig;
        public string I_EMIG_PLAC = i_emig_plac;

        public string I_IMMI = i_immi;
        public string I_IMMI_PLAC = i_immi_plac;

        public string I_OCCU = i_occu;
        public string I_OCCU_PLAC = i_occu_plac;
        public string I_OCCU_DATE = i_occu_date;
        //public string I_OCCU_AGE = i_occu_age;

        //public string I_CENS = i_cens;
        //public string I_CENS_PLAC = i_cens_plac;
        //public string I_CENS_DATE;      
        //public string I_CENS_AGE;      

        //public string I_EVEN = i_even;
        public string I_EVEN_DATE = i_even_date;
        public string I_EVEN_NOTE = i_even_note;
        //public string I_EVEN_AGE = i_even_age;
        public string I_EVEN_TYPE = i_even_type;
        public string I_EVEN_PLAC = i_even_plac;
        //public string I_EVEN_UID;
        //public string I_EVEN_RIN;

        //public string I_SOUR_PAGE = i_sour_page;
        //public string I_SOUR_QUAY = i_sour_quay;
        //public string I_SOUR_QUAL = i_sour_qual;
        //public string I_SOUR_DATA = i_sour_data;
        //public string I_SOUR_EVEN = i_sour_even;


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
        //public string I_CONF = i_conf;
        //public string I_CONF_DATE = i_conf_date;
        //public string I_CONF_PLAC = i_conf;
        //public string I_RESI = i_resi;
        //public string I_RESI_ADDR = i_resi_addr;
        //public string I_RESI_DATE = i_resi_date;
        //public string I_RESI_AGE = i_resi_age;
        //public string I_RESI_PHON = i_resi_phon;
        //public string I_EMAIL = i_email;
        //public string I_NATI;
        //public string I_OBJE = i_obje;
        //public string I_OBJE_FORM;
        public string I_OBJE_FILE = i_obje_file;
        //public string I_OBJE_TITL = i_obje_titl;
        //public string I_OBJE_NOTE = i_obje_note;
        //public string I_OBJE__PRI;
        //public string I_OBJE__CUT;
        //public string I_OBJE__PAR;
        //public string I_OBJE__PER;
        //public string I_OBJE__PHO;
        //public string I_OBJE__POS;
        //public string I_OBJE__DAT = i_obje__dat;
        //public string I_OBJE__ALB = i_obje__alb;
    }

    public class Event(int aa_ev_index, string ev_day, string ev_month, string ev_year, string ev_date_val, string ev_date
        , string ev_kind, string ev_dio, string ev_cb, string ev_place, string ev_p_index, string ev_sex, string ev_p_line)
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

    public class Info(string aa_e_index, string e_text, string e_hint)
    {
        public string AA_E_INDEX = aa_e_index;
        public string E_TEXT = e_text;
        public string E_HINT = e_hint;
    }



    public class Note(string aa_n_index, string n_rin, string n_prin, string n_conc)
    {
        public string AA_N_INDEX = aa_n_index;
        public string N_RIN = n_rin;
        public string N_PRIN = n_prin;
        public string N_CONC = n_conc;
    }

    public class Obj(string aa_o_index, string o_rin, string o_titl, string o_obje_file, string o_desc)
    {
        public string AA_O_INDEX = aa_o_index;
        public string O_TITL = o_titl;
        public string O_OBJE_FILE = o_obje_file;
        public string O_RIN = o_rin;
        public string O_DESC = o_desc;
    }

    public class Album(string aa_a_index, string a_rin, string a_titl, string a_upd, string a_desc)
    {
        public string AA_A_INDEX = aa_a_index;
        public string A_TITL = a_titl;
        public string A__UPD = a_upd;
        public string A_RIN = a_rin;
        public string A_DESC = a_desc;
    }

    //public string Blank(string z_blank)
    //{
    //    z_blank = @"'"; //HEAD", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "")
    //    z_blank = z_blank.Replace("'", @"""");
    //    z_blank = z_blank.Replace(@"\", "");
    //    return z_blank;
    //}

    public class PersLine(string aa_p_index, string pers_text, string pers_hint)
    {
        public string AA_P_INDEX = aa_p_index;
        public string PERS_TEXT = pers_text;
        public string PERS_HINT = pers_hint;
    }

    public class FamLine(string aa_p_index, string pers_text, string pers_hint)
    {
        public string AA_P_INDEX = aa_p_index;
        public string PERS_TEXT = pers_text;
        public string PERS_HINT = pers_hint;
    }

    public class Source(string aa_s_index, /*string s_sour, */string s_auth, string s_titl//, string s_rin//, string s__uid
                /*, string s_publ*/, string s_text /*string s_text_conc, string s_sour_conc, string s__type, string s__medi*/)
    {
        public string AA_S_INDEX = aa_s_index;
        //public string S_RIN;
        //public string S__UID;
        //public string S_SOUR = s_sour;
        public string S_AUTH = s_auth;
        public string S_TITL = s_titl;
        //public string S_PUBL = s_publ;
        public string S_TEXT = s_text;
        //public string S_TEXT_CONC = s_text_conc;
        //public string S__TYP = s__type;
        //public string S__MED = s__medi;
        //public string S_SOUR_CONC = s_sour_conc;
    }

    public class Updates(string aa_u_index, string u_text, string u_hint)
    {
        public string AA_U_INDEX = aa_u_index;
        public string U_TEXT = u_text;
        public string U_HINT = u_hint;
    }

    private static void PopulatePe1List()
    {
        _count = 0;
        z_nextGoalOfLines = 10000;
        //string _deatText; > part of SEX
        //string _cb;
        //string _dio = "";
        //string _day;
        //string _month;
        //string _year;

        //string _place;
        string _date_val;
        string _dateString;
        string[] _dateColl;
        string _famsText;
        string _pers_line_text;
        string _pers_line_hint = "";
        //string _path;
        //string _immi_text = "";
        //string _kind;
        //string _fam_line_text;
        //string _album_line_text;
        //string _source_line_text;
        //string _deatText;
        //string _deathdateString;


        _comment_inside_code = "foreach (_pe in";
        for (int i = 0; i < _pe1_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate _pers_line_list + _birth_list + _death_list > " + _count;
                Xwrite("Step_2602", true, _info_0_text);
                z_nextGoalOfLines += 10000;
            }




            //if (_pe1_list[i].I_DEAT == "")
            //{
            //    //_deatText = "DEAT N";
            //    _pe1_list[i].I_SEX += "a";
            //}

            //else
            //{
            //    //_deatText = "DEAT Y";
            //    _pe1_list[i].I_SEX += "d";
            //}



            //if (_pe1_list[i].I_DEAT == "DEAT Y")

            //    //string index = _pe1_list[i].AA_I_INDEX.Replace("I", "");
            //    //_info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
            //    //    + index;
            //    //Console.WriteLine(_info_0_text);
            //    //AddError("1231232", "INFO", _info_0_text);
            //    //if (_valueAdd == "DEAT Y")
            //    _pe1_list[i].I_SEX += "d";
            //else
            //    _pe1_list[i].I_SEX += "a";

            //I_FAMS
            if (_pe1_list[i].I_FAMS == "")
                _famsText = " Fxxxxxx-";
            else
                _famsText = _pe1_list[i].I_FAMS;

            //string z_birt_date;// = "," + _pe1_list[i].I_BIRT_DATE;
            //if (z_birt_date.Length == 9)
            //if (_pe1_list[i].I_BIRT_DATE.Length == 9)
            //{
            //    z_birt_date = ",0" + _pe1_list[i].I_BIRT_DATE;
            //}
            //else
            //{
            //    z_birt_date = "," + _pe1_list[i].I_BIRT_DATE;
            //}

            //string z_deat_date;
            ////z_deat_date = "," + _pe1_list[i].I_DEAT_DATE;
            ////if (z_deat_date.Length == 10)
            //if (_pe1_list[i].I_DEAT_DATE.Length == 9)
            //{
            //    z_deat_date = ",0" + _pe1_list[i].I_DEAT_DATE;
            //}
            //else
            //{
            //    z_deat_date = "," + _pe1_list[i].I_DEAT_DATE;
            //}


            _pers_line_text = "I-" + _pe1_list[i].AA_I_INDEX
            + z_tab + _pe1_list[i].I_NAME_SURN
            + z_tab + _pe1_list[i].I_NAME_GIVN
            + z_tab + _pe1_list[i].I_NAME_MARNM
            + z_tab /*+ "," */+ _pe1_list[i].I_NAME_NSFX

            //+ z_tab + z_birt_date
            + z_tab + _pe1_list[i].I_BIRT_DATE
            + z_tab + _pe1_list[i].I_BIRT_PLAC
            + z_tab + _pe1_list[i].I_SEX
            //+ z_tab + z_deat_date
            + z_tab + _pe1_list[i].I_DEAT_DATE
            + z_tab + _pe1_list[i].I_DEAT_PLAC

            //+ z_tab + _deatText
            + z_tab + _pe1_list[i].I_BURI_PLAC

            //+ z_tab + _pe1_list[i].I_DEAT_CAUS
            + z_tab + _pe1_list[i].I_FAMC
            + z_tab + _famsText


            ;

            //_info_0_text = _pers_line_text;
            Info _info_new = new(_pe1_list[i].AA_I_INDEX, _pers_line_text, _pers_line_hint);
            _pers_line_list.Add(_info_new);


            //_dateString = ";;;;;";

            //1 _UPD 15 DEC 2019
            //string _update_string = "1 _UPD 31 DEC 9999";
            _comment_inside_code = "string _update_string = \"1 _UPD 31 DEC 9999\";";

            //if (_pe1_list[i].I_UPD.Length > 12)
            //{
            //    _update_string = N78_not_used_GetUpdateString("x _UPD " + _pe1_list[i].I_UPD);  // length must be more than 11
            //}
            //else
            //{
            //    _update_string = "x _UPD 31 DEC 9999";
            //}

            //if (_update_string != "0;not 4,8,10,11;;")
            //{
            //    //AddUpdateLine(_update_string, "INDI", _pers_line_text);
            //    Updates updatesNew = new(_update_string, "INDI", _pers_line_text);
            //    z_updates_list.Add(updatesNew);
            //}


            //CheckBox for empty birth date - OFF
            //if (_pe1_list[i].I_BIRT_DATE == " ")
            //{
            //    string index = _pe1_list[i].AA_I_INDEX.Replace("I",""); 
            //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
            //        + index;
            //    Console.WriteLine(_info_0_text);
            //    AddError("1231232", "INFO", _info_0_text);
            //}

            //CheckBox for empty birth date



            //if (_pe1_list[i].I_BIRT != " ")
            //{
            //_date = "," + _pe1_list[i].I_BIRT_DATE;
            //_dateString = ";;;;;";
            //_comment_inside_code = "_pe1_list[i].I_BIRT_DATE != \"\"";
            bool_event_yes = true;

            if (bool_event_yes && _pe1_list[i].I_BIRT_DATE != "")
            {
                _dateString = N60_GetDateString(_pe1_list[i].I_BIRT_DATE);
                //_place = _pe1_list[i].I_BIRT_PLAC;
                //_dio = "";
                //_cb = _pe1_list[i].I_BIRT_NOTE;
                _dateColl = _dateString.Split(';');
                _date_val = _dateColl[0];
                //if (_dateColl[3] != "not 4,8,10,11") 
                //    _day = _dateColl[3]; else _day = "";
                //_month = _dateColl[4];
                //_year = _dateColl[5];

                //_kind = "1-BIRTH";
                //z_event_new = new(0, _day, _month, _year, _date_val
                //    , "," + _pe1_list[i].I_BIRT_DATE, "1-BIRTH", _dio, _cb, _place
                //    , _pe1_list[i].AA_I_INDEX, _pe1_list[i].I_SEX, _pers_line_text);

                //z_info_new = new(_year + ";" + _month + ";" + _day + ";", "BIRTH", _pers_line_text
                z_info_new = new(_date_val/*  + z_tab*/, "BIRTH", _pers_line_text
                                        //+ z_tab + _pe1_list[i].I
                                        + z_tab + _pe1_list[i].I_BIRT_NOTE
                                        + z_tab + _pe1_list[i].I_NOTE

                    );
                z_birth_list.Add(z_info_new);

            }


            //if (bool_event_yes && _pe1_list[i].I_DEAT != "DEAT N")
            if (bool_event_yes)
            {
                if (_pe1_list[i].I_DEAT != "" || _pe1_list[i].I_BURI_PLAC != "")
                {
                    //_date = "," + _pe1_list[i].I_DEAT_DATE;
                    //_dateString = N60_GetDateString(_pe1_list[i].I_DEAT_DATE);

                    //_deathdateString = _dateString;
                    //_place = _pe1_list[i].I_DEAT_PLAC;
                    //_cb = _pe1_list[i].I_DEAT_NOTE;
                    //_dateColl = _dateString.Split(';');
                    //_date_val = _dateColl[0];
                    //if (_dateColl.Length > 3)
                    //{
                    //if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                    //_month = _dateColl[4];
                    //_year = _dateColl[5];
                    //}
                    //else
                    //{
                    //    Debugger.Break();
                    //}



                    //_kind = "4-DEATH";
                    //z_event_new = new(0, _day, _month, _year, _date_val, "," + _pe1_list[i].I_DEAT_DATE, "4-DEATH", _dio, _cb, _place
                    //    , _pe1_list[i].AA_I_INDEX, _pe1_list[i].I_SEX, _pers_line_text);

                    //z_info_new = new(_year +";"+ _month + ";" + _day + ";", "DEATH", _pers_line_text
                    _dateString = N60_GetDateString(_pe1_list[i].I_DEAT_DATE);

                    _dateColl = _dateString.Split(';');
                    _date_val = _dateColl[0];

                    sb = new(_pers_line_text, 128);
                    //sb.Append(z_tab);
                    //sb.Append(_pe1_list[i].I_DEAT_NOTE);
                    //sb.Append(z_tab);
                    //sb.Append(_pe1_list[i].I_BURI_PLAC);
                    //sb.Append(z_tab);
                    //sb.Append(_pe1_list[i].I_DEAT_CAUS);

                    sb.Append(string.Join(z_tab,
                    [
                        _pe1_list[i].I_DEAT_NOTE,
                        _pe1_list[i].I_BURI_PLAC,
                        _pe1_list[i].I_DEAT_CAUS
                    ]));
                    _pers_line_text = sb.ToString();

                    z_info_new = new(_date_val/* + z_tab*/, "DEATH", _pers_line_text);
                            //+ z_tab + _pe1_list[i].I
                            
                    z_death_list.Add(z_info_new);


                }
            }
            //if (bool_event_yes && _pe1_list[i].I_DEAT != "DEAT N")


            _comment_inside_code = "no event buri";
        }

        //A11_Save_PersLine();

        N11_Save("_fam_line_list", _fam_line_list, z_out_file_FamLine);

        N11_Save("_pers_line_list", _pers_line_list, z_out_file_PersLine);


        N11_Save("z_birth_list", z_birth_list, z_out_file_birth_list);

        N11_Save("z_death_list", z_death_list, z_out_file_death_list);




        //N11_Save("_album_line_list", z_album_line_list, z_out_file_AlbumLine);

        //N11_Save("_source_line_list", z_source_line_list, z_out_file_SourceLine);

        //N11_Save("_note_line_list", z_note_line_list, z_out_file_NoteLine);


        //_info_0_text = "_pers_line_list populated: " + _pers_line_list.Count;

        ////Xwrite("Step_2206", true, _info_0_text);
        ////Console.WriteLine(_info_0_text);
        ////    z_info_new = new("INFO;", ";", _info_0_text);
        ////    z_info_list.Add(z_info_new);

        //_info_0_text += z_newline + "EventList Birth populated    : " + z_birth_list.Count;

        ////Xwrite("Step_2208", true, _info_0_text);

        //_info_0_text += z_newline + "EventList death+buri populated    : " + z_death_list.Count;

        ////Xwrite("Step_2208", true, _info_0_text);

        ////_info_0_text += z_newline + "EventList Buri populated    : " + z_event_buri_list.Count;

        //Xwrite("Step_2208", true, _info_0_text);

        N11_Save("z_info_list", z_info_list, z_out_file_info_list);


        //SaveInfo(_path, "__ged_IN_info.txt");


        PlaySound();

        _info_0_text = z_newline + "Step_1706 - Press ENTER to finish !";
        Console.WriteLine(_info_0_text);
        //Trace.WriteLine(_info_0_text);

        //Console.ReadLine();

        _comment_inside_code = "end of > if (_pe1_list.Count > 0)";

        _comment_inside_code = "endofMain";
    }

    private static void PopulateFamList()
    {

        _count = 0;
        z_nextGoalOfLines = 2000;

        _comment_inside_code = "for (int i = 0; i < _fam_list.Count; i++)";
        string _fam_line_text;
        for (int i = 0; i < _fam_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate _fam_line_list ";
                Xwrite("Step_2603", true, _info_0_text);
                z_nextGoalOfLines += 1000;
            }


            _fam_line_text = "F-" + _fam_list[i].AA_F_INDEX
                + z_semicolon + _fam_list[i].F_HUSB
                + z_semicolon + _fam_list[i].F_WIFE

                + z_semicolon + _fam_list[i].F_MARR_DATE
                + z_semicolon + _fam_list[i].F_MARR_PLAC
                + z_semicolon + _fam_list[i].F_CHIL
                ;
            _fam_line_text = _fam_line_text.Replace("HUSBI", "");
            _fam_line_text = _fam_line_text.Replace("WIFEI", " oo ");
            _fam_line_text = _fam_line_text.Replace("CHILI", "KID-");


            Info _info_new = new(_fam_list[i].AA_F_INDEX, _fam_line_text, "");
            _fam_line_list.Add(_info_new);
        }
        //_fam_line_text = "";
    }

    private static void PopulateAlbumList()
    {
        _count = 0;
        z_nextGoalOfLines = 2000;
        string _album_line_text;
        _comment_inside_code = "for (int i = 0; i < _pe1_list.Count; i++)";

        for (int i = 0; i < z_album_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate z_album_list ";
                Xwrite("Step_2607", true, _info_0_text);
                z_nextGoalOfLines += 1000;
            }

            _album_line_text = "A- " + z_album_list[i].AA_A_INDEX
                + z_semicolon + z_album_list[i].A_TITL
                + z_semicolon + z_album_list[i].A_DESC
                ;

            Info _info_new = new(z_album_list[i].AA_A_INDEX, _album_line_text, "");
            z_album_line_list.Add(_info_new);
        }
        //_album_line_text = "";
    }

    private static void PopulateSourceList()
    {
        _info_0_text = "begin of Populate _source_line_list" + z_newline;
        //Xwrite("Step_1102", true, _info_0_text);



        _count = 0;
        z_nextGoalOfLines = 2000;
        string _source_line_text;

        _comment_inside_code = "for (int i = 0; i < z_source_list.Count; i++)";

        for (int i = 0; i < z_source_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate z_source_list ";
                Xwrite("Step_2617", true, _info_0_text);
                z_nextGoalOfLines += 1000;
            }

            _source_line_text = "S- " + z_source_list[i].AA_S_INDEX
                + z_semicolon + z_source_list[i].S_AUTH
                + z_semicolon + z_source_list[i].S_TITL
                + z_semicolon + z_source_list[i].S_TEXT
                ;

            Info _info_new = new(z_source_list[i].AA_S_INDEX, _source_line_text, "");
            z_source_line_list.Add(_info_new);
        }
        //_source_line_text = "";
    }

    private static void Report_Statistics()
    {
        // writing z_gedheadText
        _info_0_text = z_newline + z_newline + z_gedheadText + z_newline;
        Xwrite("Step_2204", true, _count + _info_0_text);
        //Console.WriteLine(z_newline + z_newline + z_gedheadText + z_newline);
        //z_info_new = new("INFO;", ";", _info_0_text);
        //z_info_list.Add(z_info_new);

        _comment_inside_code = "if (_pe1_list.Count > 0)";
        if (_pe1_list.Count > 0)
        {
            _info_0_text = "PERS-Count   ; " + _pe1_list.Count;
            Xwrite("Step_2211", true, _info_0_text);

            if (_fam_list.Count > 0)
            {
                _info_0_text = "FAM-Count    ; " + _fam_list.Count;
                Xwrite("Step_2212", true, _info_0_text);
            }
            if (z_note_list.Count > 0)
            {
                _info_0_text = "NOTE-Count   ; " + z_note_list.Count;
                Xwrite("Step_2213", true, _info_0_text);
            }
            if (z_album_list.Count > 0)
            {
                _info_0_text = "ALBUM-Count  ; " + z_album_list.Count;
                Xwrite("Step_2214", true, _info_0_text);
            }
            if (z_source_list.Count > 0)
            {
                _info_0_text = "SOURCE-Count ; " + z_source_list.Count;
                Xwrite("Step_2215", true, _info_0_text);
            }

            bool countfor = true;
            if (countfor == true)  // Count Section
            {
                string isEmptyString = " ";
                _info_0_text = "" + z_newline;
                _info_0_text += ";Step_2202:;Count for ;TOTAL      ;" + _pe1_list.Count(a => a.I_SEX != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_DATE;" + _pe1_list.Count(a => a.I_BIRT_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_PLAC;" + _pe1_list.Count(a => a.I_BIRT_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_DATE;" + _pe1_list.Count(a => a.I_DEAT_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_PLAC;" + _pe1_list.Count(a => a.I_DEAT_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BURI_PLAC;" + _pe1_list.Count(a => a.I_BURI_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_FAMS     ;" + _pe1_list.Count(a => a.I_FAMS != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_HUSB     ;" + _fam_list.Count(a => a.F_HUSB != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_WIFE     ;" + _fam_list.Count(a => a.F_WIFE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_DATE;" + _fam_list.Count(a => a.F_MARR_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_PLAC;" + _fam_list.Count(a => a.F_MARR_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_NOTE;" + _fam_list.Count(a => a.F_MARR_NOTE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_NOTE;" + _pe1_list.Count(a => a.I_BIRT_NOTE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_NOTE;" + _pe1_list.Count(a => a.I_DEAT_NOTE != isEmptyString) + z_newline;


                _info_0_text = _count + " > no counting";
                Xwrite("Step_2202", true, _info_0_text + z_newline);
                //Console.WriteLine(z_newline + z_newline + _info_0_text + z_newline);
                //z_info_new = new("INFO;", ";", _info_0_text);
                //z_info_list.Add(z_info_new);


            }
        }
    }
    static async Task Main()
    {
        _info_0_text = z_newline + "Step_1006 - Press ENTER to start !";
        Console.WriteLine(_info_0_text);
        //Trace.WriteLine(_info_0_text);

        _comment_inside_code = "ReadLine - Press ENTER to start";
        //Console.ReadLine();

        _comment_inside_code = "mainprog here";

        //string _path = "C:/DB/";
        //string _read_file = "__ged_IN";
        //string _extension = ".ged";

        //string z_0 = "";
        //string z_1 = "";
        //string z_2 = "";

        //int _int_peList = 1;

        //int _sw0_int = -1;
        //private static 
        //bool _bool_sex_u = false;
        //bool bool_nbsp = false;
        //bool boolChecknbsp = false;
        //bool boolCheckUnklar = false;
        //bool boolSaveSingleEntry = false;
        //string z_blank = "";
        //string _secondblankOrEnd;
        //string unknownKeyText = "unknown";
        //string z_gedheadText = z_in_file;
        //string _immi_text = "";

        //string _first = "";
        //string _update_string = "";
        //string _source_string = "";
        //string _entry_text = "";
        //int secondblankOrEnd = 0;
        z_nextGoalOfLines = _count + 1;

        //int _pe_list_index = -1;
        //int _fam_list_index = -1;

        //string _date;
        //string _place;
        //string _dio = "";
        //string _cb;
        //string keyPrevious_pe = "";
        //string keyPrevious_fam = "";
        //string keyPrevious_note = "";
        //string keyPrevious_album = "";
        //string keyPrevious_sour = "";
        //string keyPrevious_obj = "";
        //string keyPrevious_indi = "";

        //string _dateString = _entry_text + _immi_text + keyPrevious_note + keyPrevious_sour + z_in_file;
        //string _line_string = "";
        z_blank = "";
        //List<PersLine> _persLineList = [];

        //MessageBox.Show(" just test ....is missing" + Environment.NewLine + Environment.NewLine +
        //                    "Make sure you have the folder \\Resources !!", "WARNING",
        //                    MessageBoxButton.OK);




        //N05_DoAutosave(_all_fam_lines);
        //N11_Save("_all_fam_lines", _all_fam_lines, C:/ DB / _3_FAM_IN.ged);

        //N05_DoAutosave(_all_lines);
        //N11_Save("_pers_line_list", _pers_line_list, z_out_file_PersLine);

        N02_Print_Additional_checks();


        _comment_inside_code = " > clear Immediate Window manually";// + _source_string + _update_string;
        Xwrite("Step_8866", true, _comment_inside_code);

        _comment_inside_code = "Trace.WriteLine goes to Output inside VS while Console.Writeline goes to Prompt-Window";



        //_count = unknownKeyCount;


        //Do_All_lines(_all_lines);        auto

        List<string> _all_fam_lines = await Task.Run(() => N01_Read_Input(z_FAM_IN_file));

        N06_FAM_Lines(_all_fam_lines);


        List<string> _all_lines = await Task.Run(() => N01_Read_Input(z_INDI_IN_file));

        N07_INDI_Lines(_all_lines);

        //_count = 0;
        //z_nextGoalOfLines = 100000;


        //foreach (var _line in _all_lines)
        //{
        //    _count += 1;
        //    //Trace.WriteLine(_count + " > " + _line);

        //    //_info_0_text = _count + " > Orig.Line= > " + _line;
        //    //Console.WriteLine(_info_0_text);
        //    string _valueAdd = "";
        //    bool _line_used = true;

        //    Replace_stuff(_line, out string _line_string);

        //    _line_string = Replace_Months_Days(_line_string);

        //    _comment_inside_code = "Check input here" + "if (_line_string.Length == 0)" + "if (_count > z_nextGoalOfLines)";

        //    //_info_0_text = z_newline
        //    //    + "now > " + _line_string + z_newline
        //    //    + "org > " + _line
        //    //    + z_newline
        //    //    ;
        //    //Xwrite("Step_2205", true, _count + " > " + _info_0_text);

        //    //_comment_inside_code = "if (_line_string.Length == 0)";
        //    //if (_line_string.Length == 0)
        //    //{
        //    //    _info_0_text = " > " + _count + " > Line= > " + _line_string + " IS EMPTY           > Orig.= > " + _line;
        //    //    //Console.WriteLine(_info_0_text);
        //    //    Trace.WriteLine(_info_0_text);
        //    //    Debugger.Break();
        //    //    continue;
        //    //}

        //    //_comment_inside_code = "if (_count > z_nextGoalOfLines)";

        //    _first = _line_string[..1];//.ToString();
        //    _ = int.TryParse(_first, out int _first_int);

        //    secondblankOrEnd = N72_Get_2nd_blank(1, _line_string);

        //    _comment_inside_code = "firstchar=0";


        //    switch (_first_int)
        //    {
        //        case 0:

        //            if (_count > z_nextGoalOfLines)
        //            {
        //                _info_0_text = "Step_1400 > " + DateTime.Now
        //                    + " > " + z_nextGoalOfLines / 1000 + " TSD > Line= > " + _line_string + "           > Orig.= > " + _line;
        //                Xwrite("INFO", true, _info_0_text);
        //                //Trace.WriteLine(_info_0_text);
        //                //z_info_new = new("INFO;", ";", _info_0_text);
        //                //z_info_list.Add(z_info_new);

        //                z_nextGoalOfLines += 50000;
        //            }


        //            if (_pe1_list.Count > 10)
        //            {
        //                _pe2_list.AddRange(_pe1_list);

        //                _pe1_list.Clear();
        //            }

        //            //switch (_pe1_list.Count)
        //            //{
        //            //    case > 200:
        //            //        _int_peList = 3;
        //            //        Console.WriteLine("_int_peList = 3;");
        //            //        break;
        //            //    case > 100:
        //            //        _int_peList = 2;
        //            //        Console.WriteLine("_int_peList = 2;");
        //            //        break;
        //            //    case > 0:
        //            //        _int_peList = 1;
        //            //        Console.WriteLine("_int_peList = 1;");
        //            //        break;
        //            //}


        //            //_first = _line_string.[..1].ToString();
        //            //_comment_inside_code = "SAVE TIME";

        //            //_comment_inside_code = "here: for all lines";

        //            //_first = _line_string[..1];//.ToString();


        //            //if (_line_string.Contains("DAH+"))
        //            //    _source_string = "_DAH_85244";

        //            //if (_line_string.Contains("Jaubert Family Tree"))
        //            //    _source_string = "Sylvie";

        //            //if (_line_string.Contains("Family Tree Builder"))
        //            //    _source_string = "FTP-Export";


        //            _comment_inside_code = "SAVE TIME" + " > here: for all lines" + " > _line_string.Contains(\"UPD\")";
        //            //if (_line_string.Contains("UPD"))  // for header
        //            //{
        //            //    //_update_string = N78_not_used_GetUpdateString(_line_string);
        //            //    _update_string = _line_string;
        //            //}

        //            //if (_line_string == "2 AGE 74")
        //            //{
        //            //    //Debugger.Break();
        //            //}



        //            _comment_inside_code = "_entry_text += keyPrevious_pe + \";\" + _line_string + \" > \";";
        //            //if (_first_int != 0)
        //            //{
        //            //    //_entry_text += keyPrevious_pe + ";" + _line_string + " > ";
        //            //}



        //            // Works


        //            _entry_text = "";
        //            //Console.WriteLine("keyPrevious {0}, _entry_text {1}, _update_string {2}, _source_string {3}", 
        //            //    keyPrevious_pe, _entry_text, _update_string, _source_string);

        //            _comment_inside_code = "output for each single entry to _GED_OUT folder";
        //            //if (z_slow > 8 && boolSaveSingleEntry == false)
        //            //{
        //            //    _info_0_text = z_slow + ";NO;no output for each single entry to _GED_OUT folder";
        //            //    Xwrite("Step_8900", true, _line_string);

        //            //    boolSaveSingleEntry = true;
        //            //}
        //            //else
        //            //{


        //            //    if (z_slow < 2 && keyPrevious_pe != null && keyPrevious_pe != "")
        //            //    {
        //            //        _info_0_text = "SaveEntry = eine Datei je ID-Nummer";
        //            //        //SaveEntry(keyPrevious, _entry_text, _update_string, _source_string); // ein 
        //            //        boolSaveSingleEntry = true;
        //            //    }
        //            //}






        //            //int _first_blank = 1;


        //            // _first_blank
        //            // Replace this unsafe block:
        //            // if (_line_string.Contains(' ')) _first_blank = _line_string.IndexOf(' ');
        //            // int start = _first_blank + 1;
        //            // int stopp = _line_string.Length - start - 1;
        //            // secondblankOrEnd = _line_string.Substring(start, stopp).IndexOf(' ') + 2;
        //            // if (secondblankOrEnd < 2)
        //            //     secondblankOrEnd = _line_string.Length - 2;

        //            // With this safe code:
        //            //_comment_inside_code = "NO find _first_blank";
        //            //if (_line_string.Contains(' '))
        //            //{
        //            //    _first_blank = _line_string.IndexOf(' ');
        //            //}
        //            //else
        //            //{
        //            //    _first_blank = -1;
        //            //}

        //            // Find second space index robustly

        //            //int secondblankOrEnd;



        //            //if (/*_first_blank >= 0 &&*/ _first_blank + 1 < _line_string.Length)
        //            //{
        //            //    secondSpaceIndex = _line_string.IndexOf(' ', _first_blank + 1);
        //            //}

        //            //// Use line end when second space not found
        //            //if (secondSpaceIndex == -1)
        //            //{
        //            //    // no second space -> treat as end of line
        //            //    secondblankOrEnd = _line_string.Length;
        //            //}
        //            //else
        //            //{
        //            //    secondblankOrEnd = secondSpaceIndex;
        //            //}
        //            //if (SecondBlankOrEnd == 4 )  // only e.g. BIRT, nothing more
        //            //    SecondBlankOrEnd = 0;
        //            //Console.WriteLine("_first_blank = {0}, = {1}, {2}", _first_blank, secondblankOrEnd, _line_string);


        //            // Example
        //            // 0123456789
        //            // 2 DATE 9 DEC 1939
        //            // 1 SEX M



        //            if (_line_string.Substring(2, 4).ToString() == "HEAD")
        //            {
        //                z_0 = "H_";
        //                //_sw0_int = 0;
        //                z_key = "HEAD";
        //                keyPrevious_pe = z_key;
        //                //continue;
        //            }

        //            _comment_inside_code = "ab hier U_";
        //            //if (_line_string.Substring(2, 2).ToString() == @"@U")
        //            //{
        //            //    z_0 = "U_";
        //            //    Console.WriteLine("#### skipped 'U' = {0}", _line_string);
        //            //    //continue;
        //            //}

        //            // NOTE
        //            _comment_inside_code = "ab hier notes";
        //            //if (_line_string.EndsWith("NOTE"))
        //            //{
        //            //    z_0 = "N_";
        //            //    //Console.WriteLine("#### skipped 'NOTE' = {0}", _line_string);

        //            //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //            //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //            //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
        //            //    z_key = z_key.Replace("@", "");
        //            //    keyPrevious_note = z_key;

        //            //    Note noteNew = new(keyPrevious_note, z_blank, z_blank, z_blank);
        //            //    z_note_list.Add(noteNew);
        //            //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
        //            //    //continue;
        //            //}


        //            // INDI
        //            //int _pe_index_count = 0;
        //            if (_line_string.EndsWith("INDI"))  // not TRLR = each entry
        //            {
        //                z_0 = "I_";
        //                //_sw0_int = 1;

        //                //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //                z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
        //                z_key = N61_CleanID(z_key);
        //                keyPrevious_indi = z_key;
        //                //keyPrevious_indi = z_key;
        //                if (keyPrevious_indi == "")
        //                {
        //                    keyPrevious_indi = " ";
        //                }

        //                Pe peNew = new(keyPrevious_indi
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 11
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 21
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 31
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 41
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 51


        //                    );
        //                //if (_count < 11300000)
        //                //{
        //                //switch (_int_peList)
        //                //{
        //                //    case 1: _pe1_list.Add(peNew); break;
        //                //    case 2: _pe2_list.Add(peNew); break;
        //                //    case 3: _pe3_list.Add(peNew); break;
        //                //    case 4: _pe4_list.Add(peNew); break;
        //                //default:
        //                //        break;
        //                //}
        //                _pe1_list.Add(peNew);
        //                //}
        //                //else
        //                //{
        //                _comment_inside_code = "pe2_list";
        //                //    _pe2_list.Add(peNew);
        //                //}

        //                // record index for fast lookup
        //                _pe1_index[keyPrevious_indi] = _pe1_list.Count - 1;
        //                //_pers_text_coll_global.Clear();
        //                //Console.WriteLine("adding = {0}", keyPrevious);
        //                //continue;
        //            }

        //            // FAM
        //            _comment_inside_code = "ab hier families";
        //            //int _fam_index_count = 0;
        //            if (_line_string.EndsWith("FAM"))
        //            {
        //                z_0 = "F_";
        //                //_sw0_int = 2;
        //                //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //                z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
        //                z_key = N61_CleanID(z_key);
        //                keyPrevious_fam = z_key;

        //                Fam famNew = new(keyPrevious_fam
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 11//
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 21
        //                    , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//,
        //                    );


        //                // record index for fast lookup
        //                _fam_list.Add(famNew);
        //                _fam_index[keyPrevious_fam] = _fam_list.Count - 1;
        //                //Console.WriteLine("adding FAM = {0}", keyPrevious);
        //                //continue;
        //            }

        //            _pe_list_index = _pe1_index.GetValueOrDefault(keyPrevious_indi, -1);
        //            _fam_list_index = _fam_index.GetValueOrDefault(keyPrevious_fam, -1);
        //            int _note_list_index = 0;
        //            //int _source_list_index = z_source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious_sour);
        //            int _source_list_index = 0;
        //            //int _album_list_index = z_album_list.FindIndex(item => item.AA_A_INDEX == keyPrevious_album);
        //            int _album_list_index = 0;
        //            z_lastPeListIndex_DONE = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
        //            //int lastPeListIndex = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
        //            //else
        //            //{
        //            //    unknownKeyCount += 1;
        //            //    keyPrevious = z_key;
        //            //    //z_lastPeListIndex_DONE = z_lastPeListIndex;
        //            //    //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        //            //    //_pe1_list.Add(peNew);
        //            //    z_key = "unknownKeyCount" + unknownKeyCount.ToString();

        //            //}

        //            _comment_inside_code = "ab hier ALBUM";
        //            //ALBUM
        //            //if (_line_string.EndsWith("ALBUM"))
        //            //{
        //            //    z_0 = "A_";
        //            //    //Console.WriteLine("#### skipped 'ALBUM' = {0}", _line_string);

        //            //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //            //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
        //            //    z_key = z_key.Replace("@", "");

        //            //    if (z_album_list.FindIndex(item => item.AA_A_INDEX == z_key) > -1)
        //            //    {
        //            //        z_key += "2";
        //            //    }

        //            //    keyPrevious_album = z_key;

        //            //    Album albumNew = new(keyPrevious_album, z_blank, z_blank, z_blank, z_blank);
        //            //    z_album_list.Add(albumNew);
        //            //    //Console.WriteLine("adding ALBUM = {0}", keyPrevious);
        //            //    //continue;
        //            //}

        //            _comment_inside_code = "ab hier end of file";
        //            //if (_line_string.EndsWith("TRLR"))
        //            //{
        //            //    z_0 = "END_";
        //            //    //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
        //            //    _info_0_text = "TRLR = End of file > " + _count;
        //            //    Xwrite("Step_9985", true, _info_0_text);
        //            //    //continue;
        //            //}


        //            //string keyPrevious_sour = "";
        //            _comment_inside_code = "ab hier sources";
        //            //if (_line_string.EndsWith("SOUR"))  // SOUR
        //            //{
        //            //    z_0 = "S_";
        //            //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
        //            //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
        //            //    z_key = z_key.Replace("@", "");
        //            //    keyPrevious_sour = z_key;

        //            //    Source sourceNew = new(keyPrevious_sour, z_blank, z_blank, z_blank);//, z_blank, z_blank, z_blank, z_blank);
        //            //    z_source_list.Add(sourceNew);
        //            //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
        //            //    //continue;
        //            //}


        //            z_lastPeListIndex_DONE = z_lastPeListIndex - 1;
        //            //}
        //            _comment_inside_code = "End of:  if (_first == 0";


        //            //_pe3_index.Clear();
        //            //for (int i = 0; i < _pe1_list.Count; i++)
        //            //{
        //            //    _pe3_index.Add(_pe1_list[i].AA_I_INDEX, i);
        //            //}

        //            //_fam_index.Clear();
        //            //for (int i = 0; i < _fam_list.Count; i++)
        //            //{
        //            //    _fam_index.Add(_fam_list[i].AA_F_INDEX, i);
        //            //}


        //            //if (_pe3_index.TryGetValue(keyPrevious_pe, out int value_pe))
        //            //{
        //            //    _pe_list_index = value_pe;
        //            //}

        //            //int _fam_list_index = 0;// = _pe1_list.FindIndex(item => item.AA_I_INDEX == keyPrevious);
        //            //if (_fam_index.TryGetValue(keyPrevious_fam, out int value_fam))
        //            //{
        //            //    _fam_list_index = value_fam;
        //            //}

        //            //_pe3_index.Add(_pe1_list[_pe_list_index].AA_I_INDEX, _pe_list_index);

        //            //int z_lastPeListIndex_DONE;

        //            //_fam_index.Add(_fam_list[_pe_list_index].AA_F_INDEX, _pe_list_index);
        //            //int _note_list_index = z_note_list.FindIndex(item => item.AA_N_INDEX == keyPrevious_note);

        //            //_pe1_list.Add(peNew);

        //            break;





        //        case 1:
        //            _comment_inside_code = "first = 1";
        //            //#region _first_int == 1"

        //            if (_line_string.Length > 5)
        //                z_1 = z_0 + _line_string.Substring(2, 4).Trim(); // + z_separator;
        //            else
        //                z_1 = z_0 + _line_string.Substring(2, 3).Trim(); // + z_separator;

        //            //_valueAdd = "";
        //            //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
        //            //if (_line_string.Length != z_1.Length + 2)
        //            //{

        //            //z_1 + z_separator +  // without
        //            //_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;

        //            //}

        //            //_valueAdd = z_1.Substring(secondblankOrEnd + 1, z_1.Length - secondblankOrEnd - 1) + z_separator;

        //            int z_1_length = z_1.Length + 1;

        //            if (_line_string.Length > z_1.Length)
        //            {
        //                _valueAdd = _line_string[z_1_length..];
        //                //_valueAdd = _line_string[2..];
        //            }

        //            //if (_valueAdd == "ENGA") _valueAdd = "verlobt";
        //            //if (_valueAdd == "MARL") _valueAdd = "StAmt";

        //            //else { _valueAdd}
        //            //z_value += CleanText(_valueAdd);
        //            //z_value += _valueAdd;

        //            //_valueAdd = CleanText(_valueAdd);
        //            //_valueAdd = CleanText(_valueAdd);

        //            if (z_0 == "I_")
        //            {
        //                //Xwrite("",true,_line_string);

        //                switch (z_1)
        //                {
        //                    // FAM
        //                    //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
        //                    //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
        //                    case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
        //                    case "F_RIN ": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
        //                    case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    //case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    case "I_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    case "I__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
        //                    ////case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
        //                    case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
        //                    //case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
        //                    //case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
        //                    //case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
        //                    //                                                                     //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;
        //                    //                                                                     //case "F_EVEN": _fam_list[_fam_list_index].F_EVEN = _valueAdd; break;

        //                    //// SOURCE
        //                    ////case "S_AUTH": z_source_list[_source_list_index].S_AUTH = _valueAdd; break;
        //                    ////case "S_TITL": z_source_list[_source_list_index].S_TITL = _valueAdd; break;
        //                    ////case "S_PUBL": z_source_list[_source_list_index].S_PUBL = _valueAdd; break;
        //                    ////case "S_TEXT": z_source_list[_source_list_index].S_TEXT = _valueAdd; break;
        //                    ////case "S__TYP": /*z_source_list[_source_list_index].S__TYP = _valueAdd;*/ break;
        //                    ////case "S__MED": z_source_list[_source_list_index].S__MED = _valueAdd; break;

        //                    //// ALBUM = Photos
        //                    ////case "S_AUTH": z_album_list[_album_list_index].S_AUTH = _valueAdd; break;
        //                    ////case "A_TITL": z_album_list[_album_list_index].A_TITL = _valueAdd; break;
        //                    ////case "A_DESC": z_album_list[_album_list_index].A_DESC = _valueAdd; break;
        //                    ////case "S_TEXT": z_album_list[_album_list_index].S_TEXT = _valueAdd; break;
        //                    case "A__UPD": /*z_album_list[_album_list_index].A__UPD = _valueAdd;*/ break;
        //                    case "A_RIN": /*z_album_list[_album_list_index].A_RIN = _valueAdd;*/ break;


        //                    //// INDI
        //                    case "I_NAME": /*_pe1_list[_pe_list_index].I_NAME = _valueAdd;*/ break;
        //                    ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
        //                    ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
        //                    ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
        //                    case "I_SEX":
        //                        _pe1_list[_pe_list_index].I_SEX = _valueAdd;
        //                        //if (z_slow > 0)
        //                        //{
        //                        //    if (_bool_sex_u == false && _valueAdd.Contains("U"))// || _valueAdd.Contains("") || _valueAdd.Contains(" "))
        //                        //    {
        //                        //        errortext = z_blank + "SEX contains U"
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_SEX
        //                        //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
        //                        //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
        //                        //            ;
        //                        //        Console.WriteLine(errortext);
        //                        //        AddError(_count.ToString(), "SEX contains U", errortext);
        //                        //    }
        //                        //}
        //                        //else
        //                        //if (z_slow == 0 && _bool_sex_u == false)
        //                        //{
        //                        //    _info_0_text = z_slow + "; NO_0009;no check for *SEX contains U*";
        //                        //    Xwrite("Step_9905", true, _info_0_text);

        //                        //    _bool_sex_u = true;
        //                        //}
        //                        break;
        //                    case "I_BIRT": /*_pe1_list[_pe_list_index].I_BIRT = _valueAdd;*/ break;
        //                    case "I_DEAT":
        //                        _pe1_list[_pe_list_index].I_DEAT = _valueAdd;

        //                        if (_valueAdd == "DEAT Y")
        //                            _pe1_list[_pe_list_index].I_SEX += "d";
        //                        else
        //                            _pe1_list[_pe_list_index].I_SEX += "a";

        //                        break;

        //                    case "I_BURI": /*_pe1_list[_pe_list_index].I_BURI = _valueAdd;*/ break;
        //                    case "I_FAMS": _pe1_list[_pe_list_index].I_FAMS += "Sp:F" + N61_CleanID(_valueAdd[1..]) + " # "/* + z_ht*/; break;
        //                    case "I_FAMC": _pe1_list[_pe_list_index].I_FAMC += "C:F" + N61_CleanID(_valueAdd[1..]) + " # "; break;


        //                    case "I_RESI": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;
        //                    //case "I_ADDR": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;  // same like RESI ??
        //                    //case "I_CONF": /*_pe1_list[_pe_list_index].I_CONF = _valueAdd;*/ break;
        //                    case "I_RELI": _pe1_list[_pe_list_index].I_RELI = _valueAdd; break;
        //                    case "I_OCCU": _pe1_list[_pe_list_index].I_OCCU = _valueAdd; break;
        //                    //case "I_CENS": /*_pe1_list[_pe_list_index].I_CENS = _valueAdd;*/ break;
        //                    case "I_NOTE": _pe1_list[_pe_list_index].I_NOTE = _valueAdd; break;

        //                    case "I_RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
        //                    //case "I__UID": /*_pe1_list[_pe_list_index].I__UID = _valueAdd;*/ break;

        //                    case "S_RIN": /*z_source_list[_source_list_index].S_RIN = _valueAdd;*/ break;
        //                    case "S__UID": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

        //                    //case "I_ORDN": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

        //                    case "I_RIN ": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
        //                    case "I__RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
        //                    case "I_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

        //                    case "I__UPD": /*_pe1_list[_pe_list_index].I_UPD = _valueAdd;*/ break;
        //                    //case "I_CHAN": _pe1_list[_pe_list_index].I_UPD = "### Change instead UPD ### " + _valueAdd; break;
        //                    //case "N_CONC": z_note_list[_note_list_index].N_CONC = _valueAdd; break;
        //                    //case "N_PRIN": z_note_list[_note_list_index].N_PRIN = _valueAdd; break;
        //                    case "N_RIN ": /*z_note_list[_note_list_index].N_RIN = _valueAdd;*/ break;
        //                    case "N_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

        //                    //case "I_EVEN": /*_pe1_list[_pe_list_index].I_EVEN = _valueAdd;*/ break;
        //                    case "I_EMIG": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
        //                    case "I_IMMI": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;

        //                    //case "I_NATI": /*_pe1_list[_pe_list_index].I_NATI = _valueAdd;*/ break;


        //                    case "I_SOUR": /*_pe1_list[_pe_list_index].I_SOUR = _valueAdd;*/ break;

        //                    case "I_OBJE": /*_pe1_list[_pe_list_index].I_OBJE = _valueAdd;*/ break;

        //                    case "I_MARR": _pe1_list[_pe_list_index].I_MARR = _valueAdd; break;
        //                    //case "I_DIV ": _pe1_list[_fam_list_index].I_DIV = _valueAdd; break;
        //                    //case "I_NATI": _pe1_list[_pe_list_index].I_NATI = _valueAdd; break;

        //                    default: _line_used = false; break;
        //                }
        //            }


        //            _comment_inside_code = "Families";
        //            if (z_0 == "F_")
        //            {
        //                switch (z_1)
        //                {
        //                    // FAM
        //                    case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = _valueAdd; break;
        //                    //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
        //                    case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = _valueAdd; break;
        //                    //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
        //                    case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
        //                    case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
        //                    case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += _valueAdd + " # "; break;
        //                    //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
        //                    //case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
        //                    case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
        //                    case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
        //                    case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
        //                    case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
        //                                                                                         //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;


        //                    default: _line_used = false; break;
        //                }
        //            }
        //            _comment_inside_code = "End of:  if (_first == 1";
        //            // end of : if (_first_int == 1")
        //            //#endregion _first = 1

        //            if (z_0 != "I_" && z_0 != "F_")
        //            {
        //                switch (z_1)
        //                {
        //                    case "H_FILE": z_gedheadText += _valueAdd; break;
        //                    //case "H_DATE": z_gedheadText += _valueAdd; break;
        //                    //case "H_GEDC": z_gedheadText += _valueAdd; break;
        //                    //case "H_CHAR": z_gedheadText += _valueAdd; break;
        //                    //case "H_LANG": z_gedheadText += _valueAdd; break;
        //                    //case "H_SOUR": z_gedheadText += _valueAdd; break;
        //                    //case "H_DEST": z_gedheadText += _valueAdd; break;
        //                    //case "H__PRO": /*z_gedheadText += _valueAdd;*/ break;
        //                    //case "H__EXP": /*z_gedheadText += _valueAdd;*/ break;
        //                    //case "H_FILE": z_gedheadText += _valueAdd; break;

        //                    default: _line_used = false; break;


        //                }
        //            }

        //            break;


        //        //#region _first = 2
        //        //_first_int == 2"
        //        case 2:

        //            z_2 = _line_string.Substring(2, 4);

        //            _valueAdd = "";
        //            //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
        //            if (_line_string.Length > 6)
        //            {
        //                //_valueAdd =_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;
        //                _valueAdd = _line_string[secondblankOrEnd..];
        //                //z_0 + z_1 + z_separator + "-" + z_2 + z_separator + // without
        //            }


        //            //_valueAdd = CleanText(_valueAdd);
        //            //_valueAdd = CleanText(_valueAdd);

        //            //z_value += _valueAdd;
        //            z_value += _valueAdd + z_separator;

        //            string _z0z1z2 = z_0 + z_1 + "_" + z_2;

        //            bool boolCheckGIVEN = false;

        //            if (z_0 == "I_")
        //            {

        //                switch (_z0z1z2)
        //                {
        //                    //// FAM
        //                    //case "F_F_MARR_DATE": _fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; break;
        //                    //case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
        //                    //case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
        //                    ////case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
        //                    ////case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
        //                    //case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
        //                    //case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
        //                    //case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
        //                    ////case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
        //                    ////case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
        //                    //case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
        //                    //// MARL
        //                    //case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
        //                    //case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
        //                    //case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
        //                    //// DIV
        //                    //case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
        //                    //case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
        //                    //case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
        //                    //// ENGA
        //                    //case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
        //                    //case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
        //                    //case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
        //                    //// ANUL
        //                    //case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
        //                    //case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
        //                    //case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

        //                    //    // SOUR

        //                    //case "S_S_SOUR_CONC": z_source_list[_source_list_index].S_SOUR_CONC = _valueAdd; break;
        //                    //case "S_S_TEXT_CONC": z_source_list[_source_list_index].S_TEXT_CONC = _valueAdd; break;


        //                    // HEADER
        //                    //case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;

        //                    //case "H_H_DEST": z_gedheadText += _valueAdd; break;
        //                    //case "H_H__PRO": z_gedheadText += _valueAdd; break;



        //                    // ALBUM
        //                    //case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
        //                    //case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;




        //                    case "I_I_BIRT_DATE":
        //                        if (_valueAdd.Length == 9)
        //                        {
        //                            _pe1_list[_pe_list_index].I_BIRT_DATE = ",0" + _valueAdd;
        //                        }
        //                        else
        //                        {
        //                            _pe1_list[_pe_list_index].I_BIRT_DATE = "," + _valueAdd;
        //                        }
        //                        //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
        //                        //break;
        //                        //_pe1_list[_pe_list_index].I_BIRT_DATE = _valueAdd;
        //                        break;
        //                    case "I_I_NAME_GIVN":
        //                        _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
        //                        _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

        //                        if (boolCheckGIVEN == false)
        //                        {
        //                            boolCheckGIVEN = true;
        //                            //if (z_slow < 2)
        //                            //{
        //                            //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
        //                            //    {
        //                            //        if (DontCheck_Given(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
        //                            //        {
        //                            //            errortext = separator + "GIVEN contains ..."
        //                            //                + separator + _pe1_list[_pe_list_index].I_NAME_NSFX
        //                            //                + "verh.;" + _pe1_list[_pe_list_index].I_NAME_MARNM
        //                            //                + separator + _pe1_list[_pe_list_index].I_NAME_SURN
        //                            //                + separator + _pe1_list[_pe_list_index].I_NAME_GIVN
        //                            //                + separator + _pe1_list[_pe_list_index].AA_I_INDEX
        //                            //                ;
        //                            //            Console.WriteLine(errortext);
        //                            //            AddError(_count.ToString(), "CHECKING", errortext);
        //                            //        }
        //                            //    }
        //                            //}
        //                            //else
        //                            //{
        //                            //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0008;CheckGiven: no output for each single entry";
        //                            //    Console.WriteLine(_info_0_text);
        //                            //    z_info_new = new("INFO;", ";", _info_0_text);

        //                            //    //boolCheckGIVEN = true;
        //                            //}
        //                        }
        //                        break;
        //                    case "I_I_NAME_NICK": _pe1_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
        //                    case "I_I_NAME__MAR": _pe1_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
        //                    case "I_I_NAME_SURN": _pe1_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

        //                    case "I_I_NAME_NPFX": _pe1_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
        //                    case "I_I_NAME__FOR": _pe1_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

        //                    case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
        //                    //case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    //case "I_I_BIRT_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    //case "I_I_BIRT__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
        //                    case "I_I_BIRT_NOTE": /*_valueAdd = _valueAdd.Replace(";", "#");*/ _pe1_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

        //                    case "I_I_DEAT_DATE":
        //                        if (_valueAdd.Length == 9)
        //                        {
        //                            _pe1_list[_pe_list_index].I_DEAT_DATE = ",0" + _valueAdd;
        //                        }
        //                        else
        //                        {
        //                            _pe1_list[_pe_list_index].I_DEAT_DATE = "," + _valueAdd;
        //                        }
        //                        //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
        //                        break;
        //                    case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
        //                    //case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    case "I_I_DEAT_CAUS": _pe1_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
        //                    //case "I_I_DEAT_AGE ": /*_pe1_list[_pe_list_index].I_DEAT_AGE = _valueAdd;*/ break;
        //                    //case "I_I_DEAT__UID": /*_pe1_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
        //                    //case "I_I_DEAT_RIN ": /*_pe1_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
        //                    case "I_I_DEAT_NOTE": /*_valueAdd = _valueAdd.Replace(";", "#");*/ _pe1_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
        //                    //case "I_I_BURI_DATE": /*_pe1_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
        //                    case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
        //                    //case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    //case "I_I_BURI_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    //case "I_I_BURI__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

        //                    //case "I_I_DIV_DATE": _pe1_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
        //                    //case "I_I_DIV_PLAC": _pe1_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
        //                    //case "I_I_RESI_EMAI": /*_pe1_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
        //                    //case "I_I_BAPM_PLAC": /*_pe1_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
        //                    //case "I_I_BAPM_DATE": /*_pe1_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
        //                    //case "I_I_CONF_PLAC": /*_pe1_list[_pe_list_index].I_CONF_PLAC = _valueAdd;*/ break;
        //                    //case "I_I_CONF_DATE": /*_pe1_list[_pe_list_index].I_CONF_DATE = _valueAdd;*/ break;

        //                    case "I_I_OCCU_DATE": _pe1_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
        //                    case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
        //                    //case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    //case "I_I_OCCU_AGE ": /*_pe1_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

        //                    //case "I_I_CENS_PLAC": /*_pe1_list[_pe_list_index].I_CENS_PLAC = _valueAdd;*/ break;
        //                    //case "I_I_CENS_DATE": /*_pe1_list[_pe_list_index].I_CENS_DATE = _valueAdd;*/ break;



        //                    //case "I_I_RESI_DATE": /*_pe1_list[_pe_list_index].I_RESI_DATE = _valueAdd;*/ break;
        //                    //case "I_I_RESI_AGE ": /*_pe1_list[_pe_list_index].I_RESI_AGE = _valueAdd;*/ break;

        //                    //case "I_I_ADDR_CONT": /*_pe1_list[_pe_list_index].I_RESI_ADDR = "Adress available";*/ break; // same like RESI ?
        //                    //case "I_I_RESI_ADDR": /*_pe1_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

        //                    //case "I_I_RESI_PLAC": _pe1_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
        //                    //case "I_I_RESI_PHON": _pe1_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
        //                    //case "I_I_RESI_FAX ": /*_pe1_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
        //                    //case "I_I_RESI_NOTE": /*_pe1_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
        //                    case "I_I_FAMC_PEDI": _pe1_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

        //                    case "I_I_EVEN_DATE": _pe1_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
        //                    case "I_I_EVEN_NOTE": _pe1_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
        //                    //case "I_I_EVEN_AGE ": /*_pe1_list[_pe_list_index].I_EVEN_AGE = _valueAdd;*/ break;

        //                    //case "I_I_EVEN__UID": /*_pe1_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
        //                    //case "I_I_EVEN_RIN ": /*_pe1_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
        //                    case "I_I_EVEN_TYPE": _pe1_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
        //                    case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;
        //                    //case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

        //                    case "I_I_EMIG_DATE": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
        //                    case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;
        //                    //case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

        //                    case "I_I_IMMI_DATE": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;
        //                    case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;
        //                    //case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

        //                    //case "I_I_SOUR_DATA": /*_pe1_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
        //                    //case "I_I_SOUR_EVEN": /*_pe1_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
        //                    //case "I_I_SOUR_PAGE": /*_pe1_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
        //                    //case "I_I_SOUR_QUAL": /*_pe1_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
        //                    //case "I_I_SOUR_QUAY": /*_pe1_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
        //                    //case "I_I_SOUR_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    //case "I_I_SOUR__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


        //                    case "I_I_OBJE_FORM": _pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe1_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
        //                    //case "I_I_OBJE_FILE": /*_pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
        //                    //case "I_I_OBJE_TITL": /*_pe1_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
        //                    //case "I_I_OBJE_NOTE": /*_pe1_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PRI": /*_pe1_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__CUT": /*_pe1_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PAR": /*_pe1_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PER": /*_pe1_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PHO": /*_pe1_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__POS": /*_pe1_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__DAT": /*_pe1_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__ALB": /*_pe1_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__FIL": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
        //                    ////case "I_I_OBJE__PLA": /*_pe1_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


        //                    //case "I_I_ORDN_DATE": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


        //                    case "I_I_DATE_TIME": _pe1_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
        //                    case "I_I_CHAN_DATE": _pe1_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
        //                    case "I_I_NOTE_CONC": _pe1_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
        //                    //case "I_I_FILE": z_gedheadText += _valueAdd; break;

        //                    case "I_I_NAME_NSFX":
        //                        _pe1_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

        //                        //if (z_slow > 0)
        //                        //{
        //                        //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
        //                        //    {
        //                        //        if (DontCheck_NSFX(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
        //                        //        {
        //                        //            _info_0_text = z_blank //+ "____________________"
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_NSFX
        //                        //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
        //                        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
        //                        //            //+ " born: " + _pe1_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
        //                        //            //+ " marr: " + _pe1_list[_pe_list_index].I_MARR_DATE
        //                        //            //+ " died: " + _pe1_list[_pe_list_index].I_DEAT_DATE
        //                        //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
        //                        //            ;
        //                        //            Console.WriteLine(_info_0_text);
        //                        //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
        //                        //        }
        //                        //    }
        //                        //}
        //                        break;

        //                    //if (_pe1_list[_pe_list_index].I_BIRT_DATE == "")
        //                    //{
        //                    //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe1_list[_pe_list_index].AA_I_INDEX;
        //                    //    Console.WriteLine(_info_0_text);
        //                    //    AddError("1231232", "INFO", _info_0_text);

        //                    //    _pe1_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
        //                    //}


        //                    default:
        //                        //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
        //                        //if (_z0z1z2 != "F_F_MARR_ADDR" || _z0z1z2 != "H_H__NAV__NAV" || _z0z1z2 != "H_H_DATE_TIME")
        //                        unknownKeyText = z_newline + "z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd;
        //                        //Console.WriteLine(/*z_newline + */"z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);
        //                        //   >> message below

        //                        // z_2 ignored

        //                        //if (_z0z1z2 == "H_H_DATE_TIME") unknownKeyText = "";
        //                        //if (_z0z1z2 == "H_H_DATE__TIM") unknownKeyText = "";
        //                        //if (_z0z1z2 == "H_H_SOUR__TRE") unknownKeyText = "";
        //                        //if (_z0z1z2 == "H_H__NAV__NAV") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_MARR_ADDR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_OCCU__UID") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_OCCU_RIN ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_RESI__UID") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_RESI_RIN ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_RESI_TYPE") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_RESI_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_NAME_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_BIRT_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_BAPM_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_DEAT_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_BURI_SOUR") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_DIV__UID") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_DIV_RIN ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_ENGA__UID") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_ENGA_RIN ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_MARL__UID") unknownKeyText = "";
        //                        //if (_z0z1z2 == "F_F_MARL_RIN ") unknownKeyText = "";

        //                        //if (_z0z1z2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
        //                        //if (_z0z1z2 == "I_I_SOUR_DATA ") unknownKeyText = "";


        //                        //if (unknownKeyText != "")
        //                        //    Console.WriteLine(/*z_newline + */"Unknown z_key at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);

        //                        break;

        //                }
        //            }

        //            if (z_0 == "F_")
        //            {

        //                switch (_z0z1z2)
        //                {
        //                    // FAM
        //                    case "F_F_MARR_DATE":
        //                        if (_valueAdd.Length == 9)
        //                        {
        //                            _fam_list[_fam_list_index].F_MARR_DATE = ",0" + _valueAdd;
        //                        }
        //                        else
        //                        {
        //                            _fam_list[_fam_list_index].F_MARR_DATE = "," + _valueAdd;
        //                        }
        //                        //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
        //                        //break;
        //                        //_fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; 
        //                        break;
        //                    case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
        //                    //case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
        //                    //case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
        //                    //case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
        //                    case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
        //                    case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
        //                    case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
        //                    //case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    //case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
        //                    //case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
        //                    case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
        //                    // MARL
        //                    case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
        //                    case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
        //                    //case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
        //                    // DIV
        //                    case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
        //                    case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
        //                    //case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
        //                    case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
        //                    // ENGA
        //                    case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
        //                    case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
        //                    case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
        //                    // ANUL
        //                    case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
        //                    case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
        //                    case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

        //                    ////    // SOUR

        //                    ////case "S_S_SOUR_CONC": z_source_list[_source_list_index].S_SOUR_CONC = _valueAdd; break;
        //                    ////case "S_S_TEXT_CONC": z_source_list[_source_list_index].S_TEXT_CONC = _valueAdd; break;


        //                    //// HEADER
        //                    ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;

        //                    ////case "H_H_DEST": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H__PRO": z_gedheadText += _valueAdd; break;



        //                    //// ALBUM
        //                    ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
        //                    ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;




        //                    //case "I_I_BIRT_DATE":
        //                    //    _pe1_list[_pe_list_index].I_BIRT_DATE = _valueAdd.Trim();
        //                    //    break;
        //                    //case "I_I_NAME_GIVN":
        //                    //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
        //                    //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

        //                    //    if (boolCheckGIVEN == false)
        //                    //    {
        //                    //        boolCheckGIVEN = true;
        //                    //        //if (z_slow < 2)
        //                    //        //{
        //                    //        //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
        //                    //        //    {
        //                    //        //        if (DontCheck_Given(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
        //                    //        //        {
        //                    //        //            errortext = separator + "GIVEN contains ..."
        //                    //        //                + separator + _pe1_list[_pe_list_index].I_NAME_NSFX
        //                    //        //                + "verh.;" + _pe1_list[_pe_list_index].I_NAME_MARNM
        //                    //        //                + separator + _pe1_list[_pe_list_index].I_NAME_SURN
        //                    //        //                + separator + _pe1_list[_pe_list_index].I_NAME_GIVN
        //                    //        //                + separator + _pe1_list[_pe_list_index].AA_I_INDEX
        //                    //        //                ;
        //                    //        //            Console.WriteLine(errortext);
        //                    //        //            AddError(_count.ToString(), "CHECKING", errortext);
        //                    //        //        }
        //                    //        //    }
        //                    //        //}
        //                    //        //else
        //                    //        //{
        //                    //        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0008;CheckGiven: no output for each single entry";
        //                    //        //    Console.WriteLine(_info_0_text);
        //                    //        //    z_info_new = new("INFO;", ";", _info_0_text);

        //                    //        //    //boolCheckGIVEN = true;
        //                    //        //}
        //                    //    }
        //                    //    break;
        //                    //case "I_I_NAME_NICK": _pe1_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
        //                    //case "I_I_NAME__MAR": _pe1_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
        //                    //case "I_I_NAME_SURN": _pe1_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

        //                    //case "I_I_NAME_NPFX": _pe1_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
        //                    //case "I_I_NAME__FOR": _pe1_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

        //                    //case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
        //                    ////case "I_I_BIRT_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    ////case "I_I_BIRT__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
        //                    //case "I_I_BIRT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

        //                    //case "I_I_DEAT_DATE": _pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd.Trim(); break;
        //                    //case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
        //                    //case "I_I_DEAT_CAUS": _pe1_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
        //                    ////case "I_I_DEAT_AGE ": /*_pe1_list[_pe_list_index].I_DEAT_AGE = _valueAdd;*/ break;
        //                    ////case "I_I_DEAT__UID": /*_pe1_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
        //                    ////case "I_I_DEAT_RIN ": /*_pe1_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
        //                    //case "I_I_DEAT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
        //                    ////case "I_I_BURI_DATE": /*_pe1_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
        //                    //case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
        //                    ////case "I_I_BURI_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    ////case "I_I_BURI__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

        //                    ////case "I_I_DIV_DATE": _pe1_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
        //                    ////case "I_I_DIV_PLAC": _pe1_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
        //                    ////case "I_I_RESI_EMAI": /*_pe1_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
        //                    ////case "I_I_BAPM_PLAC": /*_pe1_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
        //                    ////case "I_I_BAPM_DATE": /*_pe1_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
        //                    ////case "I_I_CONF_PLAC": /*_pe1_list[_pe_list_index].I_CONF_PLAC = _valueAdd;*/ break;
        //                    ////case "I_I_CONF_DATE": /*_pe1_list[_pe_list_index].I_CONF_DATE = _valueAdd;*/ break;
        //                    //case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
        //                    //case "I_I_OCCU_DATE": _pe1_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
        //                    ////case "I_I_OCCU_AGE ": /*_pe1_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

        //                    ////case "I_I_CENS_PLAC": /*_pe1_list[_pe_list_index].I_CENS_PLAC = _valueAdd;*/ break;
        //                    ////case "I_I_CENS_DATE": /*_pe1_list[_pe_list_index].I_CENS_DATE = _valueAdd;*/ break;



        //                    ////case "I_I_RESI_DATE": /*_pe1_list[_pe_list_index].I_RESI_DATE = _valueAdd;*/ break;
        //                    ////case "I_I_RESI_AGE ": /*_pe1_list[_pe_list_index].I_RESI_AGE = _valueAdd;*/ break;

        //                    ////case "I_I_ADDR_CONT": /*_pe1_list[_pe_list_index].I_RESI_ADDR = "Adress available";*/ break; // same like RESI ?
        //                    ////case "I_I_RESI_ADDR": /*_pe1_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

        //                    ////case "I_I_RESI_PLAC": _pe1_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
        //                    ////case "I_I_RESI_PHON": _pe1_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
        //                    ////case "I_I_RESI_FAX ": /*_pe1_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
        //                    ////case "I_I_RESI_NOTE": /*_pe1_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
        //                    //case "I_I_FAMC_PEDI": _pe1_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

        //                    //case "I_I_EVEN_DATE": _pe1_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
        //                    //case "I_I_EVEN_NOTE": _pe1_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
        //                    ////case "I_I_EVEN_AGE ": /*_pe1_list[_pe_list_index].I_EVEN_AGE = _valueAdd;*/ break;

        //                    ////case "I_I_EVEN__UID": /*_pe1_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
        //                    ////case "I_I_EVEN_RIN ": /*_pe1_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
        //                    //case "I_I_EVEN_TYPE": _pe1_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
        //                    //case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;

        //                    //case "I_I_EMIG_DATE": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
        //                    //case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;

        //                    //case "I_I_IMMI_DATE": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;
        //                    //case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;

        //                    ////case "I_I_SOUR_DATA": /*_pe1_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR_EVEN": /*_pe1_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR_PAGE": /*_pe1_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR_QUAL": /*_pe1_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR_QUAY": /*_pe1_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
        //                    ////case "I_I_SOUR__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


        //                    //case "I_I_OBJE_FORM": _pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe1_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
        //                    ////case "I_I_OBJE_FILE": /*_pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
        //                    //case "I_I_OBJE_TITL": /*_pe1_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
        //                    //case "I_I_OBJE_NOTE": /*_pe1_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PRI": /*_pe1_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__CUT": /*_pe1_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PAR": /*_pe1_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PER": /*_pe1_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__PHO": /*_pe1_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__POS": /*_pe1_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__DAT": /*_pe1_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__ALB": /*_pe1_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
        //                    //case "I_I_OBJE__FIL": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
        //                    ////case "I_I_OBJE__PLA": /*_pe1_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


        //                    //case "I_I_ORDN_DATE": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


        //                    //case "I_I_DATE_TIME": _pe1_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
        //                    //case "I_I_CHAN_DATE": _pe1_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
        //                    //case "I_I_NOTE_CONC": _pe1_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
        //                    ////case "I_I_FILE": z_gedheadText += _valueAdd; break;

        //                    //case "I_I_NAME_NSFX":
        //                    //    _pe1_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

        //                    //if (z_slow > 0)
        //                    //{
        //                    //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
        //                    //    {
        //                    //        if (DontCheck_NSFX(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
        //                    //        {
        //                    //            _info_0_text = z_blank //+ "____________________"
        //                    //            + z_blank + _pe1_list[_pe_list_index].I_NAME_NSFX
        //                    //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
        //                    //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
        //                    //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
        //                    //            //+ " born: " + _pe1_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
        //                    //            //+ " marr: " + _pe1_list[_pe_list_index].I_MARR_DATE
        //                    //            //+ " died: " + _pe1_list[_pe_list_index].I_DEAT_DATE
        //                    //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
        //                    //            ;
        //                    //            Console.WriteLine(_info_0_text);
        //                    //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
        //                    //        }
        //                    //    }
        //                    //}
        //                    //break;

        //                    //if (_pe1_list[_pe_list_index].I_BIRT_DATE == "")
        //                    //{
        //                    //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe1_list[_pe_list_index].AA_I_INDEX;
        //                    //    Console.WriteLine(_info_0_text);
        //                    //    AddError("1231232", "INFO", _info_0_text);

        //                    //    _pe1_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
        //                    //}


        //                    default:
        //                        //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
        //                        //if (_z0z1z2 != "F_F_MARR_ADDR" || _z0z1z2 != "H_H__NAV__NAV" || _z0z1z2 != "H_H_DATE_TIME")
        //                        unknownKeyText = z_newline + "z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd;
        //                    //Console.WriteLine(/*z_newline + */"z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);
        //                    //   >> message below

        //                    // z_2 ignored

        //                    //if (_z0z1z2 == "H_H_DATE_TIME") unknownKeyText = "";
        //                    //if (_z0z1z2 == "H_H_DATE__TIM") unknownKeyText = "";
        //                    //if (_z0z1z2 == "H_H_SOUR__TRE") unknownKeyText = "";
        //                    //if (_z0z1z2 == "H_H__NAV__NAV") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_MARR_ADDR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_OCCU__UID") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_OCCU_RIN ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_RESI__UID") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_RESI_RIN ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_RESI_TYPE") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_RESI_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_NAME_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_BIRT_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_BAPM_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_DEAT_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_BURI_SOUR") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_DIV__UID") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_DIV_RIN ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_ENGA__UID") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_ENGA_RIN ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_MARL__UID") unknownKeyText = "";
        //                    //if (_z0z1z2 == "F_F_MARL_RIN ") unknownKeyText = "";

        //                    //if (_z0z1z2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
        //                    //if (_z0z1z2 == "I_I_SOUR_DATA ") unknownKeyText = "";


        //                    //if (unknownKeyText != "")
        //                    //    Console.WriteLine(/*z_newline + */"Unknown z_key at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);

        //                    _line_used = false; break;

        //                }
        //            }
        //            break;
        //    }

        //    if (z_0 != "I_" && z_0 != "F_")
        //    {
        //        switch (z_2)
        //        {
        //            case "H_FILE": z_gedheadText += _valueAdd; break;
        //            default:
        //                break;
        //        }
        //    }


        //    if (_line_used == false)
        //    {
        //        z_info_new = new("INFO;", ";", "unused line ; " + _count + " > "+ _line_string);
        //        z_info_list.Add(z_info_new);
        //    }


        //    _comment_inside_code = "End of:  if (_first == 2";
        //}
        //_comment_inside_code = "End of > foreach _all_lines";


        //_comment_inside_code = "boolCheckUnklar == false";
        //if (z_slow < 2 && boolCheckUnklar == false)
        //{
        //    _info_0_text = z_slow + "; NO_0007;for unklar / Klärung / lebt";
        //    Xwrite("Step_9905", true, _info_0_text);

        //    boolCheckUnklar = true;
        //}

        //if (z_slow < x && z_lastPeListIndex_DONE > 0)  // to avoid crashes
        //{
        //    //z_lastPeListIndex_DONE = z_lastPeListIndex;

        //    string valueCheck = _pe1_list[z_lastPeListIndex_DONE].I_NAME_NSFX;
        //    if (valueCheck.Contains("unklar") || valueCheck.Contains("Klärung") || valueCheck.Contains("lebt?"))
        //    {
        //        if (DontCheck_NSFX(_pe1_list[z_lastPeListIndex].AA_I_INDI) == false)
        //        {
        //            errortext = z_blank //+ "____________________"
        //            + z_blank + _pe1_list[z_lastPeListIndex_DONE].I_NAME_NSFX
        //            + " verh. " + _pe1_list[z_lastPeListIndex_DONE].I_NAME_MARNM
        //            + z_blank + _pe1_list[z_lastPeListIndex_DONE].I_NAME_SURN
        //            + z_blank + _pe1_list[z_lastPeListIndex_DONE].I_NAME_GIVN
        //            + " born: " + _pe1_list[z_lastPeListIndex_DONE].I_BIRT_DATE
        //            + " born_at: " + _pe1_list[z_lastPeListIndex_DONE].I_BIRT_PLAC
        //            + " marr: " + _pe1_list[z_lastPeListIndex_DONE].I_MARR_DATE
        //            + " died: " + _pe1_list[z_lastPeListIndex_DONE].I_DEAT_DATE
        //            + " " + _pe1_list[z_lastPeListIndex_DONE].AA_I_INDI
        //            ;
        //            errortext = errortext.Replace("=", " = ");

        //            if (z_lastPeListIndex > z_lastPeListIndex_DONE)
        //            {
        //                Console.WriteLine(errortext);
        //                AddError(_count.ToString(), "Suffix contains 'unklar'", errortext);
        //                z_lastPeListIndex_DONE += 1;
        //            }
        //            //z_lastPeListIndex_DONE = z_lastPeListIndex;
        //        }
        //    }
        //    valueCheck = "";
        //}

        // STOPP
        //if (_CountLines > 30000)
        //    Console.WriteLine("Stopp at 30.000");


        //z_lastPeListIndex_DONE = z_lastPeListIndex;

        // end of : if (_first_int == 2")
        //#endregion _first = 2

        //z_lastPeListIndex_DONE = z_lastPeListIndex;




        //z_lastPeListIndex_DONE = z_lastPeListIndex;


        //if (_pe_list_index >= 0 && _pe1_list[_pe_list_index].I_FAMS != "")
        //    SplitColl(_pe1_list[_pe_list_index].I_FAMS, ';');




        //_update_string = "";  // here !!

        _pe1_list.AddRange(_pe2_list);
        _pe1_list.AddRange(_pe3_list);
        _pe1_list.AddRange(_pe4_list);
        _pe1_list.AddRange(_pe5_list);
        _pe1_list.AddRange(_pe6_list);
        _pe1_list.AddRange(_pe7_list);
        _pe1_list.AddRange(_pe8_list);
        _pe1_list.AddRange(_pe9_list);

        Report_Statistics();

        PopulateSourceList();

        PopulateAlbumList();

        PopulateFamList();



        PopulatePe1List();
        //if (_pe1_list[i].I_BURI != "")
        //{
        //    //_date = "," + _pe1_list[i].I_BURI_DATE;
        //    _dateString = N60_GetDateString(_pe1_list[i].I_BURI_DATE);
        //    if (_dateString == " ")
        //    {
        //        _dateString = _deathdateString;
        //        _deathdateString = "";
        //    }

        //    _place = _pe1_list[i].I_BURI_PLAC;
        //    _cb = "";
        //    _dateColl = _dateString.Split(';');
        //    _date_val = _dateColl[0];

        //    if (_dateColl.Length > 3)
        //    {
        //        if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
        //        _month = _dateColl[4];
        //        _year = _dateColl[5];
        //    }
        //    else
        //    {
        //        Debugger.Break();
        //    }

        //    _kind = "9-buried";
        //    z_event_new = new(0, _day, _month, _year, _date_val
        //        , _date = "," + _pe1_list[i].I_BURI_DATE, _kind, _dio, _cb, _place
        //        , _pe1_list[i].AA_I_INDEX, _pe1_list[i].I_SEX, _pers_line_text)
        //        ;
        //    z_birth_list.Add(z_event_new);
        //}
        //}
        //z_ht = " # ";
        _comment_inside_code = "End of MAIN()";
    }

    private static void N00_see_Main()
    {
        z_nextGoalOfLines = _count;
    }
    private static void N02_Print_Additional_checks()
    {
        _comment_inside_code = z_newline + z_newline
        + "Additional checks:" + z_newline
        + "- last done: 17_04_2026 = check Orte-Korrekturen > FTB" + z_newline
        + "- last done: 17_04_2026 = clean Erdbestattung (BG-Sources)" + z_newline

        + "- last done: 17_04_2026 = check typo: *Josepf* > Access" + z_newline
        + "- last done: 17_04_2026 = check Walbruga > FTB" + z_newline
        + "- last done: 17_04_2026 = check Wlabruga > FTB" + z_newline
        + "- last done: 17_04_2026 = Gerog vs Georg" + z_newline
        + "- last done: 19 DEC 2022  = xx times >>> FTB: check Anony* = death (0 or 1 day)" + z_newline

        + "- last done: 24 DEC 2024 = check *Reid* vs Ried > FTB" + z_newline
        + "- last done: 24 APR 2024 = if Note = M or PF > Matrikel.txt (only Note, not DEAT_CAUS)" + z_newline

        + "- last done: 17_04_2026 = XLS: check Gütler) > " + z_newline
        + "- last done: 17_04_2026 = XLS: check Kind) > XLS" + z_newline
        + "- last done: 24 DEC 2024 = XLS: check (AN > XLS" + z_newline
        + "- last done: 19 APR 2022  = xx times >>> INDI: not (Kind) and AGE = 2" + z_newline
        + "- last done: 24 APR 2024 = <p>&nbsp;" + z_newline
        + z_newline
        + "- last done: 19 APR 2022 = xx times >>> INDI: DEAT-CAUS not empty or M6097 + D_DATE > D_NOTE not empty" + z_newline
        + "- last done: 19 APR 2022 = 35 times >>> INDI: DEAT-CAUS not DE-8 or other place" + z_newline
        + "- last done: 19 APR 2022 = xx times >>> INDI: (Pflegling) and DEAT-CAUS not empty" + z_newline
        + "- last done: 19 APR 2022 = xx times >>> INDI: not (Kind) and AGE = 2" + z_newline
        + "- last done: 19 APR 2022 = xx times >>> INDI: check NOTES for being unique" + z_newline

        + "- last done: 19 APR 2022 = xx times >>> INDI: check NOTES for being unique" + z_newline
        + "- OPEN = xx times >>> CODE or FTB-EXPORT_LEBENDE: born < 1918 and still alive coded" + z_newline
        ;

        _comment_inside_code = "SKIPPED listing > Additional checks";
        Xwrite("Step_8863", true, _comment_inside_code);
    }

    private static void N07_INDI_Lines(List<string> _all_lines)
    {
        _count = 0;
        z_nextGoalOfLines = 10000;

        string keyPrevious_indi = "";
        int _pe_list_index = -1;
        string unknownKeyText;
        string z_0 = "";
        string z_1 = "";
        string z_2 = "";
        string _entry_text = "";
        bool bool_pe2_list_has_space = true;
        bool bool_pe3_list_has_space = true;
        bool bool_pe4_list_has_space = true;
        bool bool_pe5_list_has_space = true;
        bool bool_pe6_list_has_space = true;
        bool bool_pe7_list_has_space = true;
        bool bool_pe8_list_has_space = true;
        bool bool_pe9_list_has_space = true;


        foreach (var _line in _all_lines)
        {
            _count += 1;
            //Trace.WriteLine(_count + " > " + _line);

            //_info_0_text = _count + " > Orig.Line= > " + _line;
            //Console.WriteLine(_info_0_text);
            string _valueAdd = "" + _entry_text;
            bool _line_used = true;

            Replace_stuff(_line, out string _line_string);

            _line_string = Replace_Months_Days(_line_string);

            _comment_inside_code = "Check input here" + "if (_line_string.Length == 0)" + "if (_count > z_nextGoalOfLines)";

            //_info_0_text = z_newline
            //    + "now > " + _line_string + z_newline
            //    + "org > " + _line
            //    + z_newline
            //    ;
            //Xwrite("Step_2205", true, _count + " > " + _info_0_text);

            //_comment_inside_code = "if (_line_string.Length == 0)";
            //if (_line_string.Length == 0)
            //{
            //    _info_0_text = " > " + _count + " > Line= > " + _line_string + " IS EMPTY           > Orig.= > " + _line;
            //    //Console.WriteLine(_info_0_text);
            //    Trace.WriteLine(_info_0_text);
            //    Debugger.Break();
            //    continue;
            //}

            //_comment_inside_code = "if (_count > z_nextGoalOfLines)";

            string _first = _line_string[..1];//.ToString();
            _ = int.TryParse(_first, out int _first_int);

            int secondblankOrEnd = N72_Get_2nd_blank(1, _line_string);

            _comment_inside_code = "firstchar=0";


            switch (_first_int)
            {
                case 0:

                    if (_count > z_nextGoalOfLines)
                    {
                        _info_0_text = "Step_1400 > " + DateTime.Now
                            + " > " + z_nextGoalOfLines / 1000 + " TSD > Line= > " + _line_string 
                            + "           > Orig.= > " + _line + " > pe1_list.Count= " + _pe1_list.Count;
                        Xwrite("INFO", true, _info_0_text);
                        //Trace.WriteLine(_info_0_text);
                        //z_info_new = new("INFO;", ";", _info_0_text);
                        //z_info_list.Add(z_info_new);

                        z_nextGoalOfLines += 20000;
                    }

                    

                    if (_pe1_list.Count > 30000)
                    {
                        if (bool_pe2_list_has_space)
                        {
                        _pe2_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe2_list_has_space = false;
                        }

                        if (bool_pe3_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe3_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe3_list_has_space = false;
                        }

                        if (bool_pe4_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe4_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe4_list_has_space = false;
                        }

                        if (bool_pe5_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe5_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe5_list_has_space = false;
                        }

                        if (bool_pe6_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe6_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe6_list_has_space = false;
                        }

                        if (bool_pe7_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe7_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe7_list_has_space = false;
                        }

                        if (bool_pe8_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe8_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe8_list_has_space = false;
                        }

                        if (bool_pe9_list_has_space && _pe1_list.Count > 0)
                        {
                            _pe9_list.AddRange(_pe1_list);
                            _pe1_list.Clear();
                            bool_pe9_list_has_space = false;
                        }


                    }

                    //switch (_pe1_list.Count)
                    //{
                    //    case > 200:
                    //        _int_peList = 3;
                    //        Console.WriteLine("_int_peList = 3;");
                    //        break;
                    //    case > 100:
                    //        _int_peList = 2;
                    //        Console.WriteLine("_int_peList = 2;");
                    //        break;
                    //    case > 0:
                    //        _int_peList = 1;
                    //        Console.WriteLine("_int_peList = 1;");
                    //        break;
                    //}


                    //_first = _line_string.[..1].ToString();
                    //_comment_inside_code = "SAVE TIME";

                    //_comment_inside_code = "here: for all lines";

                    //_first = _line_string[..1];//.ToString();


                    //if (_line_string.Contains("DAH+"))
                    //    _source_string = "_DAH_85244";

                    //if (_line_string.Contains("Jaubert Family Tree"))
                    //    _source_string = "Sylvie";

                    //if (_line_string.Contains("Family Tree Builder"))
                    //    _source_string = "FTP-Export";


                    _comment_inside_code = "SAVE TIME" + " > here: for all lines" + " > _line_string.Contains(\"UPD\")";
                    //if (_line_string.Contains("UPD"))  // for header
                    //{
                    //    //_update_string = N78_not_used_GetUpdateString(_line_string);
                    //    _update_string = _line_string;
                    //}

                    //if (_line_string == "2 AGE 74")
                    //{
                    //    //Debugger.Break();
                    //}



                    _comment_inside_code = "_entry_text += keyPrevious_pe + \";\" + _line_string + \" > \";";
                    //if (_first_int != 0)
                    //{
                    //    //_entry_text += keyPrevious_pe + ";" + _line_string + " > ";
                    //}



                    // Works


                    _entry_text = "";
                    //Console.WriteLine("keyPrevious {0}, _entry_text {1}, _update_string {2}, _source_string {3}", 
                    //    keyPrevious_pe, _entry_text, _update_string, _source_string);

                    _comment_inside_code = "output for each single entry to _GED_OUT folder";
                    //if (z_slow > 8 && boolSaveSingleEntry == false)
                    //{
                    //    _info_0_text = z_slow + ";NO;no output for each single entry to _GED_OUT folder";
                    //    Xwrite("Step_8900", true, _line_string);

                    //    boolSaveSingleEntry = true;
                    //}
                    //else
                    //{


                    //    if (z_slow < 2 && keyPrevious_pe != null && keyPrevious_pe != "")
                    //    {
                    //        _info_0_text = "SaveEntry = eine Datei je ID-Nummer";
                    //        //SaveEntry(keyPrevious, _entry_text, _update_string, _source_string); // ein 
                    //        boolSaveSingleEntry = true;
                    //    }
                    //}






                    //int _first_blank = 1;


                    // _first_blank
                    // Replace this unsafe block:
                    // if (_line_string.Contains(' ')) _first_blank = _line_string.IndexOf(' ');
                    // int start = _first_blank + 1;
                    // int stopp = _line_string.Length - start - 1;
                    // secondblankOrEnd = _line_string.Substring(start, stopp).IndexOf(' ') + 2;
                    // if (secondblankOrEnd < 2)
                    //     secondblankOrEnd = _line_string.Length - 2;

                    // With this safe code:
                    //_comment_inside_code = "NO find _first_blank";
                    //if (_line_string.Contains(' '))
                    //{
                    //    _first_blank = _line_string.IndexOf(' ');
                    //}
                    //else
                    //{
                    //    _first_blank = -1;
                    //}

                    // Find second space index robustly

                    //int secondblankOrEnd;



                    //if (/*_first_blank >= 0 &&*/ _first_blank + 1 < _line_string.Length)
                    //{
                    //    secondSpaceIndex = _line_string.IndexOf(' ', _first_blank + 1);
                    //}

                    //// Use line end when second space not found
                    //if (secondSpaceIndex == -1)
                    //{
                    //    // no second space -> treat as end of line
                    //    secondblankOrEnd = _line_string.Length;
                    //}
                    //else
                    //{
                    //    secondblankOrEnd = secondSpaceIndex;
                    //}
                    //if (SecondBlankOrEnd == 4 )  // only e.g. BIRT, nothing more
                    //    SecondBlankOrEnd = 0;
                    //Console.WriteLine("_first_blank = {0}, = {1}, {2}", _first_blank, secondblankOrEnd, _line_string);


                    // Example
                    // 0123456789
                    // 2 DATE 9 DEC 1939
                    // 1 SEX M



                    //if (_line_string.Substring(2, 4).ToString() == "HEAD")
                    //{
                    //    z_0 = "H_";
                    //    //_sw0_int = 0;
                    //    z_key = "HEAD";
                    //    keyPrevious_pe = z_key;
                    //    //continue;
                    //}

                    _comment_inside_code = "ab hier U_";
                    //if (_line_string.Substring(2, 2).ToString() == @"@U")
                    //{
                    //    z_0 = "U_";
                    //    Console.WriteLine("#### skipped 'U' = {0}", _line_string);
                    //    //continue;
                    //}

                    // NOTE
                    _comment_inside_code = "ab hier notes";
                    //if (_line_string.EndsWith("NOTE"))
                    //{
                    //    z_0 = "N_";
                    //    //Console.WriteLine("#### skipped 'NOTE' = {0}", _line_string);

                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");
                    //    keyPrevious_note = z_key;

                    //    Note noteNew = new(keyPrevious_note, z_blank, z_blank, z_blank);
                    //    z_note_list.Add(noteNew);
                    //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //    //continue;
                    //}


                    // INDI
                    //int _pe_index_count = 0;
                    if (_line_string.EndsWith("INDI"))  // not TRLR = each entry
                    {
                        z_0 = "I_";
                        //_sw0_int = 1;

                        //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                        z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                        z_key = N61_CleanID(z_key);
                        keyPrevious_indi = z_key;
                        //keyPrevious_indi = z_key;
                        if (keyPrevious_indi == "")
                        {
                            keyPrevious_indi = " ";
                        }

                        Pe peNew = new(keyPrevious_indi
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 11
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 21
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 31
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 41
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 51


                            );
                        //if (_count < 11300000)
                        //{
                        //switch (_int_peList)
                        //{
                        //    case 1: _pe1_list.Add(peNew); break;
                        //    case 2: _pe2_list.Add(peNew); break;
                        //    case 3: _pe3_list.Add(peNew); break;
                        //    case 4: _pe4_list.Add(peNew); break;
                        //default:
                        //        break;
                        //}
                        _pe1_list.Add(peNew);
                        //}
                        //else
                        //{
                        _comment_inside_code = "pe2_list";
                        //    _pe2_list.Add(peNew);
                        //}

                        // record index for fast lookup
                        _pe1_index[keyPrevious_indi] = _pe1_list.Count - 1;
                        //_pers_text_coll_global.Clear();
                        //Console.WriteLine("adding = {0}", keyPrevious);
                        //continue;
                    }

                    // FAM
                    //_comment_inside_code = "ab hier families";
                    ////int _fam_index_count = 0;
                    //if (_line_string.EndsWith("FAM"))
                    //{
                    //    z_0 = "F_";
                    //    //_sw0_int = 2;
                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = N61_CleanID(z_key);
                    //    keyPrevious_fam = z_key;

                    //    Fam famNew = new(keyPrevious_fam
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 11//
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 21
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//,
                    //        );


                    //    // record index for fast lookup
                    //    _fam_list.Add(famNew);
                    //    _fam_index[keyPrevious_fam] = _fam_list.Count - 1;
                    //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //    //continue;
                    //}

                    _pe_list_index = _pe1_index.GetValueOrDefault(keyPrevious_indi, -1);
                    //_fam_list_index = _fam_index.GetValueOrDefault(keyPrevious_fam, -1);
                    int _note_list_index = 0;
                    //int _source_list_index = z_source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious_sour);
                    int _source_list_index = 0;
                    //int _album_list_index = z_album_list.FindIndex(item => item.AA_A_INDEX == keyPrevious_album);
                    int _album_list_index = 0;
                    z_lastPeListIndex_DONE = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
                    //int lastPeListIndex = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
                    //else
                    //{
                    //    unknownKeyCount += 1;
                    //    keyPrevious = z_key;
                    //    //z_lastPeListIndex_DONE = z_lastPeListIndex;
                    //    //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    //    //_pe1_list.Add(peNew);
                    //    z_key = "unknownKeyCount" + unknownKeyCount.ToString();

                    //}

                    _comment_inside_code = "ab hier ALBUM";
                    //ALBUM
                    //if (_line_string.EndsWith("ALBUM"))
                    //{
                    //    z_0 = "A_";
                    //    //Console.WriteLine("#### skipped 'ALBUM' = {0}", _line_string);

                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");

                    //    if (z_album_list.FindIndex(item => item.AA_A_INDEX == z_key) > -1)
                    //    {
                    //        z_key += "2";
                    //    }

                    //    keyPrevious_album = z_key;

                    //    Album albumNew = new(keyPrevious_album, z_blank, z_blank, z_blank, z_blank);
                    //    z_album_list.Add(albumNew);
                    //    //Console.WriteLine("adding ALBUM = {0}", keyPrevious);
                    //    //continue;
                    //}

                    _comment_inside_code = "ab hier end of file";
                    //if (_line_string.EndsWith("TRLR"))
                    //{
                    //    z_0 = "END_";
                    //    //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
                    //    _info_0_text = "TRLR = End of file > " + _count;
                    //    Xwrite("Step_9985", true, _info_0_text);
                    //    //continue;
                    //}


                    //string keyPrevious_sour = "";
                    _comment_inside_code = "ab hier sources";
                    //if (_line_string.EndsWith("SOUR"))  // SOUR
                    //{
                    //    z_0 = "S_";
                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");
                    //    keyPrevious_sour = z_key;

                    //    Source sourceNew = new(keyPrevious_sour, z_blank, z_blank, z_blank);//, z_blank, z_blank, z_blank, z_blank);
                    //    z_source_list.Add(sourceNew);
                    //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //    //continue;
                    //}


                    z_lastPeListIndex_DONE = z_lastPeListIndex - 1;
                    //}
                    _comment_inside_code = "End of:  if (_first == 0";


                    //_pe3_index.Clear();
                    //for (int i = 0; i < _pe1_list.Count; i++)
                    //{
                    //    _pe3_index.Add(_pe1_list[i].AA_I_INDEX, i);
                    //}

                    //_fam_index.Clear();
                    //for (int i = 0; i < _fam_list.Count; i++)
                    //{
                    //    _fam_index.Add(_fam_list[i].AA_F_INDEX, i);
                    //}


                    //if (_pe3_index.TryGetValue(keyPrevious_pe, out int value_pe))
                    //{
                    //    _pe_list_index = value_pe;
                    //}

                    //int _fam_list_index = 0;// = _pe1_list.FindIndex(item => item.AA_I_INDEX == keyPrevious);
                    //if (_fam_index.TryGetValue(keyPrevious_fam, out int value_fam))
                    //{
                    //    _fam_list_index = value_fam;
                    //}

                    //_pe3_index.Add(_pe1_list[_pe_list_index].AA_I_INDEX, _pe_list_index);

                    //int z_lastPeListIndex_DONE;

                    //_fam_index.Add(_fam_list[_pe_list_index].AA_F_INDEX, _pe_list_index);
                    //int _note_list_index = z_note_list.FindIndex(item => item.AA_N_INDEX == keyPrevious_note);

                    //_pe1_list.Add(peNew);

                    break;





                case 1:
                    _comment_inside_code = "first = 1";
                    //#region _first_int == 1"

                    if (_line_string.Length > 5)
                        z_1 = z_0 + _line_string.Substring(2, 4).Trim(); // + z_separator;
                    else
                        z_1 = z_0 + _line_string.Substring(2, 3).Trim(); // + z_separator;

                    //_valueAdd = "";
                    //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                    //if (_line_string.Length != z_1.Length + 2)
                    //{

                    //z_1 + z_separator +  // without
                    //_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;

                    //}

                    //_valueAdd = z_1.Substring(secondblankOrEnd + 1, z_1.Length - secondblankOrEnd - 1) + z_separator;

                    int z_1_length = z_1.Length + 1;

                    if (_line_string.Length > z_1.Length)
                    {
                        _valueAdd = _line_string[z_1_length..];
                        //_valueAdd = _line_string[2..];
                    }

                    //if (_valueAdd == "ENGA") _valueAdd = "verlobt";
                    //if (_valueAdd == "MARL") _valueAdd = "StAmt";

                    //else { _valueAdd}
                    //z_value += CleanText(_valueAdd);
                    //z_value += _valueAdd;

                    //_valueAdd = CleanText(_valueAdd);
                    //_valueAdd = CleanText(_valueAdd);

                    if (z_0 == "I_")
                    {
                        //Xwrite("",true,_line_string);

                        switch (z_1)
                        {
                            // FAM
                            //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
                            //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
                            case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                            case "F_RIN ": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                            case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            //case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            case "I_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            case "I__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
                            ////case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
                            case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
                            //case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
                            //case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
                            //case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
                            //                                                                     //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;
                            //                                                                     //case "F_EVEN": _fam_list[_fam_list_index].F_EVEN = _valueAdd; break;

                            //// SOURCE
                            ////case "S_AUTH": z_source_list[_source_list_index].S_AUTH = _valueAdd; break;
                            ////case "S_TITL": z_source_list[_source_list_index].S_TITL = _valueAdd; break;
                            ////case "S_PUBL": z_source_list[_source_list_index].S_PUBL = _valueAdd; break;
                            ////case "S_TEXT": z_source_list[_source_list_index].S_TEXT = _valueAdd; break;
                            ////case "S__TYP": /*z_source_list[_source_list_index].S__TYP = _valueAdd;*/ break;
                            ////case "S__MED": z_source_list[_source_list_index].S__MED = _valueAdd; break;

                            //// ALBUM = Photos
                            ////case "S_AUTH": z_album_list[_album_list_index].S_AUTH = _valueAdd; break;
                            ////case "A_TITL": z_album_list[_album_list_index].A_TITL = _valueAdd; break;
                            ////case "A_DESC": z_album_list[_album_list_index].A_DESC = _valueAdd; break;
                            ////case "S_TEXT": z_album_list[_album_list_index].S_TEXT = _valueAdd; break;
                            case "A__UPD": /*z_album_list[_album_list_index].A__UPD = _valueAdd;*/ break;
                            case "A_RIN": /*z_album_list[_album_list_index].A_RIN = _valueAdd;*/ break;


                            //// INDI
                            case "I_NAME": /*_pe1_list[_pe_list_index].I_NAME = _valueAdd;*/ break;
                            ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                            ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                            ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                            case "I_SEX":
                                _pe1_list[_pe_list_index].I_SEX = _valueAdd;
                                //if (z_slow > 0)
                                //{
                                //    if (_bool_sex_u == false && _valueAdd.Contains("U"))// || _valueAdd.Contains("") || _valueAdd.Contains(" "))
                                //    {
                                //        errortext = z_blank + "SEX contains U"
                                //            + z_blank + _pe1_list[_pe_list_index].I_SEX
                                //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
                                //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
                                //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
                                //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
                                //            ;
                                //        Console.WriteLine(errortext);
                                //        AddError(_count.ToString(), "SEX contains U", errortext);
                                //    }
                                //}
                                //else
                                //if (z_slow == 0 && _bool_sex_u == false)
                                //{
                                //    _info_0_text = z_slow + "; NO_0009;no check for *SEX contains U*";
                                //    Xwrite("Step_9905", true, _info_0_text);

                                //    _bool_sex_u = true;
                                //}
                                break;
                            case "I_BIRT": /*_pe1_list[_pe_list_index].I_BIRT = _valueAdd;*/ break;
                            case "I_DEAT":
                                _pe1_list[_pe_list_index].I_DEAT = _valueAdd;

                                if (_valueAdd == "DEAT Y")
                                    _pe1_list[_pe_list_index].I_SEX += "d";
                                else
                                    _pe1_list[_pe_list_index].I_SEX += "a";

                                break;

                            case "I_BURI": /*_pe1_list[_pe_list_index].I_BURI = _valueAdd;*/ break;
                            case "I_FAMS": _pe1_list[_pe_list_index].I_FAMS += "Sp:F" + N61_CleanID(_valueAdd[1..]) + " # "/* + z_ht*/; break;
                            case "I_FAMC": _pe1_list[_pe_list_index].I_FAMC += "C:F" + N61_CleanID(_valueAdd[1..]) + " # "; break;


                            case "I_RESI": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;
                            //case "I_ADDR": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;  // same like RESI ??
                            //case "I_CONF": /*_pe1_list[_pe_list_index].I_CONF = _valueAdd;*/ break;
                            case "I_RELI": _pe1_list[_pe_list_index].I_RELI = _valueAdd; break;
                            case "I_OCCU": _pe1_list[_pe_list_index].I_OCCU = _valueAdd; break;
                            //case "I_CENS": /*_pe1_list[_pe_list_index].I_CENS = _valueAdd;*/ break;
                            case "I_NOTE": _pe1_list[_pe_list_index].I_NOTE = _valueAdd; break;

                            case "I_RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                            //case "I__UID": /*_pe1_list[_pe_list_index].I__UID = _valueAdd;*/ break;

                            case "S_RIN": /*z_source_list[_source_list_index].S_RIN = _valueAdd;*/ break;
                            case "S__UID": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

                            //case "I_ORDN": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

                            case "I_RIN ": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                            case "I__RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                            case "I_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

                            case "I__UPD": /*_pe1_list[_pe_list_index].I_UPD = _valueAdd;*/ break;
                            //case "I_CHAN": _pe1_list[_pe_list_index].I_UPD = "### Change instead UPD ### " + _valueAdd; break;
                            //case "N_CONC": z_note_list[_note_list_index].N_CONC = _valueAdd; break;
                            //case "N_PRIN": z_note_list[_note_list_index].N_PRIN = _valueAdd; break;
                            case "N_RIN ": /*z_note_list[_note_list_index].N_RIN = _valueAdd;*/ break;
                            case "N_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

                            //case "I_EVEN": /*_pe1_list[_pe_list_index].I_EVEN = _valueAdd;*/ break;
                            case "I_EMIG": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
                            case "I_IMMI": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;

                            //case "I_NATI": /*_pe1_list[_pe_list_index].I_NATI = _valueAdd;*/ break;


                            case "I_SOUR": /*_pe1_list[_pe_list_index].I_SOUR = _valueAdd;*/ break;

                            case "I_OBJE": /*_pe1_list[_pe_list_index].I_OBJE = _valueAdd;*/ break;

                            case "I_MARR": _pe1_list[_pe_list_index].I_MARR = _valueAdd; break;
                            //case "I_DIV ": _pe1_list[_fam_list_index].I_DIV = _valueAdd; break;
                            //case "I_NATI": _pe1_list[_pe_list_index].I_NATI = _valueAdd; break;

                            default: _line_used = false; break;
                        }
                    }


                    //_comment_inside_code = "Families";
                    //if (z_0 == "F_")
                    //{
                    //    switch (z_1)
                    //    {
                    //        // FAM
                    //        case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = _valueAdd; break;
                    //        //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
                    //        case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = _valueAdd; break;
                    //        //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
                    //        case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                    //        case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += _valueAdd + " # "; break;
                    //        //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
                    //        //case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
                    //        case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
                    //        case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
                    //        case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
                    //        case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
                    //                                                                             //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;


                    //        default: _line_used = false; break;
                    //    }
                    //}
                    _comment_inside_code = "End of:  if (_first == 1";
                    // end of : if (_first_int == 1")
                    //#endregion _first = 1

                    if (z_0 != "I_" && z_0 != "F_")
                    {
                        switch (z_1)
                        {
                            case "H_FILE": z_gedheadText += _valueAdd; break;
                            //case "H_DATE": z_gedheadText += _valueAdd; break;
                            //case "H_GEDC": z_gedheadText += _valueAdd; break;
                            //case "H_CHAR": z_gedheadText += _valueAdd; break;
                            //case "H_LANG": z_gedheadText += _valueAdd; break;
                            //case "H_SOUR": z_gedheadText += _valueAdd; break;
                            //case "H_DEST": z_gedheadText += _valueAdd; break;
                            //case "H__PRO": /*z_gedheadText += _valueAdd;*/ break;
                            //case "H__EXP": /*z_gedheadText += _valueAdd;*/ break;
                            //case "H_FILE": z_gedheadText += _valueAdd; break;

                            default: _line_used = false; break;


                        }
                    }

                    break;


                //#region _first = 2
                //_first_int == 2"
                case 2:

                    z_2 = _line_string.Substring(2, 4);

                    _valueAdd = "";
                    //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                    if (_line_string.Length > secondblankOrEnd + 1)
                    {
                        secondblankOrEnd += 1;
                        //_valueAdd =_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;
                        _valueAdd = _line_string[secondblankOrEnd..];
                        //z_0 + z_1 + z_separator + "-" + z_2 + z_separator + // without
                    }


                    //_valueAdd = CleanText(_valueAdd);
                    //_valueAdd = CleanText(_valueAdd);

                    //z_value += _valueAdd;
                    z_value += _valueAdd + z_separator;

                    string _z0z1z2 = z_0 + z_1 + "_" + z_2;

                    bool boolCheckGIVEN = false;

                    if (z_0 == "I_")
                    {

                        switch (_z0z1z2)
                        {
                            //// FAM
                            //case "F_F_MARR_DATE": _fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; break;
                            //case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
                            //case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
                            ////case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
                            ////case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
                            //case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
                            //case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
                            //case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
                            ////case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
                            ////case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
                            //case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
                            //// MARL
                            //case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
                            //case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
                            //case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
                            //// DIV
                            //case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
                            //case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
                            //case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
                            //// ENGA
                            //case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
                            //case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
                            //case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
                            //// ANUL
                            //case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
                            //case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
                            //case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

                            //    // SOUR

                            //case "S_S_SOUR_CONC": z_source_list[_source_list_index].S_SOUR_CONC = _valueAdd; break;
                            //case "S_S_TEXT_CONC": z_source_list[_source_list_index].S_TEXT_CONC = _valueAdd; break;


                            // HEADER
                            //case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                            //case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;

                            //case "H_H_DEST": z_gedheadText += _valueAdd; break;
                            //case "H_H__PRO": z_gedheadText += _valueAdd; break;



                            // ALBUM
                            //case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                            //case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                            //case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;




                            case "I_I_BIRT_DATE":
                                if (_valueAdd.Length == 9)
                                {
                                    _pe1_list[_pe_list_index].I_BIRT_DATE = ",0" + _valueAdd;
                                }
                                else
                                {
                                    _pe1_list[_pe_list_index].I_BIRT_DATE = "," + _valueAdd;
                                }
                                //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
                                //break;
                                //_pe1_list[_pe_list_index].I_BIRT_DATE = _valueAdd;
                                break;
                            case "I_I_NAME_GIVN":
                                _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
                                _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

                                if (boolCheckGIVEN == false)
                                {
                                    boolCheckGIVEN = true;
                                    //if (z_slow < 2)
                                    //{
                                    //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
                                    //    {
                                    //        if (DontCheck_Given(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                                    //        {
                                    //            errortext = separator + "GIVEN contains ..."
                                    //                + separator + _pe1_list[_pe_list_index].I_NAME_NSFX
                                    //                + "verh.;" + _pe1_list[_pe_list_index].I_NAME_MARNM
                                    //                + separator + _pe1_list[_pe_list_index].I_NAME_SURN
                                    //                + separator + _pe1_list[_pe_list_index].I_NAME_GIVN
                                    //                + separator + _pe1_list[_pe_list_index].AA_I_INDEX
                                    //                ;
                                    //            Console.WriteLine(errortext);
                                    //            AddError(_count.ToString(), "CHECKING", errortext);
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0008;CheckGiven: no output for each single entry";
                                    //    Console.WriteLine(_info_0_text);
                                    //    z_info_new = new("INFO;", ";", _info_0_text);

                                    //    //boolCheckGIVEN = true;
                                    //}
                                }
                                break;
                            case "I_I_NAME_NICK": _pe1_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
                            case "I_I_NAME__MAR": _pe1_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
                            case "I_I_NAME_SURN": _pe1_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

                            case "I_I_NAME_NPFX": _pe1_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
                            case "I_I_NAME__FOR": _pe1_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

                            case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
                            //case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            //case "I_I_BIRT_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            //case "I_I_BIRT__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
                            case "I_I_BIRT_NOTE": /*_valueAdd = _valueAdd.Replace(";", "#");*/ _pe1_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

                            case "I_I_DEAT_DATE":
                                if (_valueAdd.Length == 9)
                                {
                                    _pe1_list[_pe_list_index].I_DEAT_DATE = ",0" + _valueAdd;
                                }
                                else
                                {
                                    _pe1_list[_pe_list_index].I_DEAT_DATE = "," + _valueAdd;
                                }
                                //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
                                break;
                            case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
                            //case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            case "I_I_DEAT_CAUS": _pe1_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
                            //case "I_I_DEAT_AGE ": /*_pe1_list[_pe_list_index].I_DEAT_AGE = _valueAdd;*/ break;
                            //case "I_I_DEAT__UID": /*_pe1_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
                            //case "I_I_DEAT_RIN ": /*_pe1_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
                            case "I_I_DEAT_NOTE": /*_valueAdd = _valueAdd.Replace(";", "#");*/ _pe1_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
                            //case "I_I_BURI_DATE": /*_pe1_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
                            case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
                            //case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            //case "I_I_BURI_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            //case "I_I_BURI__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

                            //case "I_I_DIV_DATE": _pe1_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
                            //case "I_I_DIV_PLAC": _pe1_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
                            //case "I_I_RESI_EMAI": /*_pe1_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
                            //case "I_I_BAPM_PLAC": /*_pe1_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
                            //case "I_I_BAPM_DATE": /*_pe1_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
                            //case "I_I_CONF_PLAC": /*_pe1_list[_pe_list_index].I_CONF_PLAC = _valueAdd;*/ break;
                            //case "I_I_CONF_DATE": /*_pe1_list[_pe_list_index].I_CONF_DATE = _valueAdd;*/ break;

                            case "I_I_OCCU_DATE": _pe1_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
                            case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
                            //case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            //case "I_I_OCCU_AGE ": /*_pe1_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

                            //case "I_I_CENS_PLAC": /*_pe1_list[_pe_list_index].I_CENS_PLAC = _valueAdd;*/ break;
                            //case "I_I_CENS_DATE": /*_pe1_list[_pe_list_index].I_CENS_DATE = _valueAdd;*/ break;



                            //case "I_I_RESI_DATE": /*_pe1_list[_pe_list_index].I_RESI_DATE = _valueAdd;*/ break;
                            //case "I_I_RESI_AGE ": /*_pe1_list[_pe_list_index].I_RESI_AGE = _valueAdd;*/ break;

                            //case "I_I_ADDR_CONT": /*_pe1_list[_pe_list_index].I_RESI_ADDR = "Adress available";*/ break; // same like RESI ?
                            //case "I_I_RESI_ADDR": /*_pe1_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

                            //case "I_I_RESI_PLAC": _pe1_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
                            //case "I_I_RESI_PHON": _pe1_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
                            //case "I_I_RESI_FAX ": /*_pe1_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
                            //case "I_I_RESI_NOTE": /*_pe1_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
                            case "I_I_FAMC_PEDI": _pe1_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

                            case "I_I_EVEN_DATE": _pe1_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
                            case "I_I_EVEN_NOTE": _pe1_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
                            //case "I_I_EVEN_AGE ": /*_pe1_list[_pe_list_index].I_EVEN_AGE = _valueAdd;*/ break;

                            //case "I_I_EVEN__UID": /*_pe1_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
                            //case "I_I_EVEN_RIN ": /*_pe1_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
                            case "I_I_EVEN_TYPE": _pe1_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
                            case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;
                            //case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

                            case "I_I_EMIG_DATE": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
                            case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;
                            //case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

                            case "I_I_IMMI_DATE": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;
                            case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;
                            //case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;

                            //case "I_I_SOUR_DATA": /*_pe1_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
                            //case "I_I_SOUR_EVEN": /*_pe1_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
                            //case "I_I_SOUR_PAGE": /*_pe1_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
                            //case "I_I_SOUR_QUAL": /*_pe1_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
                            //case "I_I_SOUR_QUAY": /*_pe1_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
                            //case "I_I_SOUR_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            //case "I_I_SOUR__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


                            case "I_I_OBJE_FORM": _pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe1_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
                            //case "I_I_OBJE_FILE": /*_pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
                            //case "I_I_OBJE_TITL": /*_pe1_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
                            //case "I_I_OBJE_NOTE": /*_pe1_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
                            //case "I_I_OBJE__PRI": /*_pe1_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
                            //case "I_I_OBJE__CUT": /*_pe1_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
                            //case "I_I_OBJE__PAR": /*_pe1_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
                            //case "I_I_OBJE__PER": /*_pe1_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
                            //case "I_I_OBJE__PHO": /*_pe1_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
                            //case "I_I_OBJE__POS": /*_pe1_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
                            //case "I_I_OBJE__DAT": /*_pe1_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
                            //case "I_I_OBJE__ALB": /*_pe1_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
                            //case "I_I_OBJE__FIL": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
                            ////case "I_I_OBJE__PLA": /*_pe1_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


                            //case "I_I_ORDN_DATE": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


                            case "I_I_DATE_TIME": _pe1_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
                            case "I_I_CHAN_DATE": _pe1_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
                            case "I_I_NOTE_CONC": _pe1_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
                            //case "I_I_FILE": z_gedheadText += _valueAdd; break;

                            case "I_I_NAME_NSFX":
                                _pe1_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

                                //if (z_slow > 0)
                                //{
                                //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
                                //    {
                                //        if (DontCheck_NSFX(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                                //        {
                                //            _info_0_text = z_blank //+ "____________________"
                                //            + z_blank + _pe1_list[_pe_list_index].I_NAME_NSFX
                                //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
                                //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
                                //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
                                //            //+ " born: " + _pe1_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
                                //            //+ " marr: " + _pe1_list[_pe_list_index].I_MARR_DATE
                                //            //+ " died: " + _pe1_list[_pe_list_index].I_DEAT_DATE
                                //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
                                //            ;
                                //            Console.WriteLine(_info_0_text);
                                //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
                                //        }
                                //    }
                                //}
                                break;

                            //if (_pe1_list[_pe_list_index].I_BIRT_DATE == "")
                            //{
                            //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe1_list[_pe_list_index].AA_I_INDEX;
                            //    Console.WriteLine(_info_0_text);
                            //    AddError("1231232", "INFO", _info_0_text);

                            //    _pe1_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
                            //}


                            default:
                                //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
                                //if (_z0z1z2 != "F_F_MARR_ADDR" || _z0z1z2 != "H_H__NAV__NAV" || _z0z1z2 != "H_H_DATE_TIME")
                                unknownKeyText = z_newline + "z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd;
                                //Console.WriteLine(/*z_newline + */"z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);
                                //   >> message below

                                // z_2 ignored

                                //if (_z0z1z2 == "H_H_DATE_TIME") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H_DATE__TIM") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H_SOUR__TRE") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H__NAV__NAV") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARR_ADDR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_OCCU__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_OCCU_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_TYPE") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_NAME_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BIRT_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BAPM_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_DEAT_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BURI_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_DIV__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_DIV_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_ENGA__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_ENGA_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARL__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARL_RIN ") unknownKeyText = "";

                                //if (_z0z1z2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_SOUR_DATA ") unknownKeyText = "";


                                //if (unknownKeyText != "")
                                //    Console.WriteLine(/*z_newline + */"Unknown z_key at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);

                                break;

                        }
                    }

                    //if (z_0 == "F_")
                    //{

                    //    switch (_z0z1z2)
                    //    {
                    //        // FAM
                    //        case "F_F_MARR_DATE":
                    //            if (_valueAdd.Length == 9)
                    //            {
                    //                _fam_list[_fam_list_index].F_MARR_DATE = ",0" + _valueAdd;
                    //            }
                    //            else
                    //            {
                    //                _fam_list[_fam_list_index].F_MARR_DATE = "," + _valueAdd;
                    //            }
                    //            //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
                    //            //break;
                    //            //_fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; 
                    //            break;
                    //        case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
                    //        //case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                    //        case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
                    //        //case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
                    //        //case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
                    //        case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
                    //        case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
                    //        case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
                    //        //case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                    //        //case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
                    //        //case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
                    //        case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
                    //        // MARL
                    //        case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
                    //        case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
                    //        //case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                    //        case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
                    //        // DIV
                    //        case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
                    //        case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
                    //        //case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                    //        case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
                    //        // ENGA
                    //        case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
                    //        case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
                    //        case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
                    //        // ANUL
                    //        case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
                    //        case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
                    //        case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

                    //        ////    // SOUR

                    //        ////case "S_S_SOUR_CONC": z_source_list[_source_list_index].S_SOUR_CONC = _valueAdd; break;
                    //        ////case "S_S_TEXT_CONC": z_source_list[_source_list_index].S_TEXT_CONC = _valueAdd; break;


                    //        //// HEADER
                    //        ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;

                    //        ////case "H_H_DEST": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H__PRO": z_gedheadText += _valueAdd; break;



                    //        //// ALBUM
                    //        ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                    //        ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;




                    //        //case "I_I_BIRT_DATE":
                    //        //    _pe1_list[_pe_list_index].I_BIRT_DATE = _valueAdd.Trim();
                    //        //    break;
                    //        //case "I_I_NAME_GIVN":
                    //        //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
                    //        //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

                    //        //    if (boolCheckGIVEN == false)
                    //        //    {
                    //        //        boolCheckGIVEN = true;
                    //        //        //if (z_slow < 2)
                    //        //        //{
                    //        //        //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
                    //        //        //    {
                    //        //        //        if (DontCheck_Given(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                    //        //        //        {
                    //        //        //            errortext = separator + "GIVEN contains ..."
                    //        //        //                + separator + _pe1_list[_pe_list_index].I_NAME_NSFX
                    //        //        //                + "verh.;" + _pe1_list[_pe_list_index].I_NAME_MARNM
                    //        //        //                + separator + _pe1_list[_pe_list_index].I_NAME_SURN
                    //        //        //                + separator + _pe1_list[_pe_list_index].I_NAME_GIVN
                    //        //        //                + separator + _pe1_list[_pe_list_index].AA_I_INDEX
                    //        //        //                ;
                    //        //        //            Console.WriteLine(errortext);
                    //        //        //            AddError(_count.ToString(), "CHECKING", errortext);
                    //        //        //        }
                    //        //        //    }
                    //        //        //}
                    //        //        //else
                    //        //        //{
                    //        //        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0008;CheckGiven: no output for each single entry";
                    //        //        //    Console.WriteLine(_info_0_text);
                    //        //        //    z_info_new = new("INFO;", ";", _info_0_text);

                    //        //        //    //boolCheckGIVEN = true;
                    //        //        //}
                    //        //    }
                    //        //    break;
                    //        //case "I_I_NAME_NICK": _pe1_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
                    //        //case "I_I_NAME__MAR": _pe1_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
                    //        //case "I_I_NAME_SURN": _pe1_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

                    //        //case "I_I_NAME_NPFX": _pe1_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
                    //        //case "I_I_NAME__FOR": _pe1_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

                    //        //case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
                    //        ////case "I_I_BIRT_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    //        ////case "I_I_BIRT__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
                    //        //case "I_I_BIRT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

                    //        //case "I_I_DEAT_DATE": _pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd.Trim(); break;
                    //        //case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
                    //        //case "I_I_DEAT_CAUS": _pe1_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
                    //        ////case "I_I_DEAT_AGE ": /*_pe1_list[_pe_list_index].I_DEAT_AGE = _valueAdd;*/ break;
                    //        ////case "I_I_DEAT__UID": /*_pe1_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
                    //        ////case "I_I_DEAT_RIN ": /*_pe1_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
                    //        //case "I_I_DEAT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
                    //        ////case "I_I_BURI_DATE": /*_pe1_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
                    //        //case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
                    //        ////case "I_I_BURI_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    //        ////case "I_I_BURI__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

                    //        ////case "I_I_DIV_DATE": _pe1_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
                    //        ////case "I_I_DIV_PLAC": _pe1_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
                    //        ////case "I_I_RESI_EMAI": /*_pe1_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
                    //        ////case "I_I_BAPM_PLAC": /*_pe1_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
                    //        ////case "I_I_BAPM_DATE": /*_pe1_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
                    //        ////case "I_I_CONF_PLAC": /*_pe1_list[_pe_list_index].I_CONF_PLAC = _valueAdd;*/ break;
                    //        ////case "I_I_CONF_DATE": /*_pe1_list[_pe_list_index].I_CONF_DATE = _valueAdd;*/ break;
                    //        //case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
                    //        //case "I_I_OCCU_DATE": _pe1_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
                    //        ////case "I_I_OCCU_AGE ": /*_pe1_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

                    //        ////case "I_I_CENS_PLAC": /*_pe1_list[_pe_list_index].I_CENS_PLAC = _valueAdd;*/ break;
                    //        ////case "I_I_CENS_DATE": /*_pe1_list[_pe_list_index].I_CENS_DATE = _valueAdd;*/ break;



                    //        ////case "I_I_RESI_DATE": /*_pe1_list[_pe_list_index].I_RESI_DATE = _valueAdd;*/ break;
                    //        ////case "I_I_RESI_AGE ": /*_pe1_list[_pe_list_index].I_RESI_AGE = _valueAdd;*/ break;

                    //        ////case "I_I_ADDR_CONT": /*_pe1_list[_pe_list_index].I_RESI_ADDR = "Adress available";*/ break; // same like RESI ?
                    //        ////case "I_I_RESI_ADDR": /*_pe1_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

                    //        ////case "I_I_RESI_PLAC": _pe1_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
                    //        ////case "I_I_RESI_PHON": _pe1_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
                    //        ////case "I_I_RESI_FAX ": /*_pe1_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
                    //        ////case "I_I_RESI_NOTE": /*_pe1_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
                    //        //case "I_I_FAMC_PEDI": _pe1_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

                    //        //case "I_I_EVEN_DATE": _pe1_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
                    //        //case "I_I_EVEN_NOTE": _pe1_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
                    //        ////case "I_I_EVEN_AGE ": /*_pe1_list[_pe_list_index].I_EVEN_AGE = _valueAdd;*/ break;

                    //        ////case "I_I_EVEN__UID": /*_pe1_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
                    //        ////case "I_I_EVEN_RIN ": /*_pe1_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
                    //        //case "I_I_EVEN_TYPE": _pe1_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
                    //        //case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;

                    //        //case "I_I_EMIG_DATE": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
                    //        //case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;

                    //        //case "I_I_IMMI_DATE": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;
                    //        //case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;

                    //        ////case "I_I_SOUR_DATA": /*_pe1_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR_EVEN": /*_pe1_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR_PAGE": /*_pe1_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR_QUAL": /*_pe1_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR_QUAY": /*_pe1_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    //        ////case "I_I_SOUR__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


                    //        //case "I_I_OBJE_FORM": _pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe1_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
                    //        ////case "I_I_OBJE_FILE": /*_pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
                    //        //case "I_I_OBJE_TITL": /*_pe1_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
                    //        //case "I_I_OBJE_NOTE": /*_pe1_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__PRI": /*_pe1_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__CUT": /*_pe1_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__PAR": /*_pe1_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__PER": /*_pe1_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__PHO": /*_pe1_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__POS": /*_pe1_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__DAT": /*_pe1_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__ALB": /*_pe1_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
                    //        //case "I_I_OBJE__FIL": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
                    //        ////case "I_I_OBJE__PLA": /*_pe1_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


                    //        //case "I_I_ORDN_DATE": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


                    //        //case "I_I_DATE_TIME": _pe1_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
                    //        //case "I_I_CHAN_DATE": _pe1_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
                    //        //case "I_I_NOTE_CONC": _pe1_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
                    //        ////case "I_I_FILE": z_gedheadText += _valueAdd; break;

                    //        //case "I_I_NAME_NSFX":
                    //        //    _pe1_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

                    //        //if (z_slow > 0)
                    //        //{
                    //        //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
                    //        //    {
                    //        //        if (DontCheck_NSFX(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                    //        //        {
                    //        //            _info_0_text = z_blank //+ "____________________"
                    //        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_NSFX
                    //        //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
                    //        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
                    //        //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
                    //        //            //+ " born: " + _pe1_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
                    //        //            //+ " marr: " + _pe1_list[_pe_list_index].I_MARR_DATE
                    //        //            //+ " died: " + _pe1_list[_pe_list_index].I_DEAT_DATE
                    //        //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
                    //        //            ;
                    //        //            Console.WriteLine(_info_0_text);
                    //        //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
                    //        //        }
                    //        //    }
                    //        //}
                    //        //break;

                    //        //if (_pe1_list[_pe_list_index].I_BIRT_DATE == "")
                    //        //{
                    //        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe1_list[_pe_list_index].AA_I_INDEX;
                    //        //    Console.WriteLine(_info_0_text);
                    //        //    AddError("1231232", "INFO", _info_0_text);

                    //        //    _pe1_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
                    //        //}


                    //        default:
                    //            //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
                    //            //if (_z0z1z2 != "F_F_MARR_ADDR" || _z0z1z2 != "H_H__NAV__NAV" || _z0z1z2 != "H_H_DATE_TIME")
                    //            unknownKeyText = z_newline + "z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd;
                    //            //Console.WriteLine(/*z_newline + */"z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);
                    //            //   >> message below

                    //            // z_2 ignored

                    //            //if (_z0z1z2 == "H_H_DATE_TIME") unknownKeyText = "";
                    //            //if (_z0z1z2 == "H_H_DATE__TIM") unknownKeyText = "";
                    //            //if (_z0z1z2 == "H_H_SOUR__TRE") unknownKeyText = "";
                    //            //if (_z0z1z2 == "H_H__NAV__NAV") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_MARR_ADDR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_OCCU__UID") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_OCCU_RIN ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_RESI__UID") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_RESI_RIN ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_RESI_TYPE") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_RESI_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_NAME_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_BIRT_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_BAPM_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_DEAT_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_BURI_SOUR") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_DIV__UID") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_DIV_RIN ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_ENGA__UID") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_ENGA_RIN ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_MARL__UID") unknownKeyText = "";
                    //            //if (_z0z1z2 == "F_F_MARL_RIN ") unknownKeyText = "";

                    //            //if (_z0z1z2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
                    //            //if (_z0z1z2 == "I_I_SOUR_DATA ") unknownKeyText = "";


                    //            //if (unknownKeyText != "")
                    //            //    Console.WriteLine(/*z_newline + */"Unknown z_key at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);

                    //            _line_used = false; break;

                    //    }
                    //}
                    break;
            }

            if (z_0 != "I_" && z_0 != "F_")
            {
                switch (z_2)
                {
                    case "H_FILE": z_gedheadText += _valueAdd; break;
                    default:
                        break;
                }
            }


            if (_line_used == false)
            {
                z_info_new = new("INFO;", ";", "unused line ; " + _count + " > " + _line_string);
                z_info_list.Add(z_info_new);
            }


            _comment_inside_code = "End of:  if (_first == 2";
        }
        _all_lines.Clear();
        _comment_inside_code = "End of > foreach _all_lines";
    }

    private static void N06_FAM_Lines(List<string> _all_fam_lines)
    {
        _count = 0;
        z_nextGoalOfLines = 100000;

        string keyPrevious_fam = "";
        int _fam_list_index = -1;
        string unknownKeyText;
        string z_0 = "";
        string z_1 = "";
        string z_2 = "";
        string _entry_text = ""; ;


        foreach (var _line in _all_fam_lines)
        {
            _count += 1;
            //Trace.WriteLine(_count + " > " + _line);

            //_info_0_text = _count + " > Orig.Line= > " + _line;
            //Console.WriteLine(_info_0_text);
            string _valueAdd = "" + _entry_text; 
            bool _line_used = true;

            Replace_stuff(_line, out string _line_string);

            _line_string = Replace_Months_Days(_line_string);

            _comment_inside_code = "Check input here" + "if (_line_string.Length == 0)" + "if (_count > z_nextGoalOfLines)";

            //_info_0_text = z_newline
            //    + "now > " + _line_string + z_newline
            //    + "org > " + _line
            //    + z_newline
            //    ;
            //Xwrite("Step_2205", true, _count + " > " + _info_0_text);

            //_comment_inside_code = "if (_line_string.Length == 0)";
            //if (_line_string.Length == 0)
            //{
            //    _info_0_text = " > " + _count + " > Line= > " + _line_string + " IS EMPTY           > Orig.= > " + _line;
            //    //Console.WriteLine(_info_0_text);
            //    Trace.WriteLine(_info_0_text);
            //    Debugger.Break();
            //    continue;
            //}

            //_comment_inside_code = "if (_count > z_nextGoalOfLines)";

            string _first = _line_string[..1];//.ToString();
            _ = int.TryParse(_first, out int _first_int);

            int secondblankOrEnd = N72_Get_2nd_blank(1, _line_string);

            _comment_inside_code = "firstchar=0";


            switch (_first_int)
            {
                case 0:

                    if (_count > z_nextGoalOfLines)
                    {
                        _info_0_text = "Step_1400 > " + DateTime.Now
                            + " > " + z_nextGoalOfLines / 1000 + " TSD > Line= > " + _line_string + "           > Orig.= > " + _line;
                        Xwrite("INFO", true, _info_0_text);
                        //Trace.WriteLine(_info_0_text);
                        //z_info_new = new("INFO;", ";", _info_0_text);
                        //z_info_list.Add(z_info_new);

                        z_nextGoalOfLines += 50000;
                    }


                    if (_pe1_list.Count > 10)
                    {
                        _pe2_list.AddRange(_pe1_list);

                        _pe1_list.Clear();
                    }

                    //switch (_pe1_list.Count)
                    //{
                    //    case > 200:
                    //        _int_peList = 3;
                    //        Console.WriteLine("_int_peList = 3;");
                    //        break;
                    //    case > 100:
                    //        _int_peList = 2;
                    //        Console.WriteLine("_int_peList = 2;");
                    //        break;
                    //    case > 0:
                    //        _int_peList = 1;
                    //        Console.WriteLine("_int_peList = 1;");
                    //        break;
                    //}


                    //_first = _line_string.[..1].ToString();
                    //_comment_inside_code = "SAVE TIME";

                    //_comment_inside_code = "here: for all lines";

                    //_first = _line_string[..1];//.ToString();


                    //if (_line_string.Contains("DAH+"))
                    //    _source_string = "_DAH_85244";

                    //if (_line_string.Contains("Jaubert Family Tree"))
                    //    _source_string = "Sylvie";

                    //if (_line_string.Contains("Family Tree Builder"))
                    //    _source_string = "FTP-Export";


                    _comment_inside_code = "SAVE TIME" + " > here: for all lines" + " > _line_string.Contains(\"UPD\")";
                    //if (_line_string.Contains("UPD"))  // for header
                    //{
                    //    //_update_string = N78_not_used_GetUpdateString(_line_string);
                    //    _update_string = _line_string;
                    //}

                    //if (_line_string == "2 AGE 74")
                    //{
                    //    //Debugger.Break();
                    //}



                    _comment_inside_code = "_entry_text += keyPrevious_pe + \";\" + _line_string + \" > \";";
                    //if (_first_int != 0)
                    //{
                    //    //_entry_text += keyPrevious_pe + ";" + _line_string + " > ";
                    //}



                    // Works


                    _entry_text = "";
                    //Console.WriteLine("keyPrevious {0}, _entry_text {1}, _update_string {2}, _source_string {3}", 
                    //    keyPrevious_pe, _entry_text, _update_string, _source_string);

                    _comment_inside_code = "output for each single entry to _GED_OUT folder";
                    //if (z_slow > 8 && boolSaveSingleEntry == false)
                    //{
                    //    _info_0_text = z_slow + ";NO;no output for each single entry to _GED_OUT folder";
                    //    Xwrite("Step_8900", true, _line_string);

                    //    boolSaveSingleEntry = true;
                    //}
                    //else
                    //{


                    //    if (z_slow < 2 && keyPrevious_pe != null && keyPrevious_pe != "")
                    //    {
                    //        _info_0_text = "SaveEntry = eine Datei je ID-Nummer";
                    //        //SaveEntry(keyPrevious, _entry_text, _update_string, _source_string); // ein 
                    //        boolSaveSingleEntry = true;
                    //    }
                    //}






                    //int _first_blank = 1;


                    // _first_blank
                    // Replace this unsafe block:
                    // if (_line_string.Contains(' ')) _first_blank = _line_string.IndexOf(' ');
                    // int start = _first_blank + 1;
                    // int stopp = _line_string.Length - start - 1;
                    // secondblankOrEnd = _line_string.Substring(start, stopp).IndexOf(' ') + 2;
                    // if (secondblankOrEnd < 2)
                    //     secondblankOrEnd = _line_string.Length - 2;

                    // With this safe code:
                    //_comment_inside_code = "NO find _first_blank";
                    //if (_line_string.Contains(' '))
                    //{
                    //    _first_blank = _line_string.IndexOf(' ');
                    //}
                    //else
                    //{
                    //    _first_blank = -1;
                    //}

                    // Find second space index robustly

                    //int secondblankOrEnd;



                    //if (/*_first_blank >= 0 &&*/ _first_blank + 1 < _line_string.Length)
                    //{
                    //    secondSpaceIndex = _line_string.IndexOf(' ', _first_blank + 1);
                    //}

                    //// Use line end when second space not found
                    //if (secondSpaceIndex == -1)
                    //{
                    //    // no second space -> treat as end of line
                    //    secondblankOrEnd = _line_string.Length;
                    //}
                    //else
                    //{
                    //    secondblankOrEnd = secondSpaceIndex;
                    //}
                    //if (SecondBlankOrEnd == 4 )  // only e.g. BIRT, nothing more
                    //    SecondBlankOrEnd = 0;
                    //Console.WriteLine("_first_blank = {0}, = {1}, {2}", _first_blank, secondblankOrEnd, _line_string);


                    // Example
                    // 0123456789
                    // 2 DATE 9 DEC 1939
                    // 1 SEX M



                    //if (_line_string.Substring(2, 4).ToString() == "HEAD")
                    //{
                    //    z_0 = "H_";
                    //    //_sw0_int = 0;
                    //    z_key = "HEAD";
                    //    keyPrevious_pe = z_key;
                    //    //continue;
                    //}

                    _comment_inside_code = "ab hier U_";
                    //if (_line_string.Substring(2, 2).ToString() == @"@U")
                    //{
                    //    z_0 = "U_";
                    //    Console.WriteLine("#### skipped 'U' = {0}", _line_string);
                    //    //continue;
                    //}

                    // NOTE
                    _comment_inside_code = "ab hier notes";
                    //if (_line_string.EndsWith("NOTE"))
                    //{
                    //    z_0 = "N_";
                    //    //Console.WriteLine("#### skipped 'NOTE' = {0}", _line_string);

                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");
                    //    keyPrevious_note = z_key;

                    //    Note noteNew = new(keyPrevious_note, z_blank, z_blank, z_blank);
                    //    z_note_list.Add(noteNew);
                    //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //    //continue;
                    //}


                    // INDI
                    //int _pe_index_count = 0;
                    //if (_line_string.EndsWith("INDI"))  // not TRLR = each entry
                    //{
                    //    z_0 = "I_";
                    //    //_sw0_int = 1;

                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = N61_CleanID(z_key);
                    //    keyPrevious_fam = z_key;
                    //    //keyPrevious_indi = z_key;
                    //    if (keyPrevious_fam == "")
                    //    {
                    //        keyPrevious_fam = " ";
                    //    }

                    //    Pe peNew = new(keyPrevious_fam
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 11
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 21
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 31
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 41
                    //        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 51


                    //        );
                    //    //if (_count < 11300000)
                    //    //{
                    //    //switch (_int_peList)
                    //    //{
                    //    //    case 1: _pe1_list.Add(peNew); break;
                    //    //    case 2: _pe2_list.Add(peNew); break;
                    //    //    case 3: _pe3_list.Add(peNew); break;
                    //    //    case 4: _pe4_list.Add(peNew); break;
                    //    //default:
                    //    //        break;
                    //    //}
                    //    _pe1_list.Add(peNew);
                    //    //}
                    //    //else
                    //    //{
                    //    _comment_inside_code = "pe2_list";
                    //    //    _pe2_list.Add(peNew);
                    //    //}

                    //    // record index for fast lookup
                    //    _pe1_index[keyPrevious_indi] = _pe1_list.Count - 1;
                    //    //_pers_text_coll_global.Clear();
                    //    //Console.WriteLine("adding = {0}", keyPrevious);
                    //    //continue;
                    //}

                    // FAM
                    _comment_inside_code = "ab hier families";
                    //int _fam_index_count = 0;
                    if (_line_string.EndsWith("FAM"))
                    {
                        z_0 = "F_";
                        //_sw0_int = 2;
                        //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                        z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                        z_key = N61_CleanID(z_key);
                        keyPrevious_fam = z_key;

                        Fam famNew = new(keyPrevious_fam
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 11//
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 21
                            , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//,
                            );


                        // record index for fast lookup
                        _fam_list.Add(famNew);
                        _fam_index[keyPrevious_fam] = _fam_list.Count - 1;
                        //Console.WriteLine("adding FAM = {0}", keyPrevious);
                        //continue;
                    }

                    //_pe_list_index = _pe1_index.GetValueOrDefault(keyPrevious_indi, -1);
                    _fam_list_index = _fam_index.GetValueOrDefault(keyPrevious_fam, -1);
                    //int _note_list_index = 0;
                    ////int _source_list_index = z_source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious_sour);
                    //int _source_list_index = 0;
                    ////int _album_list_index = z_album_list.FindIndex(item => item.AA_A_INDEX == keyPrevious_album);
                    //int _album_list_index = 0;
                    //z_lastPeListIndex_DONE = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
                    //int lastPeListIndex = _pe_list_index + _note_list_index + _source_list_index + _album_list_index;
                    //else
                    //{
                    //    unknownKeyCount += 1;
                    //    keyPrevious = z_key;
                    //    //z_lastPeListIndex_DONE = z_lastPeListIndex;
                    //    //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    //    //_pe1_list.Add(peNew);
                    //    z_key = "unknownKeyCount" + unknownKeyCount.ToString();

                    //}

                    _comment_inside_code = "ab hier ALBUM";
                    //ALBUM
                    //if (_line_string.EndsWith("ALBUM"))
                    //{
                    //    z_0 = "A_";
                    //    //Console.WriteLine("#### skipped 'ALBUM' = {0}", _line_string);

                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");

                    //    if (z_album_list.FindIndex(item => item.AA_A_INDEX == z_key) > -1)
                    //    {
                    //        z_key += "2";
                    //    }

                    //    keyPrevious_album = z_key;

                    //    Album albumNew = new(keyPrevious_album, z_blank, z_blank, z_blank, z_blank);
                    //    z_album_list.Add(albumNew);
                    //    //Console.WriteLine("adding ALBUM = {0}", keyPrevious);
                    //    //continue;
                    //}

                    _comment_inside_code = "ab hier end of file";
                    //if (_line_string.EndsWith("TRLR"))
                    //{
                    //    z_0 = "END_";
                    //    //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
                    //    _info_0_text = "TRLR = End of file > " + _count;
                    //    Xwrite("Step_9985", true, _info_0_text);
                    //    //continue;
                    //}


                    //string keyPrevious_sour = "";
                    _comment_inside_code = "ab hier sources";
                    //if (_line_string.EndsWith("SOUR"))  // SOUR
                    //{
                    //    z_0 = "S_";
                    //    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    //    z_key = z_key.Replace("@", "");
                    //    keyPrevious_sour = z_key;

                    //    Source sourceNew = new(keyPrevious_sour, z_blank, z_blank, z_blank);//, z_blank, z_blank, z_blank, z_blank);
                    //    z_source_list.Add(sourceNew);
                    //    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //    //continue;
                    //}


                    z_lastPeListIndex_DONE = z_lastPeListIndex - 1;
                    //}
                    _comment_inside_code = "End of:  if (_first == 0";


                    //_pe3_index.Clear();
                    //for (int i = 0; i < _pe1_list.Count; i++)
                    //{
                    //    _pe3_index.Add(_pe1_list[i].AA_I_INDEX, i);
                    //}

                    //_fam_index.Clear();
                    //for (int i = 0; i < _fam_list.Count; i++)
                    //{
                    //    _fam_index.Add(_fam_list[i].AA_F_INDEX, i);
                    //}


                    //if (_pe3_index.TryGetValue(keyPrevious_pe, out int value_pe))
                    //{
                    //    _pe_list_index = value_pe;
                    //}

                    //int _fam_list_index = 0;// = _pe1_list.FindIndex(item => item.AA_I_INDEX == keyPrevious);
                    //if (_fam_index.TryGetValue(keyPrevious_fam, out int value_fam))
                    //{
                    //    _fam_list_index = value_fam;
                    //}

                    //_pe3_index.Add(_pe1_list[_pe_list_index].AA_I_INDEX, _pe_list_index);

                    //int z_lastPeListIndex_DONE;

                    //_fam_index.Add(_fam_list[_pe_list_index].AA_F_INDEX, _pe_list_index);
                    //int _note_list_index = z_note_list.FindIndex(item => item.AA_N_INDEX == keyPrevious_note);

                    //_pe1_list.Add(peNew);

                    break;





                case 1:
                    _comment_inside_code = "first = 1";
                    //#region _first_int == 1"

                    if (_line_string.Length > 5)
                        z_1 = z_0 + _line_string.Substring(2, 4).Trim(); // + z_separator;
                    else
                        z_1 = z_0 + _line_string.Substring(2, 3).Trim(); // + z_separator;

                    //_valueAdd = "";
                    //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                    //if (_line_string.Length != z_1.Length + 2)
                    //{

                    //z_1 + z_separator +  // without
                    //_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;

                    //}

                    //_valueAdd = z_1.Substring(secondblankOrEnd + 1, z_1.Length - secondblankOrEnd - 1) + z_separator;

                    int z_1_length = z_1.Length + 1;

                    if (_line_string.Length > z_1.Length)
                    {
                        _valueAdd = _line_string[z_1_length..];
                        //_valueAdd = _line_string[2..];
                    }

                    //if (_valueAdd == "ENGA") _valueAdd = "verlobt";
                    //if (_valueAdd == "MARL") _valueAdd = "StAmt";

                    //else { _valueAdd}
                    //z_value += CleanText(_valueAdd);
                    //z_value += _valueAdd;

                    //_valueAdd = CleanText(_valueAdd);
                    //_valueAdd = CleanText(_valueAdd);

                    //if (z_0 == "I_")
                    //{
                    //    //Xwrite("",true,_line_string);

                    //    switch (z_1)
                    //    {
                    //        // FAM
                    //        //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
                    //        //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
                    //        case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                    //        case "F_RIN ": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                    //        case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        //case "F_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        case "I_UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        case "I__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    //        //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
                    //        ////case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
                    //        case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
                    //        //case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
                    //        //case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
                    //        //case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
                    //        //                                                                     //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;
                    //        //                                                                     //case "F_EVEN": _fam_list[_fam_list_index].F_EVEN = _valueAdd; break;

                    //        //// SOURCE
                    //        ////case "S_AUTH": z_source_list[_source_list_index].S_AUTH = _valueAdd; break;
                    //        ////case "S_TITL": z_source_list[_source_list_index].S_TITL = _valueAdd; break;
                    //        ////case "S_PUBL": z_source_list[_source_list_index].S_PUBL = _valueAdd; break;
                    //        ////case "S_TEXT": z_source_list[_source_list_index].S_TEXT = _valueAdd; break;
                    //        ////case "S__TYP": /*z_source_list[_source_list_index].S__TYP = _valueAdd;*/ break;
                    //        ////case "S__MED": z_source_list[_source_list_index].S__MED = _valueAdd; break;

                    //        //// ALBUM = Photos
                    //        ////case "S_AUTH": z_album_list[_album_list_index].S_AUTH = _valueAdd; break;
                    //        ////case "A_TITL": z_album_list[_album_list_index].A_TITL = _valueAdd; break;
                    //        ////case "A_DESC": z_album_list[_album_list_index].A_DESC = _valueAdd; break;
                    //        ////case "S_TEXT": z_album_list[_album_list_index].S_TEXT = _valueAdd; break;
                    //        case "A__UPD": /*z_album_list[_album_list_index].A__UPD = _valueAdd;*/ break;
                    //        case "A_RIN": /*z_album_list[_album_list_index].A_RIN = _valueAdd;*/ break;


                    //        //// INDI
                    //        case "I_NAME": /*_pe1_list[_pe_list_index].I_NAME = _valueAdd;*/ break;
                    //        ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //        ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //        ////case "I_NAME": _pe1_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //        case "I_SEX":
                    //            //_pe1_list[_pe_list_index].I_SEX = _valueAdd;
                    //            //if (z_slow > 0)
                    //            //{
                    //            //    if (_bool_sex_u == false && _valueAdd.Contains("U"))// || _valueAdd.Contains("") || _valueAdd.Contains(" "))
                    //            //    {
                    //            //        errortext = z_blank + "SEX contains U"
                    //            //            + z_blank + _pe1_list[_pe_list_index].I_SEX
                    //            //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
                    //            //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
                    //            //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
                    //            //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
                    //            //            ;
                    //            //        Console.WriteLine(errortext);
                    //            //        AddError(_count.ToString(), "SEX contains U", errortext);
                    //            //    }
                    //            //}
                    //            //else
                    //            //if (z_slow == 0 && _bool_sex_u == false)
                    //            //{
                    //            //    _info_0_text = z_slow + "; NO_0009;no check for *SEX contains U*";
                    //            //    Xwrite("Step_9905", true, _info_0_text);

                    //            //    _bool_sex_u = true;
                    //            //}
                    //            break;
                    //        case "I_BIRT": /*_pe1_list[_pe_list_index].I_BIRT = _valueAdd;*/ break;
                    //        //case "I_DEAT":
                    //        //    _pe1_list[_pe_list_index].I_DEAT = _valueAdd;

                    //        //    if (_valueAdd == "DEAT Y")
                    //        //        _pe1_list[_pe_list_index].I_SEX += "d";
                    //        //    else
                    //        //        _pe1_list[_pe_list_index].I_SEX += "a";

                    //        //    break;

                    //        case "I_BURI": /*_pe1_list[_pe_list_index].I_BURI = _valueAdd;*/ break;
                    //        //case "I_FAMS": _pe1_list[_pe_list_index].I_FAMS += "Sp:F" + N61_CleanID(_valueAdd[1..]) + " # "/* + z_ht*/; break;
                    //        //case "I_FAMC": _pe1_list[_pe_list_index].I_FAMC += "C:F" + N61_CleanID(_valueAdd[1..]) + " # "; break;


                    //        case "I_RESI": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;
                    //        //case "I_ADDR": /*_pe1_list[_pe_list_index].I_RESI = _valueAdd;*/ break;  // same like RESI ??
                    //        //case "I_CONF": /*_pe1_list[_pe_list_index].I_CONF = _valueAdd;*/ break;
                    //        //case "I_RELI": _pe1_list[_pe_list_index].I_RELI = _valueAdd; break;
                    //        //case "I_OCCU": _pe1_list[_pe_list_index].I_OCCU = _valueAdd; break;
                    //        //case "I_CENS": /*_pe1_list[_pe_list_index].I_CENS = _valueAdd;*/ break;
                    //        //case "I_NOTE": _pe1_list[_pe_list_index].I_NOTE = _valueAdd; break;

                    //        case "I_RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                    //        //case "I__UID": /*_pe1_list[_pe_list_index].I__UID = _valueAdd;*/ break;

                    //        case "S_RIN": /*z_source_list[_source_list_index].S_RIN = _valueAdd;*/ break;
                    //        case "S__UID": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

                    //        //case "I_ORDN": /*z_source_list[_source_list_index].S__UID = _valueAdd;*/ break;

                    //        case "I_RIN ": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                    //        case "I__RIN": /*_pe1_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                    //        case "I_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

                    //        case "I__UPD": /*_pe1_list[_pe_list_index].I_UPD = _valueAdd;*/ break;
                    //        //case "I_CHAN": _pe1_list[_pe_list_index].I_UPD = "### Change instead UPD ### " + _valueAdd; break;
                    //        //case "N_CONC": z_note_list[_note_list_index].N_CONC = _valueAdd; break;
                    //        //case "N_PRIN": z_note_list[_note_list_index].N_PRIN = _valueAdd; break;
                    //        case "N_RIN ": /*z_note_list[_note_list_index].N_RIN = _valueAdd;*/ break;
                    //        case "N_UID ": /*_pe1_list[_pe_list_index].I_UID = _valueAdd;*/ break;

                    //        //case "I_EVEN": /*_pe1_list[_pe_list_index].I_EVEN = _valueAdd;*/ break;
                    //        //case "I_EMIG": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
                    //        //case "I_IMMI": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;

                    //        //case "I_NATI": /*_pe1_list[_pe_list_index].I_NATI = _valueAdd;*/ break;


                    //        case "I_SOUR": /*_pe1_list[_pe_list_index].I_SOUR = _valueAdd;*/ break;

                    //        case "I_OBJE": /*_pe1_list[_pe_list_index].I_OBJE = _valueAdd;*/ break;

                    //        //case "I_MARR": _pe1_list[_pe_list_index].I_MARR = _valueAdd; break;
                    //        //case "I_DIV ": _pe1_list[_fam_list_index].I_DIV = _valueAdd; break;
                    //        //case "I_NATI": _pe1_list[_pe_list_index].I_NATI = _valueAdd; break;

                    //        default: _line_used = false; break;
                    //    }
                    //}


                    _comment_inside_code = "Families";
                    if (z_0 == "F_")
                    {
                        switch (z_1)
                        {
                            // FAM
                            case "F_HUSB":
                                _valueAdd = N63_X_String(7, _valueAdd);
                                //while (_valueAdd.Length < 7)
                                //{
                                //    _valueAdd += " " + _valueAdd;
                                //}
                                _fam_list[_fam_list_index].F_HUSB = _valueAdd; 
                                break;
                            //case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = N61_CleanID(_valueAdd); break;
                            case "F_WIFE":
                                _valueAdd = N63_X_String(7, _valueAdd);
                                _fam_list[_fam_list_index].F_WIFE = _valueAdd; 
                                break;
                            //case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = N61_CleanID(_valueAdd); break;
                            case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                            case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                            case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += _valueAdd + " # "; break;
                            //case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += N61_CleanID(_valueAdd) + " # "; break;
                            //case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
                            case "F_MARR": /*_fam_list[_fam_list_index].F_MARR = _valueAdd;*/ break;
                            case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
                            case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
                            case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
                                                                                                 //case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;
                            default: _line_used = false; break;
                        }
                    }
                    _comment_inside_code = "End of:  if (_first == 1";
                    break;


                //#region _first = 2
                //_first_int == 2"
                case 2:

                    z_2 = _line_string.Substring(2, 4);

                    _valueAdd = "";
                    //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                    if (_line_string.Length > secondblankOrEnd + 1)
                    {
                        secondblankOrEnd += 1;
                        //_valueAdd =_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;
                        _valueAdd = _line_string[secondblankOrEnd..];
                        //z_0 + z_1 + z_separator + "-" + z_2 + z_separator + // without
                    }


                    //_valueAdd = CleanText(_valueAdd);
                    //_valueAdd = CleanText(_valueAdd);

                    //z_value += _valueAdd;
                    z_value += _valueAdd + z_separator;

                    string _z0z1z2 = z_0 + z_1 + "_" + z_2;


                    if (z_0 == "F_")
                    {

                        switch (_z0z1z2)
                        {
                            // FAM
                            case "F_F_MARR_DATE":
                                if (_valueAdd.Length == 9)
                                {
                                    _fam_list[_fam_list_index].F_MARR_DATE = ",0" + _valueAdd;
                                }
                                else
                                {
                                    _fam_list[_fam_list_index].F_MARR_DATE = "," + _valueAdd;
                                }
                                //_pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd; 
                                //break;
                                //_fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; 
                                break;
                            case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
                            //case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
                            //case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
                            //case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
                            case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
                            case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
                            case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
                            //case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            //case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
                            //case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
                            case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
                            // MARL
                            case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
                            case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
                            //case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
                            // DIV
                            case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
                            case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
                            //case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = N62_CleanPlace(_valueAdd, out _valueAdd); break;
                            case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
                            // ENGA
                            case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
                            case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
                            case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
                            // ANUL
                            case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
                            case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
                            case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

                            ////    // SOUR

                            ////case "S_S_SOUR_CONC": z_source_list[_source_list_index].S_SOUR_CONC = _valueAdd; break;
                            ////case "S_S_TEXT_CONC": z_source_list[_source_list_index].S_TEXT_CONC = _valueAdd; break;


                            //// HEADER
                            ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                            ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;

                            ////case "H_H_DEST": z_gedheadText += _valueAdd; break;
                            ////case "H_H__PRO": z_gedheadText += _valueAdd; break;



                            //// ALBUM
                            ////case "H_H_GEDC_VERS": z_gedheadText += _valueAdd; break;
                            ////case "H_H_GEDC_FORM": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_NAME": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_VERS": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR__RTL": z_gedheadText += _valueAdd; break;
                            ////case "H_H_SOUR_CORP": z_gedheadText += _valueAdd; break;




                            //case "I_I_BIRT_DATE":
                            //    _pe1_list[_pe_list_index].I_BIRT_DATE = _valueAdd.Trim();
                            //    break;
                            //case "I_I_NAME_GIVN":
                            //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
                            //    _pe1_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

                            //    if (boolCheckGIVEN == false)
                            //    {
                            //        boolCheckGIVEN = true;
                            //        //if (z_slow < 2)
                            //        //{
                            //        //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
                            //        //    {
                            //        //        if (DontCheck_Given(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                            //        //        {
                            //        //            errortext = separator + "GIVEN contains ..."
                            //        //                + separator + _pe1_list[_pe_list_index].I_NAME_NSFX
                            //        //                + "verh.;" + _pe1_list[_pe_list_index].I_NAME_MARNM
                            //        //                + separator + _pe1_list[_pe_list_index].I_NAME_SURN
                            //        //                + separator + _pe1_list[_pe_list_index].I_NAME_GIVN
                            //        //                + separator + _pe1_list[_pe_list_index].AA_I_INDEX
                            //        //                ;
                            //        //            Console.WriteLine(errortext);
                            //        //            AddError(_count.ToString(), "CHECKING", errortext);
                            //        //        }
                            //        //    }
                            //        //}
                            //        //else
                            //        //{
                            //        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0008;CheckGiven: no output for each single entry";
                            //        //    Console.WriteLine(_info_0_text);
                            //        //    z_info_new = new("INFO;", ";", _info_0_text);

                            //        //    //boolCheckGIVEN = true;
                            //        //}
                            //    }
                            //    break;
                            //case "I_I_NAME_NICK": _pe1_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
                            //case "I_I_NAME__MAR": _pe1_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
                            //case "I_I_NAME_SURN": _pe1_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

                            //case "I_I_NAME_NPFX": _pe1_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
                            //case "I_I_NAME__FOR": _pe1_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

                            //case "I_I_BIRT_PLAC": _pe1_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
                            ////case "I_I_BIRT_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            ////case "I_I_BIRT__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
                            //case "I_I_BIRT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

                            //case "I_I_DEAT_DATE": _pe1_list[_pe_list_index].I_DEAT_DATE = _valueAdd.Trim(); break;
                            //case "I_I_DEAT_PLAC": _pe1_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
                            //case "I_I_DEAT_CAUS": _pe1_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
                            ////case "I_I_DEAT_AGE ": /*_pe1_list[_pe_list_index].I_DEAT_AGE = _valueAdd;*/ break;
                            ////case "I_I_DEAT__UID": /*_pe1_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
                            ////case "I_I_DEAT_RIN ": /*_pe1_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
                            //case "I_I_DEAT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe1_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
                            ////case "I_I_BURI_DATE": /*_pe1_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
                            //case "I_I_BURI_PLAC": _pe1_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
                            ////case "I_I_BURI_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            ////case "I_I_BURI__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

                            ////case "I_I_DIV_DATE": _pe1_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
                            ////case "I_I_DIV_PLAC": _pe1_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
                            ////case "I_I_RESI_EMAI": /*_pe1_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
                            ////case "I_I_BAPM_PLAC": /*_pe1_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
                            ////case "I_I_BAPM_DATE": /*_pe1_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
                            ////case "I_I_CONF_PLAC": /*_pe1_list[_pe_list_index].I_CONF_PLAC = _valueAdd;*/ break;
                            ////case "I_I_CONF_DATE": /*_pe1_list[_pe_list_index].I_CONF_DATE = _valueAdd;*/ break;
                            //case "I_I_OCCU_PLAC": _pe1_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
                            //case "I_I_OCCU_DATE": _pe1_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
                            ////case "I_I_OCCU_AGE ": /*_pe1_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

                            ////case "I_I_CENS_PLAC": /*_pe1_list[_pe_list_index].I_CENS_PLAC = _valueAdd;*/ break;
                            ////case "I_I_CENS_DATE": /*_pe1_list[_pe_list_index].I_CENS_DATE = _valueAdd;*/ break;



                            ////case "I_I_RESI_DATE": /*_pe1_list[_pe_list_index].I_RESI_DATE = _valueAdd;*/ break;
                            ////case "I_I_RESI_AGE ": /*_pe1_list[_pe_list_index].I_RESI_AGE = _valueAdd;*/ break;

                            ////case "I_I_ADDR_CONT": /*_pe1_list[_pe_list_index].I_RESI_ADDR = "Adress available";*/ break; // same like RESI ?
                            ////case "I_I_RESI_ADDR": /*_pe1_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

                            ////case "I_I_RESI_PLAC": _pe1_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
                            ////case "I_I_RESI_PHON": _pe1_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
                            ////case "I_I_RESI_FAX ": /*_pe1_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
                            ////case "I_I_RESI_NOTE": /*_pe1_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
                            //case "I_I_FAMC_PEDI": _pe1_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

                            //case "I_I_EVEN_DATE": _pe1_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
                            //case "I_I_EVEN_NOTE": _pe1_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
                            ////case "I_I_EVEN_AGE ": /*_pe1_list[_pe_list_index].I_EVEN_AGE = _valueAdd;*/ break;

                            ////case "I_I_EVEN__UID": /*_pe1_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
                            ////case "I_I_EVEN_RIN ": /*_pe1_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
                            //case "I_I_EVEN_TYPE": _pe1_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
                            //case "I_I_EVEN_PLAC": _pe1_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;

                            //case "I_I_EMIG_DATE": _pe1_list[_pe_list_index].I_EMIG = _valueAdd; break;
                            //case "I_I_EMIG_PLAC": _pe1_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;

                            //case "I_I_IMMI_DATE": _pe1_list[_pe_list_index].I_IMMI = _valueAdd; break;
                            //case "I_I_IMMI_PLAC": _pe1_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;

                            ////case "I_I_SOUR_DATA": /*_pe1_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
                            ////case "I_I_SOUR_EVEN": /*_pe1_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
                            ////case "I_I_SOUR_PAGE": /*_pe1_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
                            ////case "I_I_SOUR_QUAL": /*_pe1_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
                            ////case "I_I_SOUR_QUAY": /*_pe1_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
                            ////case "I_I_SOUR_RIN ": /*_pe1_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                            ////case "I_I_SOUR__UID": /*_pe1_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


                            //case "I_I_OBJE_FORM": _pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe1_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
                            ////case "I_I_OBJE_FILE": /*_pe1_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
                            //case "I_I_OBJE_TITL": /*_pe1_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
                            //case "I_I_OBJE_NOTE": /*_pe1_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
                            //case "I_I_OBJE__PRI": /*_pe1_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
                            //case "I_I_OBJE__CUT": /*_pe1_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
                            //case "I_I_OBJE__PAR": /*_pe1_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
                            //case "I_I_OBJE__PER": /*_pe1_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
                            //case "I_I_OBJE__PHO": /*_pe1_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
                            //case "I_I_OBJE__POS": /*_pe1_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
                            //case "I_I_OBJE__DAT": /*_pe1_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
                            //case "I_I_OBJE__ALB": /*_pe1_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
                            //case "I_I_OBJE__FIL": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
                            ////case "I_I_OBJE__PLA": /*_pe1_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


                            //case "I_I_ORDN_DATE": /*_pe1_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


                            //case "I_I_DATE_TIME": _pe1_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
                            //case "I_I_CHAN_DATE": _pe1_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
                            //case "I_I_NOTE_CONC": _pe1_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
                            ////case "I_I_FILE": z_gedheadText += _valueAdd; break;

                            //case "I_I_NAME_NSFX":
                            //    _pe1_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

                            //if (z_slow > 0)
                            //{
                            //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
                            //    {
                            //        if (DontCheck_NSFX(_pe1_list[_pe_list_index].AA_I_INDEX) == false)
                            //        {
                            //            _info_0_text = z_blank //+ "____________________"
                            //            + z_blank + _pe1_list[_pe_list_index].I_NAME_NSFX
                            //            + " verh. " + _pe1_list[_pe_list_index].I_NAME_MARNM
                            //            + z_blank + _pe1_list[_pe_list_index].I_NAME_SURN
                            //            + z_blank + _pe1_list[_pe_list_index].I_NAME_GIVN
                            //            //+ " born: " + _pe1_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
                            //            //+ " marr: " + _pe1_list[_pe_list_index].I_MARR_DATE
                            //            //+ " died: " + _pe1_list[_pe_list_index].I_DEAT_DATE
                            //            + z_blank + _pe1_list[_pe_list_index].AA_I_INDEX
                            //            ;
                            //            Console.WriteLine(_info_0_text);
                            //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
                            //        }
                            //    }
                            //}
                            //break;

                            //if (_pe1_list[_pe_list_index].I_BIRT_DATE == "")
                            //{
                            //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe1_list[_pe_list_index].AA_I_INDEX;
                            //    Console.WriteLine(_info_0_text);
                            //    AddError("1231232", "INFO", _info_0_text);

                            //    _pe1_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
                            //}


                            default:
                                //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
                                //if (_z0z1z2 != "F_F_MARR_ADDR" || _z0z1z2 != "H_H__NAV__NAV" || _z0z1z2 != "H_H_DATE_TIME")
                                unknownKeyText = z_newline + "z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd;
                                //Console.WriteLine(/*z_newline + */"z_key not used at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);
                                //   >> message below

                                // z_2 ignored

                                //if (_z0z1z2 == "H_H_DATE_TIME") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H_DATE__TIM") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H_SOUR__TRE") unknownKeyText = "";
                                //if (_z0z1z2 == "H_H__NAV__NAV") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARR_ADDR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_OCCU__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_OCCU_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_TYPE") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_RESI_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_NAME_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BIRT_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BAPM_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_DEAT_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_BURI_SOUR") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_DIV__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_DIV_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_ENGA__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_ENGA_RIN ") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARL__UID") unknownKeyText = "";
                                //if (_z0z1z2 == "F_F_MARL_RIN ") unknownKeyText = "";

                                //if (_z0z1z2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
                                //if (_z0z1z2 == "I_I_SOUR_DATA ") unknownKeyText = "";


                                //if (unknownKeyText != "")
                                //    Console.WriteLine(/*z_newline + */"Unknown z_key at _z0z1z2 = " + _z0z1z2 + " at line: " + _count.ToString() + ": z_value = " + _valueAdd);

                                _line_used = false; break;

                        }
                    }
                    break;
            }

            if (z_0 != "I_" && z_0 != "F_")
            {
                switch (z_2)
                {
                    case "H_FILE": z_gedheadText += _valueAdd; break;
                    default:
                        break;
                }
            }


            if (_line_used == false)
            {
                z_info_new = new("INFO;", ";", "unused line ; " + _count + " > " + _line_string);
                z_info_list.Add(z_info_new);
            }


            _comment_inside_code = "End of:  if (_first == 2";
        }
        _comment_inside_code = "End of > foreach _all_lines";
    }

    private static string N63_X_String(int v, string _text)
    {
        string _add = "";
        for (int i = 0; i < v - _text.Length; i++)
        {
            _add += " ";
        }
        return _add + _text;
    }

    private static string N62_CleanPlace(string valueAdd1, out string valueAdd2)
    {
        valueAdd2 = valueAdd1;
        int pos = valueAdd1.IndexOf("DE-") + 9;
        if (pos > valueAdd1.Length) pos = valueAdd1.Length;
        if (pos > 8)
        {
            valueAdd2 = valueAdd1[..pos];
        }
        valueAdd2 = valueAdd2.Replace("jetzt Dolni Dvur ", "");
        valueAdd2 = valueAdd2.Replace("München (Munich)", "Munich");
        return valueAdd2;
    }
}