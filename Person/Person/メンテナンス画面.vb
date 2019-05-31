Imports System.Data.OleDb

Public Class メンテナンス画面

    'テキストボックスのマウスダウンイベント制御用
    Private mdFlag As Boolean = False

    '職種
    Private sectArray() As String = {"医師", "薬剤師", "看護師", "准看護師", "介護福祉士", "放射線技師", "臨床検査技師", "栄養士", "管理栄養士", "助手", "事務職", "警備", "営繕"}

    ''' <summary>
    ''' 行ヘッダーのカレントセルを表す三角マークを非表示に設定する為のクラス。
    ''' </summary>
    ''' <remarks></remarks>
    Public Class dgvRowHeaderCell

        'DataGridViewRowHeaderCell を継承
        Inherits DataGridViewRowHeaderCell

        'DataGridViewHeaderCell.Paint をオーバーライドして行ヘッダーを描画
        Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, _
           ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal cellState As DataGridViewElementStates, _
           ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, _
           ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
           ByVal paintParts As DataGridViewPaintParts)
            '標準セルの描画からセル内容の背景だけ除いた物を描画(-5)
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, _
                     formattedValue, errorText, cellStyle, advancedBorderStyle, _
                     Not DataGridViewPaintParts.ContentBackground)
        End Sub

    End Class

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub メンテナンス画面_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        'ラジオボタン初期設定
        initPrintState()

        '職種リストボックス
        sectListBox.Items.AddRange(sectArray)

        'データグリッドビュー初期設定
        initDgvStaff()

        'データ表示
        displayDgvStaff()
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub メンテナンス画面_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Control = False Then
                Me.SelectNextControl(Me.ActiveControl, Not e.Shift, True, True, True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 職種ボックスフォーカスイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sectBox_GotFocus(sender As Object, e As System.EventArgs) Handles sectBox.GotFocus
        sectListBox.Visible = True
    End Sub

    ''' <summary>
    ''' 職種リストボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sectListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles sectListBox.SelectedValueChanged
        sectBox.Text = sectListBox.Text
        sectBox.Focus()
    End Sub

    ''' <summary>
    ''' データグリッドビュー初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initDgvStaff()
        Util.EnableDoubleBuffering(dgvStaff)

        With dgvStaff
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False '行削除禁止
            .BorderStyle = BorderStyle.FixedSingle
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            .DefaultCellStyle.ForeColor = Color.Black
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowHeadersWidth = 30
            .RowTemplate.Height = 16
            .RowTemplate.HeaderCell = New dgvRowHeaderCell() '行ヘッダの三角マークを非表示に
            .BackgroundColor = Color.FromKnownColor(KnownColor.Control)
            .ShowCellToolTips = False
            .EnableHeadersVisualStyles = False
            .Font = New Font("ＭＳ Ｐゴシック", 9)
            .ReadOnly = True
        End With
    End Sub

    ''' <summary>
    ''' 入力内容クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        'テキストボックス等
        namBox.Text = ""
        kanaBox.Text = ""
        dspBox.Text = ""
        birthBox.clearText()
        sectBox.Text = ""
        ymd1Box.clearText()
        ymd2Box.clearText()
        bikoBox.Text = ""
        tel1Box.Text = ""
        tel2Box.Text = ""
        jyu1Box.Text = ""
        jyu2Box.Text = ""
        nNoBox.Text = ""
        nYmd1Box.clearText()
        nYmd2Box.clearText()
        kNoBox.Text = ""
        kYmd1Box.clearText()
        kYmd2Box.clearText()
        mNoBox.Text = ""
        mYmdBox.clearText()
        mSyaBox.Text = ""
        '画像
        imageBox.Image = Nothing
    End Sub

    ''' <summary>
    ''' データ表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub displayDgvStaff()
        'クリア
        dgvStaff.Columns.Clear()
        clearInput()

        Dim cnn As New ADODB.Connection
        cnn.Open(TopForm.DB_Person)
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select Nam, Kana, Dsp, Birth, Int((Format(NOW(),'YYYYMMDD')-Format(Birth, 'YYYYMMDD'))/10000) as Age, Sect, Ymd1, Ymd2, Text, Tel1, Tel2, Jyu1, Jyu2, NNo, NYmd1, NYmd2, KNo, KYmd1, KYmd2, MNo, MYmd, MSya from Staff order by Kana"
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, rs, "Staff")
        Dim dt As DataTable = ds.Tables("Staff")

        '列追加
        dt.Columns.Add("Image", GetType(String)) 'イメージ
        dt.Columns.Add("Zai", GetType(String)) '在職期間
        For Each row As DataRow In dt.Rows
            Dim nyu As String = Util.checkDBNullValue(row("Ymd1"))
            Dim tai As String = Util.checkDBNullValue(row("Ymd2"))
            If tai = "" Then
                tai = DateTime.Now.ToString("yyyy/MM/dd")
            End If
            If nyu <> "" AndAlso tai <> "" Then
                Dim age As Integer = Util.calcAge(nyu, tai)
                row("Zai") = If(age <= 0, "", age)
            End If
        Next

        '表示
        dgvStaff.DataSource = dt
        cnn.Close()

        '幅設定等
        With dgvStaff
            With .Columns("Nam")
                .HeaderText = "氏名"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 85
                .Frozen = True
            End With
            With .Columns("Kana")
                .HeaderText = "ｶﾅ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 85
            End With
            With .Columns("Dsp")
                .HeaderText = "表示"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
            End With
            With .Columns("Image")
                .DisplayIndex = 3
                .HeaderText = "ｲﾒｰｼﾞ"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 40
                .HeaderCell.Style.Font = New Font("ＭＳ Ｐゴシック", 8)
            End With
            With .Columns("Birth")
                .HeaderText = "生年月日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Age")
                .HeaderText = "年齢"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
            End With
            With .Columns("Sect")
                .HeaderText = "職種"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 80
            End With
            With .Columns("Ymd1")
                .HeaderText = "入職日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Ymd2")
                .HeaderText = "退職日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("Zai")
                .DisplayIndex = 9
                .HeaderText = "在職"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 35
            End With
            With .Columns("Text")
                .HeaderText = "備考"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 95
            End With
            With .Columns("Tel1")
                .HeaderText = "電話1"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("Tel2")
                .HeaderText = "電話2"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("Jyu1")
                .HeaderText = "住所1"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 190
            End With
            With .Columns("Jyu2")
                .HeaderText = "住所2"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 190
            End With
            With .Columns("NNo")
                .HeaderText = "年金No."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("NYmd1")
                .HeaderText = "取得日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("NYmd2")
                .HeaderText = "喪失日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("KNo")
                .HeaderText = "雇用保険No."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("KYmd1")
                .HeaderText = "取得日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("KYmd2")
                .HeaderText = "喪失日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("MNo")
                .HeaderText = "免許No."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 90
            End With
            With .Columns("MYmd")
                .HeaderText = "取得日"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
            With .Columns("MSya")
                .HeaderText = "発行者"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .SortMode = DataGridViewColumnSortMode.NotSortable
                .Width = 75
            End With
        End With

        namBox.Focus()
    End Sub

    ''' <summary>
    ''' CellFormatting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStaff_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvStaff.CellFormatting
        Dim columnName As String = dgvStaff.Columns(e.ColumnIndex).Name
        If e.RowIndex >= 0 AndAlso (columnName = "Birth" OrElse columnName = "Ymd1" OrElse columnName = "Ymd2" OrElse columnName = "NYmd1" OrElse columnName = "NYmd2" OrElse columnName = "KYmd1" OrElse columnName = "KYmd2" OrElse columnName = "MYmd") Then
            e.Value = Util.convADStrToWarekiStr(e.Value)
            e.FormattingApplied = True
        End If
    End Sub

    ''' <summary>
    ''' セルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStaff_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStaff.CellMouseClick
        If e.RowIndex >= 0 Then
            clearInput()

            '値取得
            Dim nam As String = Util.checkDBNullValue(dgvStaff("Nam", e.RowIndex).Value)
            Dim kana As String = Util.checkDBNullValue(dgvStaff("Kana", e.RowIndex).Value)
            Dim dsp As String = Util.checkDBNullValue(dgvStaff("Dsp", e.RowIndex).Value)
            Dim birth As String = Util.checkDBNullValue(dgvStaff("Birth", e.RowIndex).Value)
            Dim sect As String = Util.checkDBNullValue(dgvStaff("Sect", e.RowIndex).Value)
            Dim ymd1 As String = Util.checkDBNullValue(dgvStaff("Ymd1", e.RowIndex).Value)
            Dim ymd2 As String = Util.checkDBNullValue(dgvStaff("Ymd2", e.RowIndex).Value)
            Dim text As String = Util.checkDBNullValue(dgvStaff("Text", e.RowIndex).Value)
            Dim tel1 As String = Util.checkDBNullValue(dgvStaff("Tel1", e.RowIndex).Value)
            Dim tel2 As String = Util.checkDBNullValue(dgvStaff("Tel2", e.RowIndex).Value)
            Dim jyu1 As String = Util.checkDBNullValue(dgvStaff("Jyu1", e.RowIndex).Value)
            Dim jyu2 As String = Util.checkDBNullValue(dgvStaff("Jyu2", e.RowIndex).Value)
            Dim nno As String = Util.checkDBNullValue(dgvStaff("NNo", e.RowIndex).Value)
            Dim nymd1 As String = Util.checkDBNullValue(dgvStaff("NYmd1", e.RowIndex).Value)
            Dim nymd2 As String = Util.checkDBNullValue(dgvStaff("NYmd2", e.RowIndex).Value)
            Dim kno As String = Util.checkDBNullValue(dgvStaff("KNo", e.RowIndex).Value)
            Dim kymd1 As String = Util.checkDBNullValue(dgvStaff("KYmd1", e.RowIndex).Value)
            Dim kymd2 As String = Util.checkDBNullValue(dgvStaff("KYmd2", e.RowIndex).Value)
            Dim mno As String = Util.checkDBNullValue(dgvStaff("MNo", e.RowIndex).Value)
            Dim mymd As String = Util.checkDBNullValue(dgvStaff("MYmd", e.RowIndex).Value)
            Dim msya As String = Util.checkDBNullValue(dgvStaff("MSya", e.RowIndex).Value)

            '各ボックスへセット
            namBox.Text = nam
            kanaBox.Text = kana
            dspBox.Text = dsp
            birthBox.setADStr(birth)
            sectBox.Text = sect
            ymd1Box.setADStr(ymd1)
            ymd2Box.setADStr(ymd2)
            bikoBox.Text = text
            tel1Box.Text = tel1
            tel2Box.Text = tel2
            jyu1Box.Text = jyu1
            jyu2Box.Text = jyu2
            nNoBox.Text = nno
            nYmd1Box.setADStr(nymd1)
            nYmd2Box.setADStr(nymd2)
            kNoBox.Text = kno
            kYmd1Box.setADStr(kymd1)
            kYmd2Box.setADStr(kymd2)
            mNoBox.Text = mno
            mYmdBox.setADStr(mymd)
            mSyaBox.Text = msya

            '画像
            Dim imageFilePath As String = TopForm.staffDirPath & "\" & nam & ".JPG" '画像ファイルパス
            If System.IO.File.Exists(imageFilePath) Then
                '描画先とするImageオブジェクトを作成する
                Dim canvas As New Bitmap(imageBox.Width, imageBox.Height)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Dim g As Graphics = Graphics.FromImage(canvas)

                'Bitmapオブジェクトの作成
                Dim image = New Bitmap(imageFilePath)
                '補間方法として高品質双三次補間を指定する
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                '画像を縮小して描画する
                If dsp = "1" Then
                    g.DrawImage(image, 0, 0, 190, 140)
                    'imageBox.Size = New Size(190, 140)
                ElseIf dsp = "2" Then
                    g.DrawImage(image, 0, 0, 140, 190)
                    'imageBox.Size = New Size(140, 190)
                End If

                'BitmapとGraphicsオブジェクトを破棄
                image.Dispose()
                g.Dispose()

                imageBox.SizeMode = PictureBoxSizeMode.AutoSize
                imageBox.Image = canvas
            Else
                imageBox.Image = Nothing
            End If

            'フォーカス
            namBox.Focus()
        End If
    End Sub

    ''' <summary>
    ''' CellPainting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStaff_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvStaff.CellPainting
        '行ヘッダーかどうか調べる
        If e.ColumnIndex < 0 AndAlso e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics, _
                (e.RowIndex + 1).ToString(), _
                e.CellStyle.Font, _
                indexRect, _
                e.CellStyle.ForeColor, _
                TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 列ヘッダーダブルクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStaff_ColumnHeaderMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvStaff.ColumnHeaderMouseDoubleClick
        Dim targetColumn As DataGridViewColumn = dgvStaff.Columns(e.ColumnIndex) '選択列
        dgvStaff.Sort(targetColumn, System.ComponentModel.ListSortDirection.Ascending) '昇順でソート
    End Sub

    ''' <summary>
    ''' 印刷ラジオボタン初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", TopForm.iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", TopForm.iniFilePath)
        End If
    End Sub

    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", TopForm.iniFilePath)
        End If
    End Sub

    Private Sub textBox_Enter(sender As Object, e As System.EventArgs) Handles namBox.Enter, kanaBox.Enter, kanaBox.Enter, sectBox.Enter, tel1Box.Enter, tel2Box.Enter, jyu1Box.Enter, jyu2Box.Enter, nNoBox.Enter, kNoBox.Enter, mNoBox.Enter, mSyaBox.Enter
        Dim tb As TextBox = CType(sender, TextBox)
        tb.SelectAll()
        mdFlag = True
    End Sub

    Private Sub textBox_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles namBox.MouseDown, kanaBox.MouseDown, kanaBox.MouseDown, sectBox.MouseDown, tel1Box.MouseDown, tel2Box.MouseDown, jyu1Box.MouseDown, jyu2Box.MouseDown, nNoBox.MouseDown, kNoBox.MouseDown, mNoBox.MouseDown, mSyaBox.MouseDown
        If mdFlag = True Then
            Dim tb As TextBox = CType(sender, TextBox)
            tb.SelectAll()
            mdFlag = False
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        '氏名
        Dim nam As String = namBox.Text
        If nam = "" Then
            MsgBox("氏名を入力して下さい。", MsgBoxStyle.Exclamation)
            namBox.Focus()
            Return
        End If
        'ｶﾅ
        Dim kana As String = kanaBox.Text
        If kana = "" Then
            MsgBox("ｶﾅを入力して下さい。", MsgBoxStyle.Exclamation)
            kanaBox.Focus()
            Return
        End If
        '表示
        Dim dsp As String = dspBox.Text
        If Not System.Text.RegularExpressions.Regex.IsMatch(dsp, "^[12]$") Then
            MsgBox("表示を正しく入力して下さい。", MsgBoxStyle.Exclamation)
            dspBox.Focus()
            Return
        End If
        '生年月日
        Dim birth As String = birthBox.getADStr()
        If birth = "" Then
            MsgBox("生年月日を入力して下さい。", MsgBoxStyle.Exclamation)
            birthBox.Focus()
            Return
        End If
        '職種
        Dim sect As String = sectBox.Text
        If sect = "" Then
            MsgBox("職種を入力して下さい。", MsgBoxStyle.Exclamation)
            sectBox.Focus()
            Return
        End If
        '入職日
        Dim ymd1 As String = ymd1Box.getADStr()
        If ymd1 = "" Then
            MsgBox("入職日を入力して下さい。", MsgBoxStyle.Exclamation)
            ymd1Box.Focus()
            Return
        End If
        '退職日
        Dim ymd2 As String = ymd2Box.getADStr()
        '備考
        Dim text As String = bikoBox.Text
        '電話1
        Dim tel1 As String = tel1Box.Text
        '電話2
        Dim tel2 As String = tel2Box.Text
        '住所1
        Dim jyu1 As String = jyu1Box.Text
        '住所2
        Dim jyu2 As String = jyu2Box.Text
        '年金No.
        Dim nno As String = nNoBox.Text
        '　取得日
        Dim nymd1 As String = nYmd1Box.getADStr()
        '　喪失日
        Dim nymd2 As String = nYmd2Box.getADStr()
        '雇用保険No.
        Dim kno As String = kNoBox.Text
        '　取得日
        Dim kymd1 As String = kYmd1Box.getADStr()
        '　喪失日
        Dim kymd2 As String = kYmd2Box.getADStr()
        '免許No.
        Dim mno As String = mNoBox.Text
        '　取得日
        Dim mymd As String = mYmdBox.getADStr()
        '　発行者
        Dim msya As String = mSyaBox.Text

        '登録
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Person)
        Dim sql As String = "select * from Staff where Nam = '" & nam & "' and Kana = '" & kana & "' and Birth = '" & birth & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            '新規登録
            rs.AddNew()        
        End If
        rs.Fields("Nam").Value = nam
        rs.Fields("Kana").Value = kana
        rs.Fields("Dsp").Value = dsp
        rs.Fields("Birth").Value = birth
        rs.Fields("Sect").Value = sect
        rs.Fields("Ymd1").Value = ymd1
        rs.Fields("Ymd2").Value = ymd2
        rs.Fields("Text").Value = text
        rs.Fields("Tel1").Value = tel1
        rs.Fields("Tel2").Value = tel2
        rs.Fields("Jyu1").Value = jyu1
        rs.Fields("Jyu2").Value = jyu2
        rs.Fields("NNo").Value = nno
        rs.Fields("NYmd1").Value = nymd1
        rs.Fields("NYmd2").Value = nymd2
        rs.Fields("KNo").Value = kno
        rs.Fields("KYmd1").Value = kymd1
        rs.Fields("KYmd2").Value = kymd2
        rs.Fields("MNo").Value = mno
        rs.Fields("MYmd").Value = mymd
        rs.Fields("MSya").Value = msya
        rs.Update()
        rs.Close()
        cn.Close()

        '再表示
        displayDgvStaff()

    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        '氏名
        Dim nam As String = namBox.Text

        '削除
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_Person)
        Dim sql As String = "select * from Staff where Nam = '" & nam & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount <= 0 Then
            MsgBox("登録されてません。", MsgBoxStyle.Exclamation)
            rs.Close()
            cn.Close()
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("削除してよろしいですか？", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                rs.Delete()
                rs.Update()
                rs.Close()
                cn.Close()

                '再表示
                displayDgvStaff()
            Else
                rs.Close()
                cn.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub
End Class