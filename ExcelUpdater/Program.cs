using OfficeOpenXml;
using System.ComponentModel;

ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

// Get input values from the user
Console.WriteLine("Enter value for Field 1:");
string field1 = Console.ReadLine();

Console.WriteLine("Enter value for Field 2:");
string field2 = Console.ReadLine();

Console.WriteLine("Enter value for Field 3:");
string field3 = Console.ReadLine();

//Console.WriteLine("Enter the path to the Excel file:");
//string excelFilePath = "D:\\Practice\\Practice\\Test\\Excel-POC.xlsx";

// Get the current directory of the application
string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

// Specify the file name (ensure the file is in the application folder)
string fileName = "Excel-POC.xlsx";

// Combine the directory and file name to get the full file path
string excelFilePath = Path.Combine(currentDirectory, fileName);

if (!File.Exists(excelFilePath))
{
    Console.WriteLine("The file does not exist.");
    return;
}

// Load and modify the Excel file
using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
{
    var worksheet = package.Workbook.Worksheets["Sheet1"]; // Get the first worksheet

    // Assign the input values to specific cells (e.g., A1, B1, C1)
    worksheet.Cells["B2"].Value = Convert.ToDouble(field1);
    worksheet.Cells["B3"].Value = Convert.ToDouble(field2);
    worksheet.Cells["B4"].Value = Convert.ToDouble(field3);

    //// Force recalculation of formulas
    //package.Workbook.Calculate();
    // Save the changes
    package.Save();
}

Console.WriteLine("Excel file updated successfully.");