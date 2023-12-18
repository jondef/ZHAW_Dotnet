Imports System
Imports System.Xml
Imports System.IO
Imports System.Windows.Forms

Namespace DN12

    Public Class XmlConverter

        Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
            If rbCsvToXml.Checked Then
                ConvertCsvToXml()
            ElseIf rbXmlToCsv.Checked Then
                ConvertXmlToCsv()
            End If
        End Sub

        Private Sub ConvertCsvToXml()
            Using openFileDialog As New OpenFileDialog With {.Filter = "CSV Files (*.csv)|*.csv"}
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim csvFile As String = openFileDialog.FileName
                    Dim xmlFile As String = Path.ChangeExtension(csvFile, ".xml")

                    ConvertCsvFileToXml(csvFile, xmlFile)
                    MessageBox.Show("CSV to XML conversion completed!")
                End If
            End Using
        End Sub

        Private Sub ConvertCsvFileToXml(csvFile As String, xmlFile As String)
            Using writer As New XmlTextWriter(xmlFile, System.Text.Encoding.UTF8),
                  reader As New StreamReader(csvFile)

                writer.WriteStartDocument()
                writer.WriteStartElement("Root")

                Dim headers() As String = reader.ReadLine().Split(","c)

                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim values() As String = line.Split(","c)
                    writer.WriteStartElement("Record")
                    For i As Integer = 0 To headers.Length - 1
                        writer.WriteElementString(headers(i), values(i))
                    Next
                    writer.WriteEndElement()
                End While

                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
        End Sub

        Private Sub ConvertXmlToCsv()
            Using openFileDialog As New OpenFileDialog With {.Filter = "XML Files (*.xml)|*.xml"}
                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim xmlFile As String = openFileDialog.FileName
                    Dim csvFile As String = Path.ChangeExtension(xmlFile, ".csv")

                    ConvertXmlFileToCsv(xmlFile, csvFile)
                    MessageBox.Show("XML to CSV conversion completed!")
                End If
            End Using
        End Sub

        Private Sub ConvertXmlFileToCsv(xmlFile As String, csvFile As String)
            Using writer As New StreamWriter(csvFile),
                  reader As XmlReader = XmlReader.Create(xmlFile)

                While reader.Read()
                    If reader.IsStartElement() AndAlso reader.Name = "Record" Then
                        Dim record As New List(Of String)
                        While reader.ReadToFollowing("Field")
                            record.Add(reader.ReadElementContentAsString())
                        End While
                        writer.WriteLine(String.Join(",", record))
                    End If
                End While
            End Using
        End Sub
    End Class

End Namespace
