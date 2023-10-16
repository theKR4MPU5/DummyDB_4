using DummyDB_4;

namespace DummyDB_4;

public static class CsvReadingService
{
    public static string[]? ReadFromCsv(string dataFilePath, string schemaFilePath)
    {
        var dataFromCsv = File.ReadAllLines(dataFilePath);
        var schema = Schema.GetFromJsonFile(schemaFilePath);

        try
        {
            if (JsonValidationService.CheckBySchema(schema!, dataFromCsv))
            {
                return dataFromCsv[1..];
            }
            else
            {
                throw new FormatException("Невозможно считать данные из файла, так как они не соответствуют схеме таблицы.");
            }
        }
        catch (Exception ex)
        {
            WriteExceptionMessage(ex);
        }

        return null;
    }

    private static void WriteExceptionMessage(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Console.WriteLine($"Ошибка: {ex.Message}");
        Console.ResetColor();
    }
}