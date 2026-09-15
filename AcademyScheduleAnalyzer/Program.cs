using System;
using System.Text;

string[] sessionNames =
{
    "C# Basics",
    "Arrays",
    "Functions",
    "Date and Time",
    "Exception Handling"
};

DateTime[] sessionDates =
{
    new DateTime(2026, 9, 10, 18, 0, 0),
    new DateTime(2026, 9, 13, 18, 0, 0),
    new DateTime(2026, 9, 17, 18, 0, 0),
    new DateTime(2026, 9, 20, 18, 0, 0),
    new DateTime(2026, 9, 24, 18, 0, 0)
};

int[] sessionDurations =
{
    180,
    240,
    180,
    240,
    180
};

// ==================== PART 2 ====================

void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
{
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {names[i]}");
        Console.WriteLine($"Date: {dates[i]:dd MMMM yyyy}");
        Console.WriteLine($"Start Time: {dates[i]:hh:mm tt}");
        Console.WriteLine($"Duration: {durations[i]} minutes");
        Console.WriteLine();
    }
}

// ==================== PART 3 ====================

void SearchSession(string[] names, DateTime[] dates, int[] durations)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine()!;

    int index = Array.IndexOf(names, searchName);

    if (index != -1)
    {
        Console.WriteLine($"Session: {names[index]}");
        Console.WriteLine($"Date: {dates[index]:dd MMMM yyyy}");
        Console.WriteLine($"Start Time: {dates[index]:hh:mm tt}");
        Console.WriteLine($"Duration: {durations[index]} minutes");
    }
    else
    {
        Console.WriteLine("Session not found.");
    }
}

// ==================== PART 4 ====================

void ArrayOperations(string[] names)
{
    string[] sortedSessions = new string[names.Length];
    Array.Copy(names, sortedSessions, names.Length);
    Array.Sort(sortedSessions);

    Console.WriteLine("\n--- Sorted Sessions ---");

    foreach (string session in sortedSessions)
    {
        Console.WriteLine(session);
    }

    string[] reversedSessions = new string[names.Length];
    Array.Copy(names, reversedSessions, names.Length);
    Array.Reverse(reversedSessions);

    Console.WriteLine("\n--- Reversed Sessions ---");

    foreach (string session in reversedSessions)
    {
        Console.WriteLine(session);
    }

    Console.Write("\nEnter session name to find index: ");
    string searchName = Console.ReadLine()!;

    int index = Array.IndexOf(names, searchName);
    Console.WriteLine($"Index: {index}");

    bool exists = Array.Exists(names, name => name == searchName);
    Console.WriteLine($"Exists: {exists}");

    string found = Array.Find(names, name => name == searchName);

    if (found != null)
        Console.WriteLine($"Array.Find: {found}");
    else
        Console.WriteLine("Array.Find: Session not found.");

    int foundIndex = Array.FindIndex(names, name => name == searchName);

    Console.WriteLine($"Array.FindIndex: {foundIndex}");

    string[] copiedNames = new string[names.Length];
    Array.Copy(names, copiedNames, names.Length);

    copiedNames[0] = "Updated C# Basics";

    Console.WriteLine("\nOriginal array:");

    foreach (string name in names)
    {
        Console.WriteLine(name);
    }

    Console.WriteLine("\nCopied array:");

    foreach (string name in copiedNames)
    {
        Console.WriteLine(name);
    }
}

// ==================== PART 5 ====================

int GetTotalDuration(int[] durations)
{
    int total = 0;

    foreach (int duration in durations)
    {
        total += duration;
    }

    return total;
}

double GetAverageDuration(int[] durations)
{
    return (double)GetTotalDuration(durations) / durations.Length;
}

int GetShortestDuration(int[] durations)
{
    int shortest = durations[0];

    foreach (int duration in durations)
    {
        if (duration < shortest)
        {
            shortest = duration;
        }
    }

    return shortest;
}

int GetLongestDuration(int[] durations)
{
    int longest = durations[0];

    foreach (int duration in durations)
    {
        if (duration > longest)
        {
            longest = duration;
        }
    }

    return longest;
}

void DisplayDurationStatistics(int[] durations)
{
    Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
    Console.WriteLine($"Average Duration: {GetAverageDuration(durations):F2} minutes");
    Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
    Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");

    int[] sortedDurations = new int[durations.Length];

    Array.Copy(durations, sortedDurations, durations.Length);
    Array.Sort(sortedDurations);

    Console.WriteLine("\nSorted Durations:");

    foreach (int duration in sortedDurations)
    {
        Console.WriteLine(duration);
    }
}

// ==================== PART 6 ====================

void DisplaySessionDetails(string name, DateTime date, int duration)
{
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Date: {date:dd MMMM yyyy}");
    Console.WriteLine($"Start Time: {date:hh:mm tt}");
    Console.WriteLine($"Duration: {duration} minutes");
}

