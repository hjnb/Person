<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class メンテナンス画面
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.namBox = New System.Windows.Forms.TextBox()
        Me.kanaBox = New System.Windows.Forms.TextBox()
        Me.dspBox = New System.Windows.Forms.TextBox()
        Me.birthBox = New ymdBox.ymdBox()
        Me.sectBox = New System.Windows.Forms.TextBox()
        Me.ymd1Box = New ymdBox.ymdBox()
        Me.ymd2Box = New ymdBox.ymdBox()
        Me.bikoBox = New System.Windows.Forms.TextBox()
        Me.tel1Box = New System.Windows.Forms.TextBox()
        Me.tel2Box = New System.Windows.Forms.TextBox()
        Me.jyu1Box = New System.Windows.Forms.TextBox()
        Me.jyu2Box = New System.Windows.Forms.TextBox()
        Me.nNoBox = New System.Windows.Forms.TextBox()
        Me.nYmd1Box = New ymdBox.ymdBox()
        Me.nYmd2Box = New ymdBox.ymdBox()
        Me.kNoBox = New System.Windows.Forms.TextBox()
        Me.kYmd1Box = New ymdBox.ymdBox()
        Me.kYmd2Box = New ymdBox.ymdBox()
        Me.mNoBox = New System.Windows.Forms.TextBox()
        Me.mYmdBox = New ymdBox.ymdBox()
        Me.mSyaBox = New System.Windows.Forms.TextBox()
        Me.sectListBox = New System.Windows.Forms.ListBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.rbtnPreview = New System.Windows.Forms.RadioButton()
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.dgvStaff = New System.Windows.Forms.DataGridView()
        Me.imageBox = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(19, 298)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 12)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "住所2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(19, 272)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "住所1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(19, 247)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 12)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "電話2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "電話1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(19, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "備考"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "退職日"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "入職日"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "職種"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "生年月日"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "ｶﾅ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "氏名"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "表示"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(341, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "発行者"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(341, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 12)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "取得日"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(326, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 12)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "免許No."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(341, 169)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "喪失日"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(341, 144)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 12)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "取得日"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(326, 117)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 12)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "雇用保険No."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(341, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 12)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "喪失日"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(341, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "取得日"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(326, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 12)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "年金No."
        '
        'namBox
        '
        Me.namBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.namBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.namBox.Location = New System.Drawing.Point(80, 13)
        Me.namBox.Name = "namBox"
        Me.namBox.Size = New System.Drawing.Size(124, 19)
        Me.namBox.TabIndex = 33
        '
        'kanaBox
        '
        Me.kanaBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanaBox.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.kanaBox.Location = New System.Drawing.Point(80, 38)
        Me.kanaBox.Name = "kanaBox"
        Me.kanaBox.Size = New System.Drawing.Size(124, 19)
        Me.kanaBox.TabIndex = 34
        '
        'dspBox
        '
        Me.dspBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dspBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dspBox.Location = New System.Drawing.Point(80, 63)
        Me.dspBox.MaxLength = 1
        Me.dspBox.Name = "dspBox"
        Me.dspBox.Size = New System.Drawing.Size(38, 19)
        Me.dspBox.TabIndex = 35
        Me.dspBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'birthBox
        '
        Me.birthBox.boxType = 0
        Me.birthBox.DateText = ""
        Me.birthBox.EraLabelText = "R01"
        Me.birthBox.EraText = ""
        Me.birthBox.Location = New System.Drawing.Point(79, 87)
        Me.birthBox.MonthLabelText = "05"
        Me.birthBox.MonthText = ""
        Me.birthBox.Name = "birthBox"
        Me.birthBox.Size = New System.Drawing.Size(86, 20)
        Me.birthBox.TabIndex = 36
        '
        'sectBox
        '
        Me.sectBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.sectBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.sectBox.Location = New System.Drawing.Point(80, 114)
        Me.sectBox.Name = "sectBox"
        Me.sectBox.Size = New System.Drawing.Size(124, 19)
        Me.sectBox.TabIndex = 37
        '
        'ymd1Box
        '
        Me.ymd1Box.boxType = 0
        Me.ymd1Box.DateText = ""
        Me.ymd1Box.EraLabelText = "R01"
        Me.ymd1Box.EraText = ""
        Me.ymd1Box.Location = New System.Drawing.Point(79, 138)
        Me.ymd1Box.MonthLabelText = "05"
        Me.ymd1Box.MonthText = ""
        Me.ymd1Box.Name = "ymd1Box"
        Me.ymd1Box.Size = New System.Drawing.Size(86, 20)
        Me.ymd1Box.TabIndex = 38
        '
        'ymd2Box
        '
        Me.ymd2Box.boxType = 0
        Me.ymd2Box.DateText = ""
        Me.ymd2Box.EraLabelText = "R01"
        Me.ymd2Box.EraText = ""
        Me.ymd2Box.Location = New System.Drawing.Point(79, 164)
        Me.ymd2Box.MonthLabelText = "05"
        Me.ymd2Box.MonthText = ""
        Me.ymd2Box.Name = "ymd2Box"
        Me.ymd2Box.Size = New System.Drawing.Size(86, 20)
        Me.ymd2Box.TabIndex = 39
        '
        'bikoBox
        '
        Me.bikoBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.bikoBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.bikoBox.Location = New System.Drawing.Point(80, 191)
        Me.bikoBox.Name = "bikoBox"
        Me.bikoBox.Size = New System.Drawing.Size(124, 19)
        Me.bikoBox.TabIndex = 40
        '
        'tel1Box
        '
        Me.tel1Box.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tel1Box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tel1Box.Location = New System.Drawing.Point(80, 217)
        Me.tel1Box.Name = "tel1Box"
        Me.tel1Box.Size = New System.Drawing.Size(124, 19)
        Me.tel1Box.TabIndex = 41
        '
        'tel2Box
        '
        Me.tel2Box.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tel2Box.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tel2Box.Location = New System.Drawing.Point(80, 243)
        Me.tel2Box.Name = "tel2Box"
        Me.tel2Box.Size = New System.Drawing.Size(124, 19)
        Me.tel2Box.TabIndex = 42
        '
        'jyu1Box
        '
        Me.jyu1Box.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.jyu1Box.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.jyu1Box.Location = New System.Drawing.Point(80, 268)
        Me.jyu1Box.Name = "jyu1Box"
        Me.jyu1Box.Size = New System.Drawing.Size(201, 19)
        Me.jyu1Box.TabIndex = 43
        '
        'jyu2Box
        '
        Me.jyu2Box.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.jyu2Box.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.jyu2Box.Location = New System.Drawing.Point(80, 293)
        Me.jyu2Box.Name = "jyu2Box"
        Me.jyu2Box.Size = New System.Drawing.Size(201, 19)
        Me.jyu2Box.TabIndex = 44
        '
        'nNoBox
        '
        Me.nNoBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nNoBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.nNoBox.Location = New System.Drawing.Point(405, 38)
        Me.nNoBox.Name = "nNoBox"
        Me.nNoBox.Size = New System.Drawing.Size(124, 19)
        Me.nNoBox.TabIndex = 45
        '
        'nYmd1Box
        '
        Me.nYmd1Box.boxType = 0
        Me.nYmd1Box.DateText = ""
        Me.nYmd1Box.EraLabelText = "R01"
        Me.nYmd1Box.EraText = ""
        Me.nYmd1Box.Location = New System.Drawing.Point(404, 62)
        Me.nYmd1Box.MonthLabelText = "05"
        Me.nYmd1Box.MonthText = ""
        Me.nYmd1Box.Name = "nYmd1Box"
        Me.nYmd1Box.Size = New System.Drawing.Size(86, 20)
        Me.nYmd1Box.TabIndex = 46
        '
        'nYmd2Box
        '
        Me.nYmd2Box.boxType = 0
        Me.nYmd2Box.DateText = ""
        Me.nYmd2Box.EraLabelText = "R01"
        Me.nYmd2Box.EraText = ""
        Me.nYmd2Box.Location = New System.Drawing.Point(404, 86)
        Me.nYmd2Box.MonthLabelText = "05"
        Me.nYmd2Box.MonthText = ""
        Me.nYmd2Box.Name = "nYmd2Box"
        Me.nYmd2Box.Size = New System.Drawing.Size(86, 20)
        Me.nYmd2Box.TabIndex = 47
        '
        'kNoBox
        '
        Me.kNoBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kNoBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.kNoBox.Location = New System.Drawing.Point(405, 113)
        Me.kNoBox.Name = "kNoBox"
        Me.kNoBox.Size = New System.Drawing.Size(124, 19)
        Me.kNoBox.TabIndex = 48
        '
        'kYmd1Box
        '
        Me.kYmd1Box.boxType = 0
        Me.kYmd1Box.DateText = ""
        Me.kYmd1Box.EraLabelText = "R01"
        Me.kYmd1Box.EraText = ""
        Me.kYmd1Box.Location = New System.Drawing.Point(404, 138)
        Me.kYmd1Box.MonthLabelText = "05"
        Me.kYmd1Box.MonthText = ""
        Me.kYmd1Box.Name = "kYmd1Box"
        Me.kYmd1Box.Size = New System.Drawing.Size(86, 20)
        Me.kYmd1Box.TabIndex = 49
        '
        'kYmd2Box
        '
        Me.kYmd2Box.boxType = 0
        Me.kYmd2Box.DateText = ""
        Me.kYmd2Box.EraLabelText = "R01"
        Me.kYmd2Box.EraText = ""
        Me.kYmd2Box.Location = New System.Drawing.Point(404, 164)
        Me.kYmd2Box.MonthLabelText = "05"
        Me.kYmd2Box.MonthText = ""
        Me.kYmd2Box.Name = "kYmd2Box"
        Me.kYmd2Box.Size = New System.Drawing.Size(86, 20)
        Me.kYmd2Box.TabIndex = 50
        '
        'mNoBox
        '
        Me.mNoBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mNoBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.mNoBox.Location = New System.Drawing.Point(405, 192)
        Me.mNoBox.Name = "mNoBox"
        Me.mNoBox.Size = New System.Drawing.Size(124, 19)
        Me.mNoBox.TabIndex = 51
        '
        'mYmdBox
        '
        Me.mYmdBox.boxType = 0
        Me.mYmdBox.DateText = ""
        Me.mYmdBox.EraLabelText = "R01"
        Me.mYmdBox.EraText = ""
        Me.mYmdBox.Location = New System.Drawing.Point(404, 217)
        Me.mYmdBox.MonthLabelText = "05"
        Me.mYmdBox.MonthText = ""
        Me.mYmdBox.Name = "mYmdBox"
        Me.mYmdBox.Size = New System.Drawing.Size(86, 20)
        Me.mYmdBox.TabIndex = 52
        '
        'mSyaBox
        '
        Me.mSyaBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.mSyaBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.mSyaBox.Location = New System.Drawing.Point(404, 244)
        Me.mSyaBox.Name = "mSyaBox"
        Me.mSyaBox.Size = New System.Drawing.Size(124, 19)
        Me.mSyaBox.TabIndex = 53
        '
        'sectListBox
        '
        Me.sectListBox.BackColor = System.Drawing.SystemColors.Control
        Me.sectListBox.FormattingEnabled = True
        Me.sectListBox.ItemHeight = 12
        Me.sectListBox.Location = New System.Drawing.Point(216, 13)
        Me.sectListBox.Name = "sectListBox"
        Me.sectListBox.Size = New System.Drawing.Size(93, 148)
        Me.sectListBox.TabIndex = 56
        Me.sectListBox.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(348, 315)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(168, 12)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "ダブルクリックした項目名で並べます"
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(590, 272)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(62, 28)
        Me.btnRegist.TabIndex = 54
        Me.btnRegist.Text = "登録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(651, 272)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(62, 28)
        Me.btnDelete.TabIndex = 57
        Me.btnDelete.Text = "削除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(744, 272)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(62, 28)
        Me.btnPrint.TabIndex = 58
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rbtnPreview
        '
        Me.rbtnPreview.AutoSize = True
        Me.rbtnPreview.Location = New System.Drawing.Point(816, 247)
        Me.rbtnPreview.Name = "rbtnPreview"
        Me.rbtnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbtnPreview.TabIndex = 59
        Me.rbtnPreview.TabStop = True
        Me.rbtnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbtnPreview.UseVisualStyleBackColor = True
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Location = New System.Drawing.Point(816, 272)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPrint.TabIndex = 60
        Me.rbtnPrint.TabStop = True
        Me.rbtnPrint.Text = "印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'dgvStaff
        '
        Me.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStaff.Location = New System.Drawing.Point(21, 331)
        Me.dgvStaff.Name = "dgvStaff"
        Me.dgvStaff.RowTemplate.Height = 21
        Me.dgvStaff.Size = New System.Drawing.Size(944, 362)
        Me.dgvStaff.TabIndex = 61
        '
        'imageBox
        '
        Me.imageBox.Location = New System.Drawing.Point(603, 40)
        Me.imageBox.Name = "imageBox"
        Me.imageBox.Size = New System.Drawing.Size(190, 140)
        Me.imageBox.TabIndex = 62
        Me.imageBox.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(122, 67)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 12)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "1：横　2：縦"
        '
        'メンテナンス画面
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 710)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.imageBox)
        Me.Controls.Add(Me.dgvStaff)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Controls.Add(Me.rbtnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.sectListBox)
        Me.Controls.Add(Me.mSyaBox)
        Me.Controls.Add(Me.mYmdBox)
        Me.Controls.Add(Me.mNoBox)
        Me.Controls.Add(Me.kYmd2Box)
        Me.Controls.Add(Me.kYmd1Box)
        Me.Controls.Add(Me.kNoBox)
        Me.Controls.Add(Me.nYmd2Box)
        Me.Controls.Add(Me.nYmd1Box)
        Me.Controls.Add(Me.nNoBox)
        Me.Controls.Add(Me.jyu2Box)
        Me.Controls.Add(Me.jyu1Box)
        Me.Controls.Add(Me.tel2Box)
        Me.Controls.Add(Me.tel1Box)
        Me.Controls.Add(Me.bikoBox)
        Me.Controls.Add(Me.ymd2Box)
        Me.Controls.Add(Me.ymd1Box)
        Me.Controls.Add(Me.sectBox)
        Me.Controls.Add(Me.birthBox)
        Me.Controls.Add(Me.dspBox)
        Me.Controls.Add(Me.kanaBox)
        Me.Controls.Add(Me.namBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "メンテナンス画面"
        Me.Text = "メンテナンス画面"
        CType(Me.dgvStaff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents namBox As System.Windows.Forms.TextBox
    Friend WithEvents kanaBox As System.Windows.Forms.TextBox
    Friend WithEvents dspBox As System.Windows.Forms.TextBox
    Friend WithEvents birthBox As ymdBox.ymdBox
    Friend WithEvents sectBox As System.Windows.Forms.TextBox
    Friend WithEvents ymd1Box As ymdBox.ymdBox
    Friend WithEvents ymd2Box As ymdBox.ymdBox
    Friend WithEvents bikoBox As System.Windows.Forms.TextBox
    Friend WithEvents tel1Box As System.Windows.Forms.TextBox
    Friend WithEvents tel2Box As System.Windows.Forms.TextBox
    Friend WithEvents jyu1Box As System.Windows.Forms.TextBox
    Friend WithEvents jyu2Box As System.Windows.Forms.TextBox
    Friend WithEvents nNoBox As System.Windows.Forms.TextBox
    Friend WithEvents nYmd1Box As ymdBox.ymdBox
    Friend WithEvents nYmd2Box As ymdBox.ymdBox
    Friend WithEvents kNoBox As System.Windows.Forms.TextBox
    Friend WithEvents kYmd1Box As ymdBox.ymdBox
    Friend WithEvents kYmd2Box As ymdBox.ymdBox
    Friend WithEvents mNoBox As System.Windows.Forms.TextBox
    Friend WithEvents mYmdBox As ymdBox.ymdBox
    Friend WithEvents mSyaBox As System.Windows.Forms.TextBox
    Friend WithEvents sectListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents rbtnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents dgvStaff As System.Windows.Forms.DataGridView
    Friend WithEvents imageBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
