Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class TopForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Person.mdb"
    Public DB_Person As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Person.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Person.ini"

    'staffフォルダパス
    Public staffDirPath As String = Util.getIniString("System", "SvrStaff", iniFilePath)

    '職種
    Private sectArray() As String = {"", "看護師", "准看護師", "助手", "介護福祉士", "臨床検査技師", "放射線技師", "事務職", "医師", "薬剤師", "栄養士", "管理栄養士", "警備", "営繕"}

    '詳細入力画面フォーム
    Private maintenanceForm As メンテナンス画面

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.KeyPreview = True
    End Sub

    ''' <summary>
    ''' keyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.KeyCode = Keys.F12 Then
            '(Alt + F11)キー押下
            If IsNothing(maintenanceForm) OrElse maintenanceForm.IsDisposed Then
                '詳細入力フォーム表示
                maintenanceForm = New メンテナンス画面()
                maintenanceForm.Show()
            End If
        End If
    End Sub

    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        'staffフォルダ存在チェック
        If Not System.IO.Directory.Exists(staffDirPath) Then
            MsgBox(staffDirPath & "が存在しません。iniファイルにstaffフォルダの正しいパスを設定して下さい。")
            Me.Close()
            Exit Sub
        End If

        '職種リストボックス初期設定
        initSectListBox()

        'ラジオボタン初期設定
        rbtnZai.Checked = True

        '印刷ラジオボタンの初期設定
        initPrintState()
    End Sub

    ''' <summary>
    ''' 職種リストボックス初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initSectListBox()
        sectListBox.Items.AddRange(sectArray)
    End Sub

    ''' <summary>
    ''' クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearData()
        '画像クリア
        imageBox.Image = Nothing
        '画面右ラベルテキストクリア
        namLabel.Text = ""
        kanaLabel.Text = ""
        birthLabel.Text = ""
        ageLabel.Text = ""
        sectLabel.Text = ""
        ymd1Label.Text = ""
        zaiLabel.Text = ""
        ymd2Label.Text = ""
        taiLabel.Text = ""
        textLabel.Text = ""
        tel1Label.Text = ""
        tel2Label.Text = ""
        jyu1Label.Text = ""
        jyu2Label.Text = ""
        nNoLabel.Text = ""
        nYmd1Label.Text = ""
        nYmd2Label.Text = ""
        kNoLabel.Text = ""
        kYmd1Label.Text = ""
        kYmd2Label.Text = ""
        mNoLabel.Text = ""
        mYmdLabel.Text = ""
        mSyaLabel.Text = ""
        dspLabel.Text = ""
    End Sub

    ''' <summary>
    ''' 氏名リスト表示
    ''' </summary>
    ''' <param name="exists">在職 or 退職</param>
    ''' <param name="sect">職種</param>
    ''' <remarks></remarks>
    Private Sub displayNamList(exists As Boolean, sect As String)
        '内容クリア
        namListBox.Items.Clear()
        clearData()

        'データ取得
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Person)
        Dim sql As String
        If sect = "" Then
            If exists Then
                sql = "select Nam from Staff where Ymd2 = NULL or Ymd2 = '' order by Kana"
            Else
                sql = "select Nam from Staff where Ymd2 <> NULL and Ymd2 <> '' order by Kana"
            End If
        Else
            If exists Then
                sql = "select Nam from Staff where Sect = '" & sect & "' and (Ymd2 = NULL or Ymd2 = '') order by Kana"
            Else
                sql = "select Nam from Staff where Sect = '" & sect & "' and (Ymd2 <> NULL and Ymd2 <> '') order by Kana"
            End If
        End If
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            namListBox.Items.Add(Util.checkDBNullValue(rs.Fields("Nam").Value))
            rs.MoveNext()
        End While
        cn.Close()
    End Sub

    ''' <summary>
    ''' 個人情報表示
    ''' </summary>
    ''' <param name="selectedNam">氏名</param>
    ''' <remarks></remarks>
    Private Sub displayPersonalData(selectedNam As String)
        'クリア
        clearData()

        'データ取得、表示
        Dim cn As New ADODB.Connection()
        cn.Open(DB_Person)
        Dim sql As String = "select * from Staff where Nam = '" & selectedNam & "'"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            '氏名
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            namLabel.Text = nam
            '画像
            Dim dsp As String = Util.checkDBNullValue(rs.Fields("Dsp").Value)
            dspLabel.Text = dsp
            Dim imageFilePath As String = staffDirPath & "\" & nam & ".JPG" '画像ファイルパス
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
                    g.DrawImage(image, 0, 0, 310, 245)
                ElseIf dsp = "2" Then
                    g.DrawImage(image, 0, 0, 240, 315)
                End If

                'BitmapとGraphicsオブジェクトを破棄
                image.Dispose()
                g.Dispose()

                imageBox.Image = canvas
            Else
                imageBox.Image = Nothing
            End If
            'ｶﾅ
            kanaLabel.Text = Util.checkDBNullValue(rs.Fields("Kana").Value)
            '生年月日
            Dim birthYmd As String = Util.checkDBNullValue(rs.Fields("Birth").Value)
            birthLabel.Text = Util.convADStrToWarekiStr(birthYmd)
            '年齢
            Dim nowYmd As String = DateTime.Now.ToString("yyyy/MM/dd")
            ageLabel.Text = Util.calcAge(birthYmd, nowYmd) & "歳"
            '職種
            sectLabel.Text = Util.checkDBNullValue(rs.Fields("Sect").Value)
            '入職日、退職日
            Dim ymd1 As String = Util.checkDBNullValue(rs.Fields("Ymd1").Value)
            Dim ymd2 As String = Util.checkDBNullValue(rs.Fields("Ymd2").Value)
            ymd1Label.Text = Util.convADStrToWarekiStr(ymd1)
            zaiLabel.Text = If(ymd2 = "", Util.calcAge(ymd1, nowYmd) & "年", "")
            ymd2Label.Text = Util.convADStrToWarekiStr(ymd2)
            taiLabel.Text = If(ymd2 = "", "", Util.calcAge(ymd1, ymd2) & "年")
            '備考
            textLabel.Text = Util.checkDBNullValue(rs.Fields("Text").Value)
            '電話1
            tel1Label.Text = Util.checkDBNullValue(rs.Fields("Tel1").Value)
            '電話2
            tel2Label.Text = Util.checkDBNullValue(rs.Fields("Tel2").Value)
            '住所1
            jyu1Label.Text = Util.checkDBNullValue(rs.Fields("Jyu1").Value)
            '住所2
            jyu2Label.Text = Util.checkDBNullValue(rs.Fields("Jyu2").Value)
            '年金No.
            nNoLabel.Text = Util.checkDBNullValue(rs.Fields("NNo").Value)
            '　取得日
            nYmd1Label.Text = Util.checkDBNullValue(rs.Fields("NYmd1").Value)
            '　喪失日
            nYmd2Label.Text = Util.checkDBNullValue(rs.Fields("NYmd2").Value)
            '雇用保険No.
            kNoLabel.Text = Util.checkDBNullValue(rs.Fields("KNo").Value)
            '　取得日
            kYmd1Label.Text = Util.checkDBNullValue(rs.Fields("KYmd1").Value)
            '　喪失日
            kYmd2Label.Text = Util.checkDBNullValue(rs.Fields("KYmd2").Value)
            '免許No.
            mNoLabel.Text = Util.checkDBNullValue(rs.Fields("MNo").Value)
            '　取得日
            mYmdLabel.Text = Util.checkDBNullValue(rs.Fields("MYmd").Value)
            '　発行者
            mSyaLabel.Text = Util.checkDBNullValue(rs.Fields("MSya").Value)
        End If
        rs.Close()
        cn.Close()
    End Sub

    ''' <summary>
    ''' 職種リストボックス値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub sectListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles sectListBox.SelectedValueChanged
        displayNamList(rbtnZai.Checked, sectListBox.Text)
    End Sub

    ''' <summary>
    ''' ラジオボタン値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtnZai_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnZai.CheckedChanged
        displayNamList(rbtnZai.Checked, sectListBox.Text)
    End Sub

    ''' <summary>
    ''' 氏名リスト値変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub namListBox_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles namListBox.SelectedValueChanged
        displayPersonalData(namListBox.Text)
    End Sub

    ''' <summary>
    ''' 下ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDown_Click(sender As System.Object, e As System.EventArgs) Handles btnDown.Click
        '行数
        Dim lastRowIndex As Integer = namListBox.Items.Count - 1

        '選択行
        Dim selectedRowIndex As Integer = namListBox.SelectedIndex

        '一つ下の行を選択
        If selectedRowIndex <> lastRowIndex Then
            namListBox.SelectedIndex = selectedRowIndex + 1
        End If
    End Sub

    ''' <summary>
    ''' 上ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        '行数
        Dim lastRowIndex As Integer = namListBox.Items.Count - 1

        '選択行
        Dim selectedRowIndex As Integer = namListBox.SelectedIndex

        '一つ上の行を選択
        If selectedRowIndex >= 1 Then
            namListBox.SelectedIndex = selectedRowIndex - 1
        End If
    End Sub

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'データ作成
        Dim dataArray(10, 3) As String
        dataArray(0, 0) = "氏名"
        dataArray(0, 1) = namLabel.Text
        dataArray(1, 0) = "ｶﾅ"
        dataArray(1, 1) = kanaLabel.Text
        dataArray(2, 0) = "生年月日"
        dataArray(2, 1) = birthLabel.Text & "　" & ageLabel.Text
        dataArray(3, 0) = "職種"
        dataArray(3, 1) = sectLabel.Text
        dataArray(4, 0) = "入職日"
        dataArray(4, 1) = ymd1Label.Text & "　" & zaiLabel.Text
        dataArray(5, 0) = "退職日"
        dataArray(5, 1) = ymd2Label.Text & "　" & taiLabel.Text
        dataArray(6, 0) = "備考"
        dataArray(6, 1) = textLabel.Text
        dataArray(7, 0) = "電話1"
        dataArray(7, 1) = tel1Label.Text
        dataArray(8, 0) = "電話2"
        dataArray(8, 1) = tel2Label.Text
        dataArray(9, 0) = "住所1"
        dataArray(9, 1) = jyu1Label.Text
        dataArray(10, 0) = "住所2"
        dataArray(10, 1) = jyu2Label.Text

        dataArray(0, 2) = "年金No."
        dataArray(0, 3) = nNoLabel.Text
        dataArray(1, 2) = "　　取得日"
        dataArray(1, 3) = nYmd1Label.Text
        dataArray(2, 2) = "　　喪失日"
        dataArray(2, 3) = nYmd2Label.Text
        dataArray(3, 2) = "雇用保険No."
        dataArray(3, 3) = kNoLabel.Text
        dataArray(4, 2) = "　　取得日"
        dataArray(4, 3) = kYmd1Label.Text
        dataArray(5, 2) = "　　喪失日"
        dataArray(5, 3) = kYmd2Label.Text
        dataArray(6, 2) = "免許No."
        dataArray(6, 3) = mNoLabel.Text
        dataArray(7, 2) = "　　取得日"
        dataArray(7, 3) = mYmdLabel.Text
        dataArray(8, 2) = "　　発行者"
        dataArray(8, 3) = mSyaLabel.Text

        '画像パス(画像が表示されている場合のみ取得)
        Dim imageFilePath As String = If(IsNothing(imageBox.Image), "", staffDirPath & "\" & namLabel.Text & ".JPG")

        'エクセル準備
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("個人票改")
        Dim xlShapes As Excel.Shapes = DirectCast(oSheet.Shapes, Excel.Shapes)
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        'データ貼り付け
        oSheet.Range("D3", "G13").Value = dataArray

        '画像ファイル
        If System.IO.File.Exists(imageFilePath) Then
            Dim cell As Excel.Range = DirectCast(oSheet.Cells(3, "B"), Excel.Range)
            If dspLabel.Text = "1" Then
                '横画像
                xlShapes.AddPicture(imageFilePath, False, True, cell.Left, cell.Top, 180, 140)
            Else
                '縦画像
                xlShapes.AddPicture(imageFilePath, False, True, cell.Left, cell.Top, 140, 180)
            End If
        End If

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If rbtnPrint.Checked = True Then
            oSheet.PrintOut()
        ElseIf rbtnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
        End If

        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub

    ''' <summary>
    ''' 印刷ラジオボタン初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", iniFilePath)
        End If
    End Sub

    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", iniFilePath)
        End If
    End Sub
End Class