DateTime GetSessionEndTime(DateTime startTime, int duration)
{
    return startTime.AddMinutes(duration);
}

DateTime ReadSessionDate()
{
    DateTime date;

    while (true)
    {
        Console.Write("Enter session date (yyyy-MM-dd HH:mm): ");

        if (DateTime.TryParseExact(
            Console.ReadLine(),
            "yyyy-MM-dd HH:mm",
            null,
            System.Globalization.DateTimeStyles.None,
            out date))
        {
            return date;
        }

        Console.WriteLine("Invalid date format.");
    }
}

string BuildReportUsingString(
    string[] names,
    DateTime[] dates,
    int[] durations)
{
    string report = "";

    for (int i = 0; i < names.Length; i++)
    {
        report += $"{names[i]} - {dates[i]:yyyy-MM-dd HH:mm} - {durations[i]} minutes\n";
    }

    return report;
}

string BuildReportUsingStringBuilder(
    string[] names,
    DateTime[] dates,
    int[] durations)
{
    StringBuilder report = new StringBuilder();

    for (int i = 0; i < names.Length; i++)
    {
        report.Append(names[i]);
        report.Append(" - ");
        report.Append(dates[i].ToString("yyyy-MM-dd HH:mm"));
        report.Append(" - ");
        report.Append(durations[i]);
        report.Append(" minutes\n");
    }

    return report.ToString();
}

// ==================== PART 7 ====================

void ChangeDuration(ref int duration)
{
    duration += 60;
}

bool TryGetSessionInfo(
    string[] names,
    int[] durations,
    string searchName,
    out string sessionName,
    out int index,
    out int duration)
{
    index = Array.IndexOf(names, searchName);

    if (index != -1)
    {
        sessionName = names[index];
        duration = durations[index];

        return true;
    }

    sessionName = "";
    duration = 0;

    return false;
}

void ChangeFirstSession(string[] names)
{
    names[0] = "Updated C# Basics";
}

// ==================== PART 8 ====================

int GetTotalUsingParams(params int[] durations)
{
    int total = 0;

    foreach (int duration in durations)
    {
        total += duration;
    }

    return total;
}

// ==================== PART 9 ====================

void DisplayDateDetails(
    string[] names,
    DateTime[] dates,
    int[] durations)
{
    for (int i = 0; i < names.Length; i++)
    {
        DateTime endTime = dates[i].AddMinutes(durations[i]);

        Console.WriteLine($"Session: {names[i]}");
        Console.WriteLine($"Full Date: {dates[i]}");
        Console.WriteLine($"Day: {dates[i].DayOfWeek}");
        Console.WriteLine($"Year: {dates[i].Year}");
        Console.WriteLine($"Month: {dates[i].Month}");
        Console.WriteLine($"Day Number: {dates[i].Day}");
        Console.WriteLine($"Start: {dates[i]:hh:mm tt}");
        Console.WriteLine($"Duration: {durations[i]} minutes");
        Console.WriteLine($"End: {endTime:hh:mm tt}");
        Console.WriteLine();
    }
}

// ==================== PART 10 ====================

void DisplayDateDifference(DateTime[] dates)
{
    TimeSpan difference = dates[1] - dates[0];

    Console.WriteLine($"Difference: {difference}");
    Console.WriteLine($"Days: {difference.Days}");
    Console.WriteLine($"Hours: {difference.Hours}");
}

// ==================== PART 11 ====================

void DisplayPastUpcoming(
    string[] names,
    DateTime[] dates)
{
    DateTime now = DateTime.Now;

    for (int i = 0; i < names.Length; i++)
    {
        if (dates[i] < now)
        {
            Console.WriteLine($"{names[i]} -> Past");
        }
        else
        {
            Console.WriteLine($"{names[i]} -> Upcoming");
        }
    }
}

// ==================== PART 12 ====================

void DisplayNearestUpcoming(
    string[] names,
    DateTime[] dates)
{
    DateTime now = DateTime.Now;

    int nearestIndex = -1;

    for (int i = 0; i < dates.Length; i++)
    {
        if (dates[i] > now)
        {
            if (nearestIndex == -1 ||
                dates[i] < dates[nearestIndex])
            {
                nearestIndex = i;
            }
        }
    }

    if (nearestIndex != -1)
    {
        TimeSpan remaining = dates[nearestIndex] - now;

        Console.WriteLine($"Nearest Session: {names[nearestIndex]}");
        Console.WriteLine($"Date: {dates[nearestIndex]:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Remaining Days: {remaining.Days}");
        Console.WriteLine($"Remaining Hours: {remaining.Hours}");
    }
    else
    {
        Console.WriteLine("No upcoming sessions.");
    }
}

// ==================== PART 13 ====================

