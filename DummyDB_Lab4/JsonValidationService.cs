

namespace DummyDB_4;

public static class JsonValidationService
{
    public static bool CheckBySchema(Schema schema, string[] data)
    {
        var areColumnsNamesOk = CheckColumnsNames(schema, data[0].Split(';'));
        for (var i = 1; i < data.Length; i++)
        {
            var flag = CheckColumnsTypes(schema, data[i].Split(';'));
            if (!flag)
            {
                return false;
            }
        }

        return areColumnsNamesOk;
    }

    private static bool CheckColumnsNames(Schema schema, string[] names)
    {
        bool hasMismatchedColumnNames = false;

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] != schema.Columns[i].Name)
            {
                hasMismatchedColumnNames = true;
                break;
            }
        }

        if (hasMismatchedColumnNames)
        {
            throw new FormatException("Названия столбцов в таблице не совпадают со схемой.");
        }

        return true;
    }

    private static bool CheckColumnsTypes(Schema schema, string[] row)
    {
        var result = false;
        for (var i = 0; i < row.Length; i++)
        {
            switch (schema.Columns[i].Type)
            {
                case "int":
                    result = int.TryParse(row[i], out _);
                    break;
                case "bool":
                    result = bool.TryParse(row[i], out _);
                    break;
                case "float":
                    result = float.TryParse(row[i], out _);
                    break;
                case "dateTime":
                    result = DateTime.TryParse(row[i], out _);
                    break;
                case "string":
                    result = true;
                    break;
                default:
                    throw new ArgumentException($"В схеме неверно указан тип данных столбца под номером {i + 1}.");
            }
        }

        return result;
    }
}