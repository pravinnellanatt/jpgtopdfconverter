Imports Root.Reports
Public Class MainForm

    Private Sub cmdConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvert.Click
        Dim doc As New Report(New PdfFormatter())
        doc.formatter.pageLayout = PageLayout.SinglePage
        doc.formatter.sCreator = "JpgtoPDF"
        doc.formatter.sAuthor = "http://www.thetechhub.com"


        pbar.Maximum = Me.FileList.CheckedItems.Count


        Dim count As Integer
        For Each item As CustomListItem In Me.FileList.CheckedItems
            Dim pg As New Page(doc)

            'best resize option found with A4 document size
            Dim img As Image = ResizeImage(item.FileName, 190, 190, True)

            pg.AddCB_MM(img.Height + 10, New RepImageMM(item.FileName, img.Width, img.Height))

            img.Dispose()
            img = Nothing
            count += 1
            pbar.Value = count
            pbar.Refresh()
            Threading.Thread.Sleep(10)
        Next


        doc.Save("c:\test.pdf")
        System.Diagnostics.Process.Start("C:\test.pdf")
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
