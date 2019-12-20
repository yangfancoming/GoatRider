using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace chapter2_5_1.excel {

    public class Demo1 {

        // 读取excel
        public static void test() {
            //获取文件路径
            string filePath = "D:\\123";
            //获取文件名
            string FileName ="222.xls";
            //创建文件对象
            FileStream fileStream = new FileStream(filePath+ @"\" + FileName, FileMode.Open, FileAccess.Read);
            //创建工作簿对象
            HSSFWorkbook workbook = new HSSFWorkbook(fileStream);
            //读取工作簿第一张表(此处参数可为下标,也可为表名)
            ISheet sheet = workbook.GetSheetAt(0);
            //新建当前工作表行数据
            IRow row;
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {　　
                //row读入第i行数据
                row = sheet.GetRow(i);
                //获取每一列的数据,并转换为对应的数据类型.
                string  c1 =  row.GetCell(1).ToString();
                double  c2 =  System.Convert.ToDouble(row.GetCell(2).ToString());

            }
        }


        // 创建excel
        public static void test1() {
            HSSFWorkbook hssfworkbook =new HSSFWorkbook();
            HSSFSheet sheet = hssfworkbook.CreateSheet("newsheet") as  HSSFSheet;
            hssfworkbook.CreateSheet("Sheet1");
            hssfworkbook.CreateSheet("Sheet2");
            hssfworkbook.CreateSheet("Sheet3");
            FileStream file =new FileStream(@"D:\123\test123.xls", FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }


        public static void test3() {

            var newFile = @"newbook.core.xlsx";

            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write)) {

                IWorkbook workbook = new XSSFWorkbook();

                ISheet sheet1 = workbook.CreateSheet("Sheet1");

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                var rowIndex = 0;
                IRow row = sheet1.CreateRow(rowIndex);
                row.Height = 30 * 80;
                row.CreateCell(0).SetCellValue("this is content");
                sheet1.AutoSizeColumn(0);
                rowIndex++;

                var sheet2 = workbook.CreateSheet("Sheet2");
                var style1 = workbook.CreateCellStyle();
                style1.FillForegroundColor = HSSFColor.Blue.Index2;
                style1.FillPattern = FillPattern.SolidForeground;

                var style2 = workbook.CreateCellStyle();
                style2.FillForegroundColor = HSSFColor.Yellow.Index2;
                style2.FillPattern = FillPattern.SolidForeground;

                var cell2 = sheet2.CreateRow(0).CreateCell(0);
                cell2.CellStyle = style1;
                cell2.SetCellValue(0);

                cell2 = sheet2.CreateRow(1).CreateCell(0);
                cell2.CellStyle = style2;
                cell2.SetCellValue(1);

                workbook.Write(fs);
            }
        }


    }
}