void DisplayDateFormatting(DateTime date)
{
    Console.WriteLine(date.ToString("yyyy-MM-dd"));
    Console.WriteLine(date.ToString("dd/MM/yyyy"));
    Console.WriteLine(date.ToString("dd MMMM yyyy"));
    Console.WriteLine(date.ToString("dddd"));
    Console.WriteLine(date.ToString("dd MMMM yyyy"));
    Console.WriteLine(date.ToString("hh:mm tt"));
}

// ==================== PART 15 ====================

void ReadMenuNumber()
{
    while (true)
    {
        Console.Write("Enter a number: ");

        try
        {
            int number = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"You entered: {number}");
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.");
        }
    }
}

// ==================== PART 16 ====================

void TestInvalidArrayIndex(string[] names)
{
    try
    {
        Console.WriteLine(names[100]);
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Invalid array index.");
    }
}

// ==================== PART 17 + 18 ====================

void ValidateDuration(int duration)
{
    if (duration <= 0)
    {
        throw new ArgumentException("Duration must be greater than zero.");
    }

    Console.WriteLine("Valid duration.");
}

void TestDurationValidation()
{
    try
    {
        Console.Write("Enter duration: ");
        int duration = int.Parse(Console.ReadLine()!);

        ValidateDuration(duration);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid number.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Input operation finished.");
    }
}

// ==================== MENU ====================

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=================================");
    Console.WriteLine("   Academy Schedule Analyzer");
    Console.WriteLine("=================================");

    Console.WriteLine("1. Display All Sessions");
    Console.WriteLine("2. Search Session");
    Console.WriteLine("3. Array Operations");
    Console.WriteLine("4. Duration Statistics");
    Console.WriteLine("5. Session Date Details");
    Console.WriteLine("6. Date Difference");
    Console.WriteLine("7. Past / Upcoming Sessions");
    Console.WriteLine("8. Nearest Upcoming Session");
    Console.WriteLine("9. Date Formatting");
    Console.WriteLine("10. Read Session Date");
    Console.WriteLine("11. Ref / Out");
    Console.WriteLine("12. Params");
    Console.WriteLine("13. String Report");
    Console.WriteLine("14. StringBuilder Report");
    Console.WriteLine("15. Format Exception");
    Console.WriteLine("16. Duration Validation");
    Console.WriteLine("0. Exit");

    Console.Write("Choose an option: ");

    int choice;

    try
    {
        choice = int.Parse(Console.ReadLine()!);
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            DisplaySessions(
                sessionNames,
                sessionDates,
                sessionDurations);
            break;

        case 2:
            SearchSession(
                sessionNames,
                sessionDates,
                sessionDurations);
            break;

        case 3:
            ArrayOperations(sessionNames);
            break;

        case 4:
            DisplayDurationStatistics(sessionDurations);
            break;

        case 5:
            DisplayDateDetails(
                sessionNames,
                sessionDates,
                sessionDurations);
            break;

        case 6:
            DisplayDateDifference(sessionDates);
            break;

        case 7:
            DisplayPastUpcoming(
                sessionNames,
                sessionDates);
            break;

        case 8:
            DisplayNearestUpcoming(
                sessionNames,
                sessionDates);
            break;

        case 9:
            DisplayDateFormatting(sessionDates[0]);
            break;

        case 10:
            DateTime newDate = ReadSessionDate();
            Console.WriteLine(
                $"Valid date: {newDate:yyyy-MM-dd HH:mm}");
            break;

        case 11:
            int durationBefore = sessionDurations[0];

            Console.WriteLine(
                $"Before ref: {durationBefore}");

            ChangeDuration(ref durationBefore);

            Console.WriteLine(
                $"After ref: {durationBefore}");

            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine()!;

            if (TryGetSessionInfo(
                sessionNames,
                sessionDurations,
                searchName,
                out string sessionName,
                out int index,
                out int duration))
            {
                Console.WriteLine($"Name: {sessionName}");
                Console.WriteLine($"Index: {index}");
                Console.WriteLine($"Duration: {duration}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }

            break;

        case 12:
            Console.WriteLine(
                $"2 args: {GetTotalUsingParams(100, 200)}");

            Console.WriteLine(
                $"3 args: {GetTotalUsingParams(100, 200, 300)}");

            Console.WriteLine(
                $"5 args: {GetTotalUsingParams(100, 200, 300, 400, 500)}");

            break;

        case 13:
            Console.WriteLine(
                BuildReportUsingString(
                    sessionNames,
                    sessionDates,
                    sessionDurations));
            break;

        case 14:
            Console.WriteLine(
                BuildReportUsingStringBuilder(
                    sessionNames,
                    sessionDates,
                    sessionDurations));
            break;

        case 15:
            ReadMenuNumber();
            break;

        case 16:
            TestDurationValidation();
            break;

        case 0:
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}