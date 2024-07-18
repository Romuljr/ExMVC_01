using ExMVC_01.Repository.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace ExMVC_01.Presentation.Reports
{
    public class ClienteReports
    {
        public byte[] GenerateExcel(List<Cliente> clientes)
        {
            //definir o modo de licença do epplus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //criando o relatório excel..
            using (var excelPackage = new ExcelPackage())
            {
                //criando a planilha dentro do arquivo xlsx
                var sheet = excelPackage.Workbook.Worksheets.Add("Clientes");
                //adicionando titulo
                sheet.Cells["A1"].Value = "Relatório de Clientes";
                sheet.Cells["A2"].Value = $"Gerado em: {DateTime.Now.ToString
                ("dd/MM/yyyy HH:mm")}";
                #region Formatação do título do relatório
                var formatacaoTitulo = sheet.Cells["A1:H1"];
                formatacaoTitulo.Merge = true;
                formatacaoTitulo.Style.Font.Size = 16;
                formatacaoTitulo.Style.Font.Bold = true;
                formatacaoTitulo.Style.Font.Color.SetColor
               (ColorTranslator.FromHtml("#FFFFFF"));
                formatacaoTitulo.Style.Fill.PatternType = ExcelFillStyle.Solid;
                formatacaoTitulo.Style.Fill.BackgroundColor
               .SetColor(ColorTranslator.FromHtml("#363636"));
                formatacaoTitulo.Style.HorizontalAlignment =
               ExcelHorizontalAlignment.Center;
                #endregion
                //mesclar células
                sheet.Cells["A2:H2"].Merge = true;
                sheet.Cells["A2:H2"].Style.Font.Italic = true;
                //escrevendo os titulos das colunas:
                sheet.Cells["A4"].Value = "ID";
                sheet.Cells["B4"].Value = "Nome do Cliente";
                sheet.Cells["C4"].Value = "Email";
                sheet.Cells["D4"].Value = "CPF";
                sheet.Cells["E4"].Value = "Data de Nascimento";
                sheet.Cells["F4"].Value = "Sexo";
                sheet.Cells["G4"].Value = "Data de Cadastro";
                sheet.Cells["H4"].Value = "Data da Última Alteração";
                #region Formatação do título das colunas
                var formatacaoColunas = sheet.Cells["A4:H4"];
                formatacaoColunas.Style.Font.Size = 12;
                formatacaoColunas.Style.Font.Bold = true;
                formatacaoColunas.Style.Font.Color.SetColor
               (ColorTranslator.FromHtml("#FFFFFF"));
                formatacaoColunas.Style.Fill.PatternType = ExcelFillStyle.Solid;
                formatacaoColunas.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#363636"));
                #endregion
                var linha = 5; //contador de linhas
                               //percorrendo a lista de clientes
                foreach (var item in clientes)
                {
                    sheet.Cells[$"A{linha}"].Value = item.Id;
                    sheet.Cells[$"B{linha}"].Value = item.Nome;
                    sheet.Cells[$"C{linha}"].Value = item.Email;
                    sheet.Cells[$"D{linha}"].Value = item.Cpf;
                    sheet.Cells[$"E{linha}"].Value = item.DataNascimento
                   .ToString("dd/MM/yyyy");
                    sheet.Cells[$"F{linha}"].Value = item.Sexo;
                    sheet.Cells[$"G{linha}"].Value = item.DataCriacao
                   .ToString("dd/MM/yyyy HH:mm");
                    sheet.Cells[$"H{linha}"].Value = item.DataAlteracao
                   .ToString("dd/MM/yyyy HH:mm");
                    #region Formatação da linha de registro do relatório
                    var formatacaoLinha = sheet.Cells[$"A{linha}:H{linha}"];
                    if (linha % 2 == 0)
                    {
                        formatacaoLinha.Style
                       .Fill.PatternType = ExcelFillStyle.Solid;
                        formatacaoLinha.Style.Fill.BackgroundColor
                       .SetColor(ColorTranslator.FromHtml("#EEEEEE"));
                    }
                    else
                    {
                        formatacaoLinha.Style.Fill
                       .PatternType = ExcelFillStyle.Solid;
                        formatacaoLinha.Style.Fill.BackgroundColor
                       .SetColor(ColorTranslator.FromHtml("#D6D6D6"));
                    }
                    #endregion
                    linha++; //incrementando
                }
                #region Formatação em todo o corpo da planilha
                var formatacaoCorpo = sheet.Cells[$"A4:H{linha - 1}"];
                formatacaoCorpo.Style.Border
               .BorderAround(ExcelBorderStyle.Medium);
                #endregion
                //ajustando a largura das colunas ao seu conteudo
                sheet.Cells["A:H"].AutoFitColumns();
                //retornando o arquivo do relatório em formato de byte[]
                return excelPackage.GetAsByteArray();


            }

        }
    }

}
