// File:A00_Code.cs

using System.Diagnostics;
using System.Media;
using System.Text;

class A00_Code
{
    //private static readonly string z_in_file = "C:/DB/__ged_IN.ged";

    private static readonly string z_out_file = "C:/DB/__ged_IN-autosave.ged";
    private static readonly string z_out_file_PersLine = "C:/DB/_PersLine-out.txt";
    private static readonly string z_out_file_FamLine = "C:/DB/_FamLine-out.txt";
    //private static readonly string z_out_file_AlbumLine = "C:/DB/_AlbumLine-out.txt";
    //private static readonly string z_out_file_SourceLine = "C:/DB/_SourceLine-out.txt";
    private static readonly string z_out_file_NoteLine = "C:/DB/_NoteLine-out.txt";

    private static readonly Dictionary<string, int> _fam_index = [];
    private static readonly Dictionary<string, int> _pe_index = [];

    private static readonly List<Pe> _pe_list = [];
    private static readonly List<Fam> _fam_list = [];
    private static readonly List<Album> z_album_list = [];
    private static readonly List<Event> z_eventList = [];
    private static readonly List<Note> z_note_list = [];
    private static readonly List<Source> z_source_list = [];
    private static readonly List<Updates> z_updates_list = [];
    private static readonly List<Obj> z_obj_list = [];


    private static readonly List<Info> _fam_line_list = [];
    private static readonly List<Info> _pers_line_list = [];
    private static readonly List<Info> z_album_line_list = [];
    private static readonly List<Info> z_info_list = [];
    private static readonly List<Info> z_list = [];
    private static readonly List<Info> z_note_line_list = [];
    private static readonly List<Info> z_source_line_list = [];
    private static readonly List<Info> z_updates_line_list = [];
    private static readonly List<Info> z_obj_line_list = [];

    private static Info z_info_new = new("", "", "");
    private static Event z_event_new = new(0, "", "", "", "", "", "", "", "", "", "", "", "");
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
    //private static string gedheadText = "";
    //private static readonly string z_ht = " # ";
    private static readonly string z_tab = "\t";
    private static readonly string z_semicolon = ";";
    private static string z_key = "";
    //private static string unknownKeyText = "unknown";
    //private static string z_0 = "";
    //private static string z_1 = "";
    //private static string z_2 = "";
    private static string _value = "";
    //private static string _valueAdd = "";
    private static string z_blank = "";


    //private bool bool_nbsp = false;



    private static int Get_2nd_blank(int _first_blank, string _line_string)
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

