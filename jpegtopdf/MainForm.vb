Imports Root.Reports
Imports System.Threading

Public Class MainForm

    Private Sub cmdConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvert.Click
        Me.lblProgress.Text = ""
        Me.pbar.Value = 0
        Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
        saveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        saveFileDialog.Filter = "PDF Files (*.PDF)|*.PDF"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim report As Report = New Report(New PdfFormatter())
            report.formatter.pageLayout = PageLayout.SinglePage
            report.formatter.sCreator = "JpgtoPDF"
            report.formatter.sAuthor = "http://www.thetechhub.com"
            Dim count As Integer = Me.FileList.CheckedItems.Count
            Me.pbar.Maximum = count
            Application.DoEvents()
            Try
                Dim enumerator As IEnumerator = Me.FileList.CheckedItems.GetEnumerator()
                While enumerator.MoveNext()
                    Dim expr_CD As Object = enumerator.Current
                    Dim customListItem2 As CustomListItem
                    Dim customListItem As CustomListItem = If((expr_CD IsNot Nothing), (CType(expr_CD, CustomListItem)), customListItem2)
                    Dim page As Page = New Page(report)
                    Dim image As Image = Me.ResizeImage(customListItem.FullPath, 190, 190, True)
                    page.AddCB_MM(CDec((image.Height + 10)), New RepImageMM(customListItem.FullPath, CDec(image.Width), CDec(image.Height)))
                    image.Dispose()
                    Dim num As Integer
                    num += 1
                    Me.pbar.Value = num
                    Me.pbar.Refresh()
                    Me.lblProgress.Text = String.Format("Processing {0} of {1}", num, count)
                    Application.DoEvents()
                End While

                Me.lblProgress.Text = "Writing to PDF file"
                Me.lblProgress.Refresh()
                Thread.Sleep(10)
                report.Save(saveFileDialog.FileName)
                Me.lblProgress.Text = "Completed ..."
                Thread.Sleep(10)
                If MessageBox.Show("Do you want to open the generated PDF file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes Then
                    Process.Start(saveFileDialog.FileName)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "JPG Files (*.jpg)|*.jpg"
        ofd.Multiselect = True
        If (ofd.ShowDialog() <> Windows.Forms.DialogResult.OK) Then Return

        For Each file As String In ofd.FileNames
            Dim index As Integer = Me.FileList.Items.Add(New CustomListItem(System.IO.Path.GetFileName(file), file))
            Me.FileList.SetItemChecked(index, True)
        Next
    End Sub

    Private Sub FileList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileList.SelectedIndexChanged
        If FileList.SelectedIndex > -1 Then
            Dim img As Image = Image.FromFile(DirectCast(FileList.SelectedItem, CustomListItem).FullPath)
            If Not img Is Nothing Then
                Me.picPreview.Image = img.GetThumbnailImage(60, 60, Nothing, New IntPtr())
                Me.lblheight.Text = String.Format("{0} x {1}", img.Height, img.Width)
            End If
            img.Dispose()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.FileList.Items.Count > 0 Then
            For i As Integer = 0 To Me.FileList.Items.Count - 1
                Me.FileList.SetItemChecked(i, Me.CheckBox1.Checked)
            Next
        End If
    End Sub
    Public Function ResizeImage(ByVal OriginalFile As String, ByVal NewWidth As Integer, ByVal MaxHeight As Integer, ByVal OnlyResizeIfWider As Boolean) As Image
        Dim FullsizeImage As System.Drawing.Image = System.Drawing.Image.FromFile(OriginalFile)

        ' Prevent using images internal thumbnail
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
        FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)

        If OnlyResizeIfWider Then
            If FullsizeImage.Width <= NewWidth Then
                NewWidth = FullsizeImage.Width
            End If
        End If

        Dim NewHeight As Integer = FullsizeImage.Height * NewWidth / FullsizeImage.Width
        If NewHeight > MaxHeight Then
            ' Resize with height instead
            NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height
            NewHeight = MaxHeight
        End If

        Dim NewImage As System.Drawing.Image = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, Nothing, IntPtr.Zero)

        ' Clear handle to original file so that we can overwrite it if necessary
        FullsizeImage.Dispose()

        ' Save resized picture
        Return NewImage
    End Function
End Class

Structure CustomListItem
    Dim FileName As String
    Dim FullPath As String
    Sub New(ByVal file As String, ByVal path As String)
        FileName = file
        FullPath = path
    End Sub
    Public Overrides Function ToString() As String
        Return FileName
    End Function
End Structure