    private static void A00_see_Main()
    {
        z_nextGoalOfLines = _count;
    }
    private static void A11_Save(string v, List<Info> _list, string _out_file)
    {
        StreamWriter _stream_Writer = new(File.Open(_out_file, FileMode.Create), Encoding.UTF8);

        z_nextGoalOfLines = _count;
        _count = -1;
        z_nextGoalOfLines = 10000;

        _info_0_text = "Output > " + v;
        string _out_text = "";

        switch (_out_text)
        {
            case "C:/DB/_FamLine-out.txt": _out_text = "I_\tHUSB\tWIFE\tMARR_DATE\tMARR_PLAC" + z_newline; break;
            case "C:/DB/_AlbumLine-out.txt": _out_text = "I_\tHUSB\tWIFE\tMARR_DATE\tMARR_PLAC" + z_newline; break;
            case "C:/DB/_PersLine-out.txt":
                _out_text = "I_\tNAME\tGIVN\tNAME_MARNM\tBIRT_DATE\tBIRT_PLAC\tDEAT_DATE\tDEAT_PLAC\tI_DEAT\tI_BURI_PLAC\tNAME_NSFX\tDEAT_CAUS\tFAMC\tIAMS" + z_newline;
                break;
        }

        //string _all_text = "";
        foreach (var _line in _list)
        {
            _count += 1;

            //string _all_text = DoReplace_Months_Days(_line);
            //_all_text += Environment.NewLine + _line;
            //Debugger.Break(); return "";

            _out_text += _line.E_TEXT + z_newline;

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

        _stream_Writer.WriteLine(_out_text);

        _stream_Writer.Close();
        _info_0_text = " _out_text PersLine > " + _count.ToString() + " > FINISHED ";
        Xwrite("Step_2500", true, _info_0_text);
    }

    private static void A05_DoAutosave(List<string> _all_lines)
    {
        //Debugger.Break();
        //try
        //{
        //z_start_time_global = DateTime.Now;
        // run processing on background thread and get processed lines


        StreamWriter _stream_Writer = new(File.Open(z_out_file, FileMode.Create), Encoding.UTF8);

        int _count = -1;
        z_nextGoalOfLines = 1000000;

        _info_0_text = "Output";
        //string _all_text = "";
        foreach (var _line in _all_lines)
        {
            _count += 1;

            //string _all_text = DoReplace_Months_Days(_line);
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
        //    Xwrite("Step_9900", true, _count + z_newline + " > DoReplace_stuff ");
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
            z_info_new = new("INFO;", ";", _info_0_text);
            z_info_list.Add(z_info_new);
        }

    }

    public static void SaveInfo(string path, string file)
    {
        char _separatorArray = ';';
        //string arrayline;// = "";
        string _newline = Environment.NewLine;
        string txt = ".txt";
        //Console.WriteLine(z_newline + z_newline + "##### Errors:" + z_newline);

        string arrayFileERRORS = path + file + "__ERRORS_out" + txt;
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

        //for (int j = 0; j < _pe_list.Count - 1; j++)
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
        streamWriterERRORS.WriteLine(_newline + "#######   maybe not finished ... this is __Errors_Out.txt - it is now: " + DateTime.Now + _newline + _newline);
        streamWriterERRORS.Close();
        //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;streamWriterERRORS = _ERRORS_out" + txt);
        //#endregion End write ERRORS
    }

    //private static void SaveEntry(string keyPrevious, string _entry_text, string _update_string, string _source_string)
    //{
    //    Debugger.Break();
    //}

    private static string GetDateString(string _dateIN)
    {
        //int z_slow = 8;
        _comment_inside_code = "_dateIN is e.g. 29.03.1969;";
        int _count = 0;
        bool bool_getDateValue = false;
        //string _info_0_text;// = "";
        string ValDateString = "0";
        //if (_dateIN.Contains("x")) //-TURNEDOFF"))
#pragma warning disable IDE0059 // Unnecessary assignment of a _value
        string dateIN_old = _dateIN;
#pragma warning restore IDE0059 // Unnecessary assignment of a _value
        //if (dateIN_old == "xyz") dateIN_old = "z";

        //if (_dateIN == "ca. Jul 1615")
        //    _dateIN = _dateIN.Replace("=", "");

        if (_dateIN.Contains("x-TURNEDOFF"))
        {
            _info_0_text = _count.ToString() + "date contains 'x';" + _dateIN;
            Xwrite("Step_1103", true, _count + _info_0_text);
            //Console.WriteLine(_info_0_text);
            //z_info_new = new("INFO;", ";", _info_0_text);
            //z_info_list.Add(z_info_new);

            _info_0_text = _count.ToString() + "date contains 'x';" + _dateIN;
            Xwrite("Step_1104", true, _count + _info_0_text);
            //Console.WriteLine(_info_0_text);
            //z_info_new = new("INFO;", ";", _info_0_text);
            //z_info_list.Add(z_info_new);
            //AddError(_count.ToString(), "date contains 'x';", _dateIN);
            //_lineString = _lineString.Replace("&nbsp;", " ");
        }
        if (_dateIN.Length > 0 && _dateIN[..1] != "u")
            bool_getDateValue = true;

        string day = "";
        string month = "";
        string year = "";
        //string 
        string dateOUT = ";;";
        //string separator = ";";
        _dateIN = _dateIN.Replace("ABT ", "");
        _dateIN = _dateIN.Replace("BEF ", "");
        _dateIN = _dateIN.Replace("CALC ", "");
        _dateIN = _dateIN.Replace("=", "");
        _dateIN = _dateIN.Replace("ca. ", "");
        _dateIN = _dateIN.Replace("ca.", "");

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

        _comment_inside_code = "Xwrite(\"Step_1702\", true, _info_0_text);";
        //_info_0_text = "Length= " + _dateIN.Length + ", _dateIN= " + _dateIN;
        //Xwrite("Step_1702", true, _info_0_text);

        switch (_dateIN.Length)//.ToString())
        {
            //case "0": break; // Empty
            case 0: break; // Empty

            //case "11":
            case 10:
                // for some tasks the date comes with leading '0' and leading character e.g. u for _UPD
                //_dateIN = _dateIN.Substring(1, 10);
                year = _dateIN.Substring(6, 4);
                month = _dateIN.Substring(3, 2);
                //day = _dateIN.Substring(0, 2);
                day = _dateIN[..2];
                dateOUT = day + z_separator + month + z_separator + year;
                break;

            //case "10":
            case 9:
                _comment_inside_code = "e.g. 1.07.1970";
                //if (_dateIN.Length == 11)
                //{
                year = _dateIN.Substring(5, 4);
                //month = GetMonthNumeric(_dateIN.Substring(3, 3));
                month = _dateIN.Substring(2, 2);
                //day = _dateIN.Substring(0, 2);
                day = _dateIN[..1];
                dateOUT = day + z_separator + month + z_separator + year;
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
            case 8:
                _comment_inside_code = "e.g. 1.07.1970 or > AFT 1856";

                if (_dateIN.Contains("AFT") || _dateIN.Contains("BEF") || _dateIN.Contains("ABT"))
                {
                    year = _dateIN.Substring(4, 4);
                    month = _dateIN[..3]; //day = dateIN.[..1];
                    dateOUT = /*day + */z_separator + month + z_separator + year;
                    //}
                    break;

                }
                else
                {
                    _comment_inside_code = "e.g. 1.07.1970";

                    year = _dateIN.Substring(4, 4);
                    month = _dateIN.Substring(2, 2);
                    day = _dateIN[..1];
                    dateOUT = "0" + day + z_separator + month + z_separator + year;
                    break;
                }
            //month = GetMonthNumeric(_dateIN.Substring(2, 3)); day = _dateIN[..1];

            //case "8":
            case 7:
                if (_dateIN == "unbekannt" || _dateIN == "unbekannt=")
                    dateOUT = "unbekannt";
                break;
            //{


            //case "7":
            case 6:
                //if (_dateIN.Length == 8)
                //{
                year = _dateIN.Substring(4, 4);
                //month = GetMonthNumeric(_dateIN.Substring(0, 3)); 
                month = _dateIN[..3]; //day = _dateIN.[..1];
                dateOUT = /*day + */z_separator + month + z_separator + year;
                //}
                break;

            //case "4":
            case 4:
                //if (_dateIN.Length == 4)
                //{
                //year = _dateIN.Substring(0, 4); 
                year = _dateIN[..4];
                dateOUT = /*day +*/ z_separator + /*month +*/ z_separator + year;
                //}
                break;
            default:
                dateOUT = "not 4,8,10,11;;";
                //Console.WriteLine(dateOUT + dateIN_old); 
                //dateOUT = ";;";
                break;
        }

        if (z_slow > 12 && dateOUT.Contains("not"))
        {
            _info_0_text = "dateOUT contains 'not';" + _dateIN;
            Xwrite("Step_1502", true, _count + _info_0_text);
            //_lineString = _lineString.Replace("&nbsp;", " ");
        }


        if (bool_getDateValue == true && z_slow > 9 && year != "")
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

        if (ValDateString == "0")
        {
            ValDateString = "nv;nv;nv";
        }

        return /*separator + */ValDateString + z_separator + dateOUT;
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

    //private static string CleanText(string _valueAdd)
    //{
    //    //Debugger.Break(); return "";
    //}

    private static string DoCleanID(string id)
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

    private static string DoReplace_stuff(string _line_string, out string _line2)
    {
        //bool boolChecknbsp = false;

        _line_string = _line_string.Replace(@"/ Sr.M.", "# Sr.M.");
        //_line_string = _line_string.Replace("\"", "");

        //_line_string = _line_string.Replace(" /", " > ");  // inside FullName
        //_line_string = _line_string.Replace("/", "");

        _line_string = _line_string.Replace("&gt;", ">");
        //_line_string = _line_string.Replace("&auml;", "ä");
        //_line_string = _line_string.Replace("&ouml;", "ö");
        //_line_string = _line_string.Replace("&uuml;", "ü");
        //_line_string = _line_string.Replace("&szlig;", "ß");
        _line_string = _line_string.Replace("&amp;", "=");

        _line_string = _line_string.Replace(";;;;;", " - ");
        _line_string = _line_string.Replace("=", "");
        _line_string = _line_string.Replace("https://", "");
        _line_string = _line_string.Replace("http://", "");
        _line_string = _line_string.Replace("<p># ", "");
        //_line_string = _line_string.Replace(" GMT -0500", "");

        _line_string = _line_string.Replace("<a href", "");
        _line_string = _line_string.Replace("</a>", "");
        _line_string = _line_string.Replace("</p>", "");
        _line_string = _line_string.Replace("@;", ";");
        _line_string = _line_string.Replace("@", "");
        _line_string = _line_string.Replace("*", "");
        _line_string = _line_string.Replace(" # ;", ";");
        _line_string = _line_string.Replace("\";\"", ";");
        //_line_string = _line_string.Replace("MH:I", "");
        _line_string = _line_string.Replace("\"", "");
        _line_string = _line_string.Replace("\";\"", ";");


        //_line_string = _line_string.Replace("M255-", "M.255-");

        _comment_inside_code = "check for &nbsp; only once per file to save time";
        //bool boolChecknbsp = false;

        //if (z_slow < 2 && boolChecknbsp == false)
        //{

        //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0006;for <p>&nbsp;";
        //    Console.WriteLine(_info_0_text);
        //    z_info_new = new("INFO;", ";", _info_0_text);
        //    boolChecknbsp = true;

        //    if (z_slow > 12 && _line_string.Contains("<p>&nbsp;"))
        //    {
        //        z_info_new = new(_count.ToString(), "line contains <p>&nbsp;", _line_string);
        //        z_info_list.Add(z_info_new);

        //        _line_string = _line_string.Replace("&nbsp;", " ");
        //        _line_string = _line_string.Replace("<p>&nbsp;</p>" + z_newline, " ");
        //    }
        //}

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

        _comment_inside_code = "add missing z_blank after DATE for e.g. ABT 10.1984";
        lineString = lineString.Replace("DATE.", "DATE .");

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
            //Console.WriteLine(z_newline + "A " + _line_string);
            //z_info_new = new(z_newline + "A " + _line_string);
            //z_info_list.Add(z_info_new);

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
                + "_first_blank =" + firstblank
                + ", =" + secondblankOrEnd
                + ", =" + thirdblankOrEnd + _newline
                + ", " + _line_string
                //+ ", " + _line_string
                ;
            Console.WriteLine(_newline + _text);
            //Console.WriteLine(z_newline + _introText);



            //Console.WriteLine("A " + _line_string);
            _length1 = _line_string.IndexOf('{');

            if (_line_string.Length < _length1)
                anameString = _line_string.Substring(1, _length1);

            _length = anameString.IndexOf('"');
            _nr = anameString.Substring(0, _length);
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
    private static List<string> A01_Read_Input(string path, string file, string extension)
    {
        var result = new List<string>();

        _info_0_text = "starting >> input: " + path + file + extension;
        Xwrite("Step_1202", true, _info_0_text);

        //DateTime z_start_time_global = DateTime.Now;
        int lastPeListIndex = 0;
        int _count = 0;
        z_nextGoalOfLines = 1000000 - 2;

        string fullPath = Path.Combine(path, file + extension);
        if (!File.Exists(fullPath))
        {
            _info_0_text = "Input-File not found >> " + path + file + extension;
            Xwrite("Step_1111", true, _count + _info_0_text);
            //_ = MessageBox.Show("Input-File not found", "BEWARE", MessageBoxButtons.OK);
            //return result;
        }

        //db = new Dictionary<string, string>();

        //#pragma warning disable SYSLIB0001 // Type or member is obsolete
        //using (StreamReader _stream_Reader = new(fullPath, Encoding.UTF7))
        using (StreamReader _stream_Reader = new(fullPath, Encoding.UTF8))
        {
            _count = 0;
            z_nextGoalOfLines = 1000000 - 1;
            while (_stream_Reader.Peek() != -1)
            {
                _count++;
                if (_count > z_nextGoalOfLines)
                {
                    _info_0_text = " reading > " + _count.ToString() + ":_start=;" + z_start_time_global;
                    Xwrite("Step_1100", true, _info_0_text);
                    z_nextGoalOfLines += 1000000;
                }

                string? _line = _stream_Reader.ReadLine();
                if (_line == null) continue;

                //Debugger.Break(); return "";

                // perform replacements (reuse existing method)


                _comment_inside_code = "NOT HERE _line = DoReplace_Months_Days(_line);";

                string key = _count.ToString();
                //db.Add(z_key, _line);
                result.Add(_line);

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

        return result;
    }

    public static string GetUpdateString(string _upd)
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

            , string i_cens
            , string i_cens_plac
            //, string i_cens_date
            //, string i_cens_age

            , string i_emig
            , string i_emig_plac

            , string i_immi
            , string i_immi_plac

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
        public string I_CONF = i_conf;
        public string I_CONF_DATE = i_conf_date;
        public string I_CONF_PLAC = i_conf;
        public string I_RESI = i_resi;
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
    static async Task Main()
    {
        string _path = "C:/DB/";
        string _read_file = "__ged_IN";
        string _extension = ".ged";

        string z_0 = "";
        string z_1 = "";
        string z_2 = "";
        //private static 
        //bool _bool_sex_u = false;
        //bool bool_nbsp = false;
        //bool boolChecknbsp = false;
        //bool boolCheckUnklar = false;
        //bool boolSaveSingleEntry = false;
        //string z_blank = "";
        //string _secondblankOrEnd;
        string unknownKeyText = "unknown";
        string gedheadText = "";

        string _first = "";
        string _update_string = "";
        string _source_string = "";
        string _entry_text = "";
        int secondblankOrEnd = 0;
        z_nextGoalOfLines = _count + 1;

        int _pe_list_index = -1;
        int _fam_list_index = -1;

        string _date;
        string _place;
        string _dio = "";
        string _cb;
        string keyPrevious_pe = "";
        string keyPrevious_fam = "";
        string keyPrevious_note = "";
        //string keyPrevious_album = "";
        string keyPrevious_sour = "";
        //string keyPrevious_obj = "";
        string keyPrevious_indi = "";
        string _day;
        string _month;
        string _year;

        string _immi_text = "";
        //string _kind;
        string _date_val;
        string _deathdateString = "";
        //int _count = A00_Code._count;
        string[] _dateColl;

        string _famsText;
        string _deatText;
        string _pers_line_text;
        //string _fam_line_text;
        //string _album_line_text;
        //string _source_line_text;


        string _pers_line_hint;

        string _dateString = _entry_text + _immi_text;
        //string _line_string = "";
        z_blank = "";
        //List<PersLine> _persLineList = [];


        List<string> _all_lines = await Task.Run(() => A01_Read_Input(_path, _read_file, _extension));

        A05_DoAutosave(_all_lines);

        _comment_inside_code = " > clear Immediate Window manually" + _source_string + _update_string;
        Xwrite("Step_8866", true, _comment_inside_code);

        _comment_inside_code = "Trace.WriteLine goes to Output inside VS while Console.Writeline goes to Prompt-Window";

        //_count = unknownKeyCount;


        //Do_All_lines(_all_lines);        

        _count = 0;
        z_nextGoalOfLines = 20000;
        int _pe_index_count = 0;
        int _fam_index_count = 0;


        foreach (var _line in _all_lines)
        {
            _count += 1;
            //Trace.WriteLine(_count + " > " + _line);

            //_info_0_text = _count + " > Orig.Line= > " + _line;
            //Console.WriteLine(_info_0_text);
            string _valueAdd = "";

            DoReplace_stuff(_line, out string _line_string);

            _line_string = DoReplace_Months_Days(_line_string);

            _comment_inside_code = "Check input here" + "if (_line_string.Length == 0)" + "if (_count > z_nextGoalOfLines)";
            //            _info_0_text = z_newline
            //                + "now > " + _line_string + z_newline
            //                + "org > " + _line
            //+ z_newline
            //                ;
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

            _first = _line_string[..1];//.ToString();
            _ = int.TryParse(_first, out int _first_int);

            if (_first_int == 0 && _count > z_nextGoalOfLines)
            {
                _info_0_text = "Step_1400 > " + DateTime.Now
                    + " > " + z_nextGoalOfLines / 1000 + " TSD > Line= > " + _line_string + "           > Orig.= > " + _line;
                Console.WriteLine(_info_0_text);
                Trace.WriteLine(_info_0_text);
                //z_info_new = new("INFO;", ";", _info_0_text);
                //z_info_list.Add(z_info_new);

                z_nextGoalOfLines += 20000;
            }


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
            //    //_update_string = GetUpdateString(_line_string);
            //    _update_string = _line_string;
            //}

            //if (_line_string == "2 AGE 74")
            //{
            //    //Debugger.Break();
            //}
            secondblankOrEnd = Get_2nd_blank(1, _line_string);



            if (_first != "0")
            {
                //_entry_text += keyPrevious_pe + ";" + _line_string + " > ";
            }

            _comment_inside_code = "firstchar=0";
            if (_first_int == 0)
            {

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


                // _first_int == 0"

                if (_line_string.Substring(2, 4).ToString() == "HEAD")
                {
                    z_0 = "H_";
                    z_key = "HEAD";
                    keyPrevious_pe = z_key;
                    //continue;
                }

                if (_line_string.Substring(2, 2).ToString() == @"@U")
                {
                    z_0 = "U_";
                    Console.WriteLine("#### skipped 'U' = {0}", _line_string);
                    //continue;
                }

                // NOTE
                if (_line_string.EndsWith("NOTE"))
                {
                    z_0 = "N_";
                    //Console.WriteLine("#### skipped 'NOTE' = {0}", _line_string);

                    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    z_key = z_key.Replace("@", "");
                    keyPrevious_note = z_key;

                    Note noteNew = new(keyPrevious_note, z_blank, z_blank, z_blank);
                    z_note_list.Add(noteNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //continue;
                }


                // INDI
                //int _pe_index_count = 0;
                if (_line_string.EndsWith("INDI"))  // not TRLR = each entry
                {
                    z_0 = "I_";

                    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    keyPrevious_indi = z_key.Replace("@", "");
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
                        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 51
                        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank  // 61
                        , z_blank
                        );
                    _pe_list.Add(peNew);

                    _pe_index.Add(keyPrevious_indi, _pe_index_count);
                    _pe_index_count = +1;
                    //_pers_text_coll_global.Clear();
                    //Console.WriteLine("adding = {0}", keyPrevious);
                    //continue;
                }

                // FAM
                _comment_inside_code = "ab hier families";
                //int _fam_index_count = 0;
                if (_line_string.EndsWith("FAM"))
                {
                    z_0 = "F_";
                    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    z_key = z_key.Replace("@", "");
                    keyPrevious_fam = z_key;

                    Fam famNew = new(keyPrevious_fam
                        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 11//
                        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//  // 21
                        , z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank, z_blank//,
                        );


                    _fam_index.Add(keyPrevious_fam, _fam_index_count);
                    _fam_index_count = +1;
                    _fam_list.Add(famNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //continue;
                }
                //else
                //{
                //    unknownKeyCount += 1;
                //    keyPrevious = z_key;
                //    //z_lastPeListIndex_DONE = z_lastPeListIndex;
                //    //pe peNew = new pe(keyPrevious,"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                //    //_pe_list.Add(peNew);
                //    z_key = "unknownKeyCount" + unknownKeyCount.ToString();

                //}


                // ALBUM
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

                if (_line_string.EndsWith("TRLR"))
                {
                    z_0 = "END_";
                    //Console.WriteLine("___________________________________________________start;" + z_start_time_global + ";now;" + DateTime.Now + ";END  ;#### TRLR = End of file");
                    _info_0_text = "TRLR = End of file > " + _count;
                    Xwrite("Step_9985", true, _info_0_text);
                    //continue;
                }


                //string keyPrevious_sour = "";
                if (_line_string.EndsWith("SOUR"))  // SOUR
                {
                    z_0 = "S_";
                    //z_key = _line_string.Substring(3, secondblankOrEnd - 3).ToString().Trim();
                    z_key = _line_string[3..secondblankOrEnd].ToString().Trim();
                    z_key = z_key.Replace("@", "");
                    keyPrevious_sour = z_key;

                    Source sourceNew = new(keyPrevious_sour, z_blank, z_blank, z_blank);//, z_blank, z_blank, z_blank, z_blank);
                    z_source_list.Add(sourceNew);
                    //Console.WriteLine("adding FAM = {0}", keyPrevious);
                    //continue;
                }
            }
            //if (_first_int == 0)
            //{
            //    _value = _value.Replace("=-", "-");
            //    //Console.Xwrite("adding keyPrevious = {0}: {1}" + z_newline, keyPrevious, _value);
            //    //Console.Xwrite("adding keyPrevious = {0}" + z_newline, keyPrevious);
            //    //_db.Add(keyPrevious, _value);
            //    //dataGridView1.Rows.Add(keyPrevious, _value);
            //    _value = "";
                z_lastPeListIndex_DONE = z_lastPeListIndex - 1;
            //}
            _comment_inside_code = "End of:  if (_first == 0";


            //_pe_index.Clear();
            //for (int i = 0; i < _pe_list.Count; i++)
            //{
            //    _pe_index.Add(_pe_list[i].AA_I_INDEX, i);
            //}

            //_fam_index.Clear();
            //for (int i = 0; i < _fam_list.Count; i++)
            //{
            //    _fam_index.Add(_fam_list[i].AA_F_INDEX, i);
            //}

            if (_first_int == 0)
            {
                //_pe_list_index = _pe_list.FindIndex(item => item.AA_I_INDEX == keyPrevious_indi);
            //int _fam_list_index = _fam_list.FindIndex(item => item.AA_F_INDEX == keyPrevious_fam);
                _pe_list_index = _pe_index.GetValueOrDefault(keyPrevious_indi, -1);
                _fam_list_index = _fam_index.GetValueOrDefault(keyPrevious_indi, -1);
            }
            //if (_pe_index.TryGetValue(keyPrevious_pe, out int value_pe))
            //{
            //    _pe_list_index = value_pe;
            //}

            //int _fam_list_index = 0;// = _pe_list.FindIndex(item => item.AA_I_INDEX == keyPrevious);
            //if (_fam_index.TryGetValue(keyPrevious_fam, out int value_fam))
            //{
            //    _fam_list_index = value_fam;
            //}

            //_pe_index.Add(_pe_list[_pe_list_index].AA_I_INDEX, _pe_list_index);
            int lastPeListIndex = _pe_list_index;
            //int z_lastPeListIndex_DONE;

            //_fam_index.Add(_fam_list[_pe_list_index].AA_F_INDEX, _pe_list_index);
            //int notelistIndex = z_note_list.FindIndex(item => item.AA_N_INDEX == keyPrevious_note);
            int notelistIndex = 0;
            //int sourcelistIndex = z_source_list.FindIndex(item => item.AA_S_INDEX == keyPrevious_sour);
            int sourcelistIndex = 0;
            //int albumlistIndex = z_album_list.FindIndex(item => item.AA_A_INDEX == keyPrevious_album);
            int albumlistIndex = 0;
            //_pe_list.Add(peNew);


            //#region _first_int == 1"
            if (_first_int == 1)
            {
                if (_line_string.Length > 5)
                    z_1 = z_0 + _line_string.Substring(2, 4).Trim(); // + z_separator;
                else z_1 = z_0 + _line_string.Substring(2, 3).Trim(); // + z_separator;

                //_valueAdd = "";
                //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                //if (_line_string.Length != z_1.Length + 2)
                //{
                //_valueAdd =
                //z_1 + z_separator +  // without
                //_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;
                //z_1.Substring(secondblankOrEnd + 1, z_1.Length - secondblankOrEnd - 1) + z_separator;
                //}
                if (_valueAdd.Length < 3)
                {
                    //_valueAdd = _line_string.Substring(2, _line_string.Length - 2);
                    _valueAdd = _line_string[2..];
                }

                if (_valueAdd == "ENGA") _valueAdd = "verlobt";
                if (_valueAdd == "MARL") _valueAdd = "StAmt";

                //else { _valueAdd}
                //_value += CleanText(_valueAdd);
                _value += _valueAdd;

                //_valueAdd = CleanText(_valueAdd);
                //_valueAdd = CleanText(_valueAdd);

                switch (z_1)
                {
                    // FAM
                    case "F_HUSB": _fam_list[_fam_list_index].F_HUSB = DoCleanID(_valueAdd); break;
                    case "F_WIFE": _fam_list[_fam_list_index].F_WIFE = DoCleanID(_valueAdd); break;
                    case "F_RIN": /*_fam_list[_fam_list_index].F_RIN = _valueAdd;*/ break;
                    case "F__UID": /*_fam_list[_fam_list_index].F__UID = _valueAdd;*/ break;
                    case "F_CHIL": _fam_list[_fam_list_index].F_CHIL += DoCleanID(_valueAdd) + " # "; break;
                    case "F__UPD": _fam_list[_fam_list_index].F__UPD = _valueAdd; break;
                    case "F_MARR": _fam_list[_fam_list_index].F_MARR = _valueAdd; break;
                    case "F_MARL": _fam_list[_fam_list_index].F_MARL = _valueAdd; break;  // Hochzeit Standesamt
                    case "F_DIV": _fam_list[_fam_list_index].F_DIV = _valueAdd; break;  // Divorce
                    case "F_ENGA": _fam_list[_fam_list_index].F_ENGA = _valueAdd; break; // Verlobung
                    case "F_ANUL": _fam_list[_fam_list_index].F_ANUL = _valueAdd; break;
                    case "F_EVEN": _fam_list[_fam_list_index].F_EVEN = _valueAdd; break;

                    // SOURCE
                    case "S_AUTH": z_source_list[sourcelistIndex].S_AUTH = _valueAdd; break;
                    case "S_TITL": z_source_list[sourcelistIndex].S_TITL = _valueAdd; break;
                    //case "S_PUBL": z_source_list[sourcelistIndex].S_PUBL = _valueAdd; break;
                    case "S_TEXT": z_source_list[sourcelistIndex].S_TEXT = _valueAdd; break;
                    case "S__TYP": /*z_source_list[sourcelistIndex].S__TYP = _valueAdd;*/ break;
                    //case "S__MED": z_source_list[sourcelistIndex].S__MED = _valueAdd; break;

                    // ALBUM = Photos
                    //case "S_AUTH": z_album_list[albumlistIndex].S_AUTH = _valueAdd; break;
                    case "A_TITL": z_album_list[albumlistIndex].A_TITL = _valueAdd; break;
                    case "A_DESC": z_album_list[albumlistIndex].A_DESC = _valueAdd; break;
                    //case "S_TEXT": z_album_list[albumlistIndex].S_TEXT = _valueAdd; break;
                    case "A__UPD": z_album_list[albumlistIndex].A__UPD = _valueAdd; break;
                    case "A_RIN": /*z_album_list[albumlistIndex].A_RIN = _valueAdd;*/ break;


                    // INDI
                    case "I_NAME": _pe_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //case "I_NAME": _pe_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //case "I_NAME": _pe_list[_pe_list_index].I_NAME = _valueAdd; break;
                    //case "I_NAME": _pe_list[_pe_list_index].I_NAME = _valueAdd; break;
                    case "I_SEX":
                        _pe_list[_pe_list_index].I_SEX = _valueAdd;
                        //if (z_slow > 0)
                        //{
                        //    if (_bool_sex_u == false && _valueAdd.Contains("U"))// || _valueAdd.Contains("") || _valueAdd.Contains(" "))
                        //    {
                        //        errortext = z_blank + "SEX contains U"
                        //            + z_blank + _pe_list[_pe_list_index].I_SEX
                        //            + " verh. " + _pe_list[_pe_list_index].I_NAME_MARNM
                        //            + z_blank + _pe_list[_pe_list_index].I_NAME_SURN
                        //            + z_blank + _pe_list[_pe_list_index].I_NAME_GIVN
                        //            + z_blank + _pe_list[_pe_list_index].AA_I_INDEX
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
                    case "I_BIRT": _pe_list[_pe_list_index].I_BIRT = _valueAdd; break;
                    case "I_DEAT":
                        _pe_list[_pe_list_index].I_DEAT = _valueAdd;

                        //if (_valueAdd == "DEAT Y")
                        //    _pe_list[_pe_list_index].I_SEX += "d";
                        //else
                        //    _pe_list[_pe_list_index].I_SEX += "a";

                        break;

                    case "I_BURI": /*_pe_list[_pe_list_index].I_BURI = _valueAdd;*/ break;
                    case "I_FAMS": _pe_list[_pe_list_index].I_FAMS += _valueAdd + " + "/* + z_ht*/; break;
                    case "I_FAMC": _pe_list[_pe_list_index].I_FAMC += _valueAdd + " + "; break;


                    case "I_RESI": _pe_list[_pe_list_index].I_RESI = _valueAdd; break;
                    case "I_ADDR": _pe_list[_pe_list_index].I_RESI = _valueAdd; break;  // same like RESI ??
                    case "I_CONF": _pe_list[_pe_list_index].I_CONF = _valueAdd; break;
                    case "I_RELI": _pe_list[_pe_list_index].I_RELI = _valueAdd; break;
                    case "I_OCCU": _pe_list[_pe_list_index].I_OCCU = _valueAdd; break;
                    case "I_CENS": _pe_list[_pe_list_index].I_CENS = _valueAdd; break;
                    case "I_NOTE": _pe_list[_pe_list_index].I_NOTE = _valueAdd; break;

                    case "I_RIN": /*_pe_list[_pe_list_index].I_RIN = _valueAdd;*/ break;
                    case "I__UID": /*_pe_list[_pe_list_index].I__UID = _valueAdd;*/ break;

                    case "S_RIN": /*z_source_list[sourcelistIndex].S_RIN = _valueAdd;*/ break;
                    case "S__UID": /*z_source_list[sourcelistIndex].S__UID = _valueAdd;*/ break;

                    //case "I_RIN ": _pe_list[_pe_list_index].I_RIN = _valueAdd; break;
                    //case "I__RIN": _pe_list[_pe_list_index].I_RIN = _valueAdd; break;
                    //case "I_UID ": _pe_list[_pe_list_index].I_UID = _valueAdd; break;

                    case "I__UPD": _pe_list[_pe_list_index].I_UPD = _valueAdd; break;
                    case "I_CHAN": _pe_list[_pe_list_index].I_UPD = "### Change instead UPD ### " + _valueAdd; break;
                    case "N_CONC": z_note_list[notelistIndex].N_CONC = _valueAdd; break;
                    case "N_PRIN": z_note_list[notelistIndex].N_PRIN = _valueAdd; break;
                    case "N_RIN": /*z_note_list[notelistIndex].N_RIN = _valueAdd;*/ break;

                    case "I_EVEN": _pe_list[_pe_list_index].I_EVEN = _valueAdd; break;
                    case "I_EMIG": _pe_list[_pe_list_index].I_EMIG = _valueAdd; break;
                    case "I_IMMI": _pe_list[_pe_list_index].I_IMMI = _valueAdd; break;

                    case "I_NATI": /*_pe_list[_pe_list_index].I_NATI = _valueAdd;*/ break;

                    case "H_DATE": gedheadText += _valueAdd; break;
                    case "H_GEDC": gedheadText += _valueAdd; break;
                    case "H_CHAR": gedheadText += _valueAdd; break;
                    case "H_LANG": gedheadText += _valueAdd; break;
                    case "H_SOUR": gedheadText += _valueAdd; break;
                    case "H_DEST": gedheadText += _valueAdd; break;
                    case "H__PRO": /*gedheadText += _valueAdd;*/ break;
                    case "H__EXP": /*gedheadText += _valueAdd;*/ break;
                    case "H_FILE": gedheadText += _valueAdd; break;

                    case "I_SOUR": _pe_list[_pe_list_index].I_SOUR = _valueAdd; break;

                    case "I_OBJE": /*_pe_list[_pe_list_index].I_OBJE = _valueAdd;*/ break;

                    //case "I_MARR": _pe_list[_fam_list_index].I_MARR = _valueAdd; break;
                    //case "I_DIV ": _pe_list[_fam_list_index].I_DIV = _valueAdd; break;
                    //case "I_NATI": _pe_list[_pe_list_index].I_NATI = _valueAdd; break;

                    default:
                        //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);

                        // these are used by Ahnenblatt
                        //if (z_1 != "S__UPD" || z_1 != "H_SUBM" || z_1 != "H__NAV" || z_1 != "H__HOM" || z_1 != "H_NAME" || z_1 != "F__STA" || z_1 != "F__MAR")
                        //{
                        //    Console.WriteLine(z_newline + "Unknown z_key at z_1 = {0}", z_1);
                        //}
                        unknownKeyText = z_newline + "z_key not used at z_1 = " + z_1 + " at line: " + _count.ToString() + ": _value = " + _valueAdd;
                        Console.WriteLine(/*z_newline + */"z_key not used at z_1     = " + z_1 + "        at line: " + _count.ToString() + ": _value = " + _valueAdd);

                        // V1 ignored:


                        if (z_1 == "H_SUBM") unknownKeyText = ""; // 1 SUBM @U1@
                        if (z_1 == "H_SUB") unknownKeyText = "";  // 1 SUBM @U1@
                        if (z_1 == "H__NAV") unknownKeyText = "";
                        if (z_1 == "H__RIN") unknownKeyText = ""; // 1 _RINS I1228,F76,N11316,M0,R0,S22,U1,L0,P0,Q0,IF251248,FF36635
                        if (z_1 == "H__UID") unknownKeyText = ""; // 1 _UID VWD90D6C-E63C-4C36-8689-3A304C67E28D
                        if (z_1 == "H__DES") unknownKeyText = ""; // 1 _DESCRIPTION_AWARE Y
                        if (z_1 == "H_DES") unknownKeyText = "";  // 1 DEST MYHERITAGE
                        if (z_1 == "H__USE") unknownKeyText = ""; // 1 _USERNAME r.r
                        if (z_1 == "H__DIS") unknownKeyText = ""; // 
                        if (z_1 == "H__FAC") unknownKeyText = ""; // 1 _FACTS_DEFRAGGED Y
                        if (z_1 == "H__HOM") unknownKeyText = "";
                        if (z_1 == "H_NAME") unknownKeyText = "";
                        if (z_1 == "H_CHA") unknownKeyText = "";  // 1 CHAR UTF-8
                        if (z_1 == "H_LAN") unknownKeyText = "";  // 1 LANG German
                        if (z_1 == "H_SOU") unknownKeyText = "";  // 1 SOUR MYHERITAGE
                        if (z_1 == "F__STA") unknownKeyText = "";
                        if (z_1 == "F__MAR") unknownKeyText = "";
                        if (z_1 == "S__UPD") unknownKeyText = "";
                        if (z_1 == "I_BURI") unknownKeyText = "";
                        if (z_1 == "U_RIN") unknownKeyText = "";
                        if (z_1 == "I_BAPM") unknownKeyText = ""; // Taufpaten
                        if (z_1 == "I__MTT") unknownKeyText = ""; // MTTAG

                        if (unknownKeyText != "")
                            Console.WriteLine(z_1 + " ignored: _value = " + _valueAdd);

                        break;
                }
                //_valueAdd = "";
            }
            _comment_inside_code = "End of:  if (_first == 1";
            // end of : if (_first_int == 1")
            //#endregion _first = 1

            //#region _first = 2
            //_first_int == 2"
            if (_first_int == 2)
            {
                z_2 = _line_string.Substring(2, 4);

                _valueAdd = "";
                //Console.WriteLine("_line_string.Length = {1}, line = {0}", _line_string, _line_string.Length);
                if (_line_string.Length > 6)
                {
                    //_valueAdd =_line_string.Substring(secondblankOrEnd + 1, _line_string.Length - secondblankOrEnd - 1) + z_separator;
                    _valueAdd = _line_string[secondblankOrEnd..];
                    //z_0 + z_1 + z_separator + "-" + z_2 + z_separator + // without
                }


                //_valueAdd = CleanText(_valueAdd);
                //_valueAdd = CleanText(_valueAdd);

                //_value += _valueAdd;
                _value += _valueAdd + z_separator;

                string v0v1v2 = z_0 + z_1 + "_" + z_2;

                bool boolCheckGIVEN = false;

                switch (v0v1v2)
                {
                    // FAM
                    case "F_F_MARR_DATE": _fam_list[_fam_list_index].F_MARR_DATE = _valueAdd; break;
                    case "F_F_MARR_PLAC": _fam_list[_fam_list_index].F_MARR_PLAC = _valueAdd; break;
                    case "F_F_MARR_NOTE": _valueAdd = _valueAdd.Replace(",", "#"); _fam_list[_fam_list_index].F_MARR_NOTE = _valueAdd; break;
                    case "F_F_MARR__UID": /*_fam_list[_fam_list_index].F_MARR__UID = _valueAdd;*/ break;
                    case "F_F_MARR_RIN ": /*_fam_list[_fam_list_index].F_MARR_RIN = _valueAdd;*/ break;
                    case "F_F_EVEN_TYPE": _fam_list[_fam_list_index].F_EVEN_TYPE = _valueAdd; break;
                    case "F_F_EVEN_DATE": _fam_list[_fam_list_index].F_EVEN_DATE = _valueAdd; break;
                    case "F_F_EVEN_PLAC": _fam_list[_fam_list_index].F_EVEN_PLAC = _valueAdd; break;
                    case "F_F_EVEN__UID": /*_fam_list[_fam_list_index].F_EVEN__UID = _valueAdd;*/ break;
                    case "F_F_EVEN_RIN ": /*_fam_list[_fam_list_index].F_EVEN_RIN = _valueAdd;*/ break;
                    case "F_F_EVEN_NOTE": _fam_list[_fam_list_index].F_EVEN_NOTE = _valueAdd; break;
                    // MARL
                    case "F_F_MARL_DATE": _fam_list[_fam_list_index].F_MARL_DATE = _valueAdd; break;
                    case "F_F_MARL_PLAC": _fam_list[_fam_list_index].F_MARL_PLAC = _valueAdd; break;
                    case "F_F_MARL_NOTE": _fam_list[_fam_list_index].F_MARL_NOTE = _valueAdd; break;
                    // DIV
                    case "F_F_DIV_DATE": _fam_list[_fam_list_index].F_DIV_DATE = _valueAdd; break;
                    case "F_F_DIV_PLAC": _fam_list[_fam_list_index].F_DIV_PLAC = _valueAdd; break;
                    case "F_F_DIV_NOTE": _fam_list[_fam_list_index].F_DIV_NOTE = _valueAdd; break;
                    // ENGA
                    case "F_F_ENGA_DATE": _fam_list[_fam_list_index].F_ENGA_DATE = _valueAdd; break;
                    case "F_F_ENGA_PLAC": _fam_list[_fam_list_index].F_ENGA_PLAC = _valueAdd; break;
                    case "F_F_ENGA_NOTE": _fam_list[_fam_list_index].F_ENGA_NOTE = _valueAdd; break;
                    // ANUL
                    case "F_F_ANUL_DATE": _fam_list[_fam_list_index].F_ANUL_DATE = _valueAdd; break;
                    case "F_F_ANUL_PLAC": _fam_list[_fam_list_index].F_ANUL_PLAC = _valueAdd; break;
                    case "F_F_ANUL_NOTE": _fam_list[_fam_list_index].F_ANUL_NOTE = _valueAdd; break;

                    //    // SOUR

                    //case "S_S_SOUR_CONC": z_source_list[sourcelistIndex].S_SOUR_CONC = _valueAdd; break;
                    //case "S_S_TEXT_CONC": z_source_list[sourcelistIndex].S_TEXT_CONC = _valueAdd; break;


                    // HEADER
                    case "H_H_GEDC_VERS": gedheadText += _valueAdd; break;
                    case "H_H_GEDC_FORM": gedheadText += _valueAdd; break;
                    case "H_H_SOUR_NAME": gedheadText += _valueAdd; break;
                    case "H_H_SOUR_VERS": gedheadText += _valueAdd; break;
                    case "H_H_SOUR__RTL": gedheadText += _valueAdd; break;
                    case "H_H_SOUR_CORP": gedheadText += _valueAdd; break;

                    case "H_H_DEST": gedheadText += _valueAdd; break;
                    case "H_H__PRO": gedheadText += _valueAdd; break;



                    // ALBUM
                    //case "H_H_GEDC_VERS": gedheadText += _valueAdd; break;
                    //case "H_H_GEDC_FORM": gedheadText += _valueAdd; break;
                    //case "H_H_SOUR_NAME": gedheadText += _valueAdd; break;
                    //case "H_H_SOUR_VERS": gedheadText += _valueAdd; break;
                    //case "H_H_SOUR__RTL": gedheadText += _valueAdd; break;
                    //case "H_H_SOUR_CORP": gedheadText += _valueAdd; break;




                    case "I_I_BIRT_DATE":
                        _pe_list[_pe_list_index].I_BIRT_DATE = _valueAdd.Trim();
                        break;
                    case "I_I_NAME_GIVN":
                        _pe_list[_pe_list_index].I_NAME_GIVN = _valueAdd;
                        _pe_list[_pe_list_index].I_NAME_GIVN = _valueAdd;

                        if (boolCheckGIVEN == false)
                        {
                            boolCheckGIVEN = true;
                            //if (z_slow < 2)
                            //{
                            //    if (_valueAdd.Contains("doppelt") || _valueAdd.Contains("ein zwei") || _valueAdd.Contains("die selbe"))
                            //    {
                            //        if (DontCheck_Given(_pe_list[_pe_list_index].AA_I_INDEX) == false)
                            //        {
                            //            errortext = separator + "GIVEN contains ..."
                            //                + separator + _pe_list[_pe_list_index].I_NAME_NSFX
                            //                + "verh.;" + _pe_list[_pe_list_index].I_NAME_MARNM
                            //                + separator + _pe_list[_pe_list_index].I_NAME_SURN
                            //                + separator + _pe_list[_pe_list_index].I_NAME_GIVN
                            //                + separator + _pe_list[_pe_list_index].AA_I_INDEX
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
                    case "I_I_NAME_NICK": _pe_list[_pe_list_index].I_NAME_NICK = _valueAdd; break;
                    case "I_I_NAME__MAR": _pe_list[_pe_list_index].I_NAME_MARNM = _valueAdd; break;
                    case "I_I_NAME_SURN": _pe_list[_pe_list_index].I_NAME_SURN = _valueAdd; break;

                    case "I_I_NAME_NPFX": _pe_list[_pe_list_index].I_NAME_NPFX = _valueAdd; break;
                    case "I_I_NAME__FOR": _pe_list[_pe_list_index].I_NAME__FOR = _valueAdd; break;

                    case "I_I_BIRT_PLAC": _pe_list[_pe_list_index].I_BIRT_PLAC = _valueAdd; break;
                    case "I_I_BIRT_RIN ": /*_pe_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    case "I_I_BIRT__UID": /*_pe_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;
                    case "I_I_BIRT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe_list[_pe_list_index].I_BIRT_NOTE = _valueAdd; break;

                    case "I_I_DEAT_DATE": _pe_list[_pe_list_index].I_DEAT_DATE = _valueAdd.Trim(); break;
                    case "I_I_DEAT_PLAC": _pe_list[_pe_list_index].I_DEAT_PLAC = _valueAdd; break;
                    case "I_I_DEAT_CAUS": _pe_list[_pe_list_index].I_DEAT_CAUS = _valueAdd; break;
                    case "I_I_DEAT_AGE ": _pe_list[_pe_list_index].I_DEAT_AGE = _valueAdd; break;
                    case "I_I_DEAT__UID": /*_pe_list[_pe_list_index].I_DEAT_UID = _valueAdd;*/ break;
                    case "I_I_DEAT_RIN ": /*_pe_list[_pe_list_index].I_DEAT_RIN = _valueAdd;*/ break;
                    case "I_I_DEAT_NOTE": _valueAdd = _valueAdd.Replace(";", "#"); _pe_list[_pe_list_index].I_DEAT_NOTE = _valueAdd; break;
                    case "I_I_BURI_DATE": /*_pe_list[_pe_list_index].I_BURI_DATE = _valueAdd.Trim();*/ break;
                    case "I_I_BURI_PLAC": _pe_list[_pe_list_index].I_BURI_PLAC = _valueAdd; break;
                    case "I_I_BURI_RIN ": /*_pe_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    case "I_I_BURI__UID": /*_pe_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;

                    //case "I_I_DIV_DATE": _pe_list[_pe_list_index].I_DIV_DATE = _valueAdd; break;
                    //case "I_I_DIV_PLAC": _pe_list[_pe_list_index].I_DIV_PLAC = _valueAdd; break;
                    case "I_I_RESI_EMAI": /*_pe_list[_pe_list_index].I_EMAIL = _valueAdd;*/ break;
                    case "I_I_BAPM_PLAC": /*_pe_list[_pe_list_index].I_BAPM_PLAC = _valueAdd;*/ break;
                    case "I_I_BAPM_DATE": /*_pe_list[_pe_list_index].I_BAPM_DATE = _valueAdd;*/ break;
                    case "I_I_CONF_PLAC": _pe_list[_pe_list_index].I_CONF_PLAC = _valueAdd; break;
                    case "I_I_CONF_DATE": _pe_list[_pe_list_index].I_CONF_DATE = _valueAdd; break;
                    case "I_I_OCCU_PLAC": _pe_list[_pe_list_index].I_OCCU_PLAC = _valueAdd; break;
                    case "I_I_OCCU_DATE": _pe_list[_pe_list_index].I_OCCU_DATE = _valueAdd; break;
                    case "I_I_OCCU_AGE ": /*_pe_list[_pe_list_index].I_OCCU_AGE = _valueAdd;*/ break;

                    case "I_I_CENS_PLAC": _pe_list[_pe_list_index].I_CENS_PLAC = _valueAdd; break;
                    //case "I_I_CENS_DATE": _pe_list[_pe_list_index].I_CENS_DATE = _valueAdd; break;
                    //case "I_I_OCCU_AGE ": _pe_list[_pe_list_index].I_OCCU_AGE = _valueAdd; break;
                    //case "I_I_RESI_EMAI": _pe_list[_pe_list_index].I_EMAIL = _valueAdd; break;

                    //case "I_I_RESI_DATE": _pe_list[_pe_list_index].I_RESI_DATE = _valueAdd; break;
                    //case "I_I_RESI_AGE ": _pe_list[_pe_list_index].I_RESI_AGE = _valueAdd; break;

                    //case "I_I_ADDR_CONT": _pe_list[_pe_list_index].I_RESI_ADDR = "Adress available"; break; // same like RESI ?
                    case "I_I_RESI_ADDR": /*_pe_list[_pe_list_index].I_RESI_ADDR = _valueAdd;*/ break;

                    //case "I_I_RESI_PLAC": _pe_list[_pe_list_index].I_RESI_ADDR = " ### PLACE instead Address?:" + _valueAdd; break;
                    //case "I_I_RESI_PHON": _pe_list[_pe_list_index].I_RESI_PHON = _valueAdd; break;
                    case "I_I_RESI_FAX ": /*_pe_list[_pe_list_index].I_RESI_FAX = _valueAdd;*/ break;
                    case "I_I_RESI_NOTE": /*_pe_list[_pe_list_index].I_RESI_NOTE = _valueAdd;*/ break;
                    case "I_I_FAMC_PEDI": _pe_list[_pe_list_index].I_FAMC_PEDI = _valueAdd; break;

                    case "I_I_EVEN_DATE": _pe_list[_pe_list_index].I_EVEN_DATE = _valueAdd; break;
                    case "I_I_EVEN_NOTE": _pe_list[_pe_list_index].I_EVEN_NOTE = _valueAdd; break;
                    case "I_I_EVEN_AGE ": _pe_list[_pe_list_index].I_EVEN_AGE = _valueAdd; break;

                    case "I_I_EVEN__UID": /*_pe_list[_pe_list_index].I_EVEN_UID = _valueAdd;*/ break;
                    case "I_I_EVEN_RIN ": /*_pe_list[_pe_list_index].I_EVEN_RIN = _valueAdd;*/ break;
                    case "I_I_EVEN_TYPE": _pe_list[_pe_list_index].I_EVEN_TYPE = _valueAdd; break;
                    case "I_I_EVEN_PLAC": _pe_list[_pe_list_index].I_EVEN_PLAC = _valueAdd; break;

                    case "I_I_EMIG_DATE": _pe_list[_pe_list_index].I_EMIG = _valueAdd; break;
                    case "I_I_EMIG_PLAC": _pe_list[_pe_list_index].I_EMIG_PLAC = _valueAdd; break;

                    case "I_I_IMMI_DATE": _pe_list[_pe_list_index].I_IMMI = _valueAdd; break;
                    case "I_I_IMMI_PLAC": _pe_list[_pe_list_index].I_IMMI_PLAC = _valueAdd; break;

                    case "I_I_SOUR_DATA": /*_pe_list[_pe_list_index].I_SOUR_DATA = _valueAdd;*/ break;
                    case "I_I_SOUR_EVEN": /*_pe_list[_pe_list_index].I_SOUR_EVEN = _valueAdd;*/ break;
                    case "I_I_SOUR_PAGE": /*_pe_list[_pe_list_index].I_SOUR_PAGE = _valueAdd;*/ break;
                    case "I_I_SOUR_QUAL": /*_pe_list[_pe_list_index].I_SOUR_QUAL = _valueAdd;*/ break;
                    case "I_I_SOUR_QUAY": /*_pe_list[_pe_list_index].I_SOUR_QUAY = _valueAdd;*/ break;
                    case "I_I_SOUR_RIN ": /*_pe_list[_pe_list_index].I_BIRT_RIN = _valueAdd;*/ break;
                    case "I_I_SOUR__UID": /*_pe_list[_pe_list_index].I_BIRT_UID = _valueAdd;*/ break;


                    case "I_I_OBJE_FORM": _pe_list[_pe_list_index].I_OBJE_FILE = _valueAdd;/*_pe_list[_pe_list_index].I_OBJE_FORM = _valueAdd;*/ break;
                    case "I_I_OBJE_FILE": /*_pe_list[_pe_list_index].I_OBJE_FILE = _valueAdd;*/ break;
                    case "I_I_OBJE_TITL": /*_pe_list[_pe_list_index].I_OBJE_TITL = _valueAdd;*/ break;
                    case "I_I_OBJE_NOTE": /*_pe_list[_pe_list_index].I_OBJE_NOTE = _valueAdd;*/ break;
                    case "I_I_OBJE__PRI": /*_pe_list[_pe_list_index].I_OBJE__PRI = _valueAdd;*/ break;
                    case "I_I_OBJE__CUT": /*_pe_list[_pe_list_index].I_OBJE__CUT = _valueAdd;*/ break;
                    case "I_I_OBJE__PAR": /*_pe_list[_pe_list_index].I_OBJE__PAR = _valueAdd;*/ break;
                    case "I_I_OBJE__PER": /*_pe_list[_pe_list_index].I_OBJE__PER = _valueAdd;*/ break;
                    case "I_I_OBJE__PHO": /*_pe_list[_pe_list_index].I_OBJE__PHO = _valueAdd;*/ break;
                    case "I_I_OBJE__POS": /*_pe_list[_pe_list_index].I_OBJE__POS = _valueAdd;*/ break;
                    case "I_I_OBJE__DAT": /*_pe_list[_pe_list_index].I_OBJE__DAT = _valueAdd;*/ break;
                    case "I_I_OBJE__ALB": /*_pe_list[_pe_list_index].I_OBJE__ALB = _valueAdd;*/ break;
                    case "I_I_OBJE__FIL": /*_pe_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;  // FILESIZE
                    case "I_I_OBJE__PLA": /*_pe_list[_pe_list_index].I_OBJE__PLA = _valueAdd;*/ break;  // PLACE


                    case "I_I_ORDN_DATE": /*_pe_list[_pe_list_index].I_OBJE__FIL = _valueAdd;*/ break;


                    case "I_I_DATE_TIME": _pe_list[_pe_list_index].I_DATE_TIME = _valueAdd; break;
                    case "I_I_CHAN_DATE": _pe_list[_pe_list_index].I_DATE_TIME = "### DATE: CHAN instead D+T: " + _valueAdd; break;
                    case "I_I_NOTE_CONC": _pe_list[_pe_list_index].I_NOTE_CONC = _valueAdd; break;
                    //case "I_I_FILE": gedheadText += _valueAdd; break;

                    case "I_I_NAME_NSFX":
                        _pe_list[_pe_list_index].I_NAME_NSFX = _valueAdd;

                        //if (z_slow > 0)
                        //{
                        //    if (_valueAdd.Contains("unklar") || _valueAdd.Contains("Klärung") || _valueAdd.Contains("lebt?"))
                        //    {
                        //        if (DontCheck_NSFX(_pe_list[_pe_list_index].AA_I_INDEX) == false)
                        //        {
                        //            _info_0_text = z_blank //+ "____________________"
                        //            + z_blank + _pe_list[_pe_list_index].I_NAME_NSFX
                        //            + " verh. " + _pe_list[_pe_list_index].I_NAME_MARNM
                        //            + z_blank + _pe_list[_pe_list_index].I_NAME_SURN
                        //            + z_blank + _pe_list[_pe_list_index].I_NAME_GIVN
                        //            //+ " born: " + _pe_list[_pe_list_index].I_BIRT_DATE  // these Values are added later
                        //            //+ " marr: " + _pe_list[_pe_list_index].I_MARR_DATE
                        //            //+ " died: " + _pe_list[_pe_list_index].I_DEAT_DATE
                        //            + z_blank + _pe_list[_pe_list_index].AA_I_INDEX
                        //            ;
                        //            Console.WriteLine(_info_0_text);
                        //            AddError("7777777", "NO_0012 Suffix contains 'unklar'", _info_0_text);
                        //        }
                        //    }
                        //}
                        break;

                    //if (_pe_list[_pe_list_index].I_BIRT_DATE == "")
                    //{
                    //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1" + _pe_list[_pe_list_index].AA_I_INDEX;
                    //    Console.WriteLine(_info_0_text);
                    //    AddError("1231232", "INFO", _info_0_text);

                    //    _pe_list[_pe_list_index].I_SEX += "U";  // 3 groups ..each 65.000 for Excel limits: M, F and U plus MU and FU
                    //}


                    default:
                        //MessageBox.Show("Unknown z_key at z_2 = {0}", z_1);
                        //if (v0v1v2 != "F_F_MARR_ADDR" || v0v1v2 != "H_H__NAV__NAV" || v0v1v2 != "H_H_DATE_TIME")
                        unknownKeyText = z_newline + "z_key not used at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": _value = " + _valueAdd;
                        Console.WriteLine(/*z_newline + */"z_key not used at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": _value = " + _valueAdd);
                        //   >> message below

                        // z_2 ignored

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

                        if (v0v1v2 == "I_I_SOUR_PAGE ") unknownKeyText = "";
                        if (v0v1v2 == "I_I_SOUR_QUAY ") unknownKeyText = "";
                        if (v0v1v2 == "I_I_SOUR_DATA ") unknownKeyText = "";


                        if (unknownKeyText != "")
                            Console.WriteLine(/*z_newline + */"Unknown z_key at v0v1v2 = " + v0v1v2 + " at line: " + _count.ToString() + ": _value = " + _valueAdd);

                        break;

                }


                //_valueAdd = "";

            }
            _comment_inside_code = "End of:  if (_first == 2";
        }
        _comment_inside_code = "End of > foreach _all_lines";


        _comment_inside_code = "boolCheckUnklar == false";
        //if (z_slow < 2 && boolCheckUnklar == false)
        //{
        //    _info_0_text = z_slow + "; NO_0007;for unklar / Klärung / lebt";
        //    Xwrite("Step_9905", true, _info_0_text);

        //    boolCheckUnklar = true;
        //}

        //if (z_slow < x && z_lastPeListIndex_DONE > 0)  // to avoid crashes
        //{
        //    //z_lastPeListIndex_DONE = z_lastPeListIndex;

        //    string valueCheck = _pe_list[z_lastPeListIndex_DONE].I_NAME_NSFX;
        //    if (valueCheck.Contains("unklar") || valueCheck.Contains("Klärung") || valueCheck.Contains("lebt?"))
        //    {
        //        if (DontCheck_NSFX(_pe_list[z_lastPeListIndex].AA_I_INDI) == false)
        //        {
        //            errortext = z_blank //+ "____________________"
        //            + z_blank + _pe_list[z_lastPeListIndex_DONE].I_NAME_NSFX
        //            + " verh. " + _pe_list[z_lastPeListIndex_DONE].I_NAME_MARNM
        //            + z_blank + _pe_list[z_lastPeListIndex_DONE].I_NAME_SURN
        //            + z_blank + _pe_list[z_lastPeListIndex_DONE].I_NAME_GIVN
        //            + " born: " + _pe_list[z_lastPeListIndex_DONE].I_BIRT_DATE
        //            + " born_at: " + _pe_list[z_lastPeListIndex_DONE].I_BIRT_PLAC
        //            + " marr: " + _pe_list[z_lastPeListIndex_DONE].I_MARR_DATE
        //            + " died: " + _pe_list[z_lastPeListIndex_DONE].I_DEAT_DATE
        //            + " " + _pe_list[z_lastPeListIndex_DONE].AA_I_INDI
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


        //if (_pe_list_index >= 0 && _pe_list[_pe_list_index].I_FAMS != "")
        //    SplitColl(_pe_list[_pe_list_index].I_FAMS, ';');




        _update_string = "";  // here !!




        //end while (streamReader



        // writing gedheadText
        _info_0_text = z_newline + z_newline + gedheadText + z_newline;
        Xwrite("Step_2204", true, _count + _info_0_text);
        //Console.WriteLine(z_newline + z_newline + gedheadText + z_newline);
        //z_info_new = new("INFO;", ";", _info_0_text);
        //z_info_list.Add(z_info_new);

        _comment_inside_code = "if (_pe_list.Count > 0)";
        if (_pe_list.Count > 0)
        {
            _info_0_text = "PERS-Count   ; " + _pe_list.Count;
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
                _info_0_text += ";Step_2202:;Count for ;TOTAL      ;" + _pe_list.Count(a => a.I_SEX != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_DATE;" + _pe_list.Count(a => a.I_BIRT_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_PLAC;" + _pe_list.Count(a => a.I_BIRT_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_DATE;" + _pe_list.Count(a => a.I_DEAT_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_PLAC;" + _pe_list.Count(a => a.I_DEAT_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BURI_PLAC;" + _pe_list.Count(a => a.I_BURI_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_FAMS     ;" + _pe_list.Count(a => a.I_FAMS != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_HUSB     ;" + _fam_list.Count(a => a.F_HUSB != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_WIFE     ;" + _fam_list.Count(a => a.F_WIFE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_DATE;" + _fam_list.Count(a => a.F_MARR_DATE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_PLAC;" + _fam_list.Count(a => a.F_MARR_PLAC != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;F_MARR_NOTE;" + _fam_list.Count(a => a.F_MARR_NOTE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_BIRT_NOTE;" + _pe_list.Count(a => a.I_BIRT_NOTE != isEmptyString) + z_newline;
                _info_0_text += ";Step_2202:;Count for ;I_DEAT_NOTE;" + _pe_list.Count(a => a.I_DEAT_NOTE != isEmptyString) + z_newline;


                _info_0_text = _count + " > no counting";
                Xwrite("Step_2202", true, _info_0_text + z_newline);
                //Console.WriteLine(z_newline + z_newline + _info_0_text + z_newline);
                //z_info_new = new("INFO;", ";", _info_0_text);
                //z_info_list.Add(z_info_new);


            }
        }


        //streamReader.Close();
        // end of reading


        _info_0_text = "begin of Populate _source_line_list" + z_newline;
        Xwrite("Step_1102", true, _info_0_text);



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
        _source_line_text = "";


        _count = 0;
        z_nextGoalOfLines = 2000;
        string _album_line_text;
        _comment_inside_code = "for (int i = 0; i < _pe_list.Count; i++)";

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
        _album_line_text = "";


        _count = 0;
        z_nextGoalOfLines = 2000;

        _comment_inside_code = "for (int i = 0; i < _pe_list.Count; i++)";
        string _fam_line_text;
        for (int i = 0; i < _fam_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate _fam_line_list ";
                Xwrite("Step_2602", true, _info_0_text);
                z_nextGoalOfLines += 1000;
            }

            _fam_line_text = "F- " + _fam_list[i].AA_F_INDEX
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
        _fam_line_text = "";

        _count = 0;
        z_nextGoalOfLines = 2000;

        for (int i = 0; i < _pe_list.Count; i++)
        {
            _count++;
            if (_count > z_nextGoalOfLines)
            {
                _info_0_text = "Populate _pers_line_list ";
                Xwrite("Step_2602", true, _info_0_text);
                z_nextGoalOfLines += 1000;
            }


            _pers_line_hint = "";

            if (_pe_list[i].I_DEAT == "DEAT Y")
                _deatText = "DEAT Y";
            else
                _deatText = "DEAT N";

            //I_FAMS
            if (_pe_list[i].I_FAMS == "")
                _famsText = " Fxxxxxx-";
            else
                _famsText = _pe_list[i].I_FAMS;

            string z_birt_date = "," + _pe_list[i].I_BIRT_DATE;
            if (z_birt_date.Length == 10)
            {
                z_birt_date = ",0" + _pe_list[i].I_BIRT_DATE;
            }

            string z_deat_date = "," + _pe_list[i].I_DEAT_DATE;
            if (z_deat_date.Length == 10)
            {
                z_deat_date = ",0" + _pe_list[i].I_DEAT_DATE;
            }


            _pers_line_text = "I-" + _pe_list[i].AA_I_INDEX
            + z_tab + _pe_list[i].I_NAME_SURN
            + z_tab + _pe_list[i].I_NAME_GIVN
            + z_tab + _pe_list[i].I_NAME_MARNM
            + z_tab + z_birt_date
            + z_tab + _pe_list[i].I_BIRT_PLAC
            + z_tab + z_deat_date
            + z_tab + _pe_list[i].I_DEAT_PLAC
            + z_tab + _deatText
            + z_tab + _pe_list[i].I_BURI_PLAC
            + z_tab + "," + _pe_list[i].I_NAME_NSFX
            + z_tab + _pe_list[i].I_DEAT_CAUS
            + z_tab + _pe_list[i].I_FAMC
            + z_tab + _famsText
            ;

            Info _info_new = new(_pe_list[i].AA_I_INDEX, _pers_line_text, _pers_line_hint);
            _pers_line_list.Add(_info_new);

            _dateString = ";;;;;";

            //1 _UPD 15 DEC 2019
            //string _update_string = "1 _UPD 31 DEC 9999";
            _comment_inside_code = "string _update_string = \"1 _UPD 31 DEC 9999\";" + _update_string;

            //if (_pe_list[i].I_UPD.Length > 12)
            //{
            //    _update_string = GetUpdateString("x _UPD " + _pe_list[i].I_UPD);  // length must be more than 11
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
            //if (_pe_list[i].I_BIRT_DATE == " ")
            //{
            //    string index = _pe_list[i].AA_I_INDEX.Replace("I",""); 
            //    _info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
            //        + index;
            //    Console.WriteLine(_info_0_text);
            //    AddError("1231232", "INFO", _info_0_text);
            //}

            //CheckBox for empty birth date
            if (_pe_list[i].I_DEAT == "DEAT Y")

                //string index = _pe_list[i].AA_I_INDEX.Replace("I", "");
                //_info_0_text = "    z_slow is ;" + z_slow + "; NO_0013;CheckBirthDat: no BirthDate yet for https://www.myheritage.de/site-family-tree-104441723/85244?rootIndivudalID=1"
                //    + index;
                //Console.WriteLine(_info_0_text);
                //AddError("1231232", "INFO", _info_0_text);
                //if (_valueAdd == "DEAT Y")
                _pe_list[i].I_SEX += "d";
            else
                _pe_list[i].I_SEX += "a";


            if (_pe_list[i].I_BIRT != " ")
            {
                //_date = "," + _pe_list[i].I_BIRT_DATE;
                //_dateString = ";;;;;";
                if (_pe_list[i].I_BIRT_DATE != " ")
                    _dateString = GetDateString(_pe_list[i].I_BIRT_DATE);
                _place = _pe_list[i].I_BIRT_PLAC;
                _dio = "";
                _cb = _pe_list[i].I_BIRT_NOTE;
                _dateColl = _dateString.Split(';');
                _date_val = _dateColl[0];
                if (_dateColl[3] != "not 4,8,10,11") _day = _dateColl[3]; else _day = "";
                _month = _dateColl[4];
                _year = _dateColl[5];

                //_kind = "1-BIRTH";
                z_event_new = new(0, _day, _month, _year, _date_val
                    , "," + _pe_list[i].I_BIRT_DATE, "1-BIRTH", _dio, _cb, _place
                    , _pe_list[i].AA_I_INDEX, _pe_list[i].I_SEX, _pers_line_text);
                z_eventList.Add(z_event_new);

                if (_pe_list[i].I_DEAT != "")
                {
                    _date = "," + _pe_list[i].I_DEAT_DATE;
                    _dateString = GetDateString(_pe_list[i].I_DEAT_DATE);

                    _deathdateString = _dateString;
                    _place = _pe_list[i].I_DEAT_PLAC;
                    _cb = _pe_list[i].I_DEAT_NOTE;
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



                    //_kind = "4-DEATH";
                    z_event_new = new(0, _day, _month, _year, _date_val, _date, "4-DEATH", _dio, _cb, _place
                        , _pe_list[i].AA_I_INDEX, _pe_list[i].I_SEX, _pers_line_text);
                    z_eventList.Add(z_event_new);
                }

                _comment_inside_code = "no event buri";
                //if (_pe_list[i].I_BURI != "")
                //{
                //    //_date = "," + _pe_list[i].I_BURI_DATE;
                //    _dateString = GetDateString(_pe_list[i].I_BURI_DATE);
                //    if (_dateString == " ")
                //    {
                //        _dateString = _deathdateString;
                //        _deathdateString = "";
                //    }

                //    _place = _pe_list[i].I_BURI_PLAC;
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
                //        , _date = "," + _pe_list[i].I_BURI_DATE, _kind, _dio, _cb, _place
                //        , _pe_list[i].AA_I_INDEX, _pe_list[i].I_SEX, _pers_line_text)
                //        ;
                //    z_eventList.Add(z_event_new);
                //}
            }
            //z_ht = " # ";
        }

        //A11_Save_PersLine();

        A11_Save("_pers_line_list", _pers_line_list, z_out_file_PersLine);

        A11_Save("_fam_line_list", _fam_line_list, z_out_file_FamLine);

        //A11_Save("_album_line_list", z_album_line_list, z_out_file_AlbumLine);

        //A11_Save("_source_line_list", z_source_line_list, z_out_file_SourceLine);

        A11_Save("_note_line_list", z_note_line_list, z_out_file_NoteLine);


        _info_0_text = "_pers_line_list populated: "
                + _pers_line_list.Count;
        Xwrite("Step_2206", true, _info_0_text);
        //Console.WriteLine(_info_0_text);
        //    z_info_new = new("INFO;", ";", _info_0_text);
        //    z_info_list.Add(z_info_new);

        _info_0_text = "EventList populated    : "
            + z_eventList.Count;
        Xwrite("Step_2208", true, _info_0_text);


        SaveInfo(_path, "__ged_IN_info.txt");


        Do_99_PlaySound();

        _info_0_text = z_newline + "Step_1706 - Press ENTER to finish !";
        Console.WriteLine(_info_0_text);
        //Trace.WriteLine(_info_0_text);

        Console.ReadLine();

        _comment_inside_code = "end of > if (_pe_list.Count > 0)";

        _comment_inside_code = "endofMain";
    }
}