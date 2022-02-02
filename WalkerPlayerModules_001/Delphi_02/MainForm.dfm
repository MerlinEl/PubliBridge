object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'WalkerPlayer.dll > CSharp Methods Call:'
  ClientHeight = 578
  ClientWidth = 770
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnClose = OnFormClose
  OnShow = OnFormShown
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox6: TGroupBox
    Left = 5
    Top = 311
    Width = 757
    Height = 263
    Caption = 'Console:'
    TabOrder = 0
    object TxtConsole: TMemo
      Left = 3
      Top = 21
      Width = 747
      Height = 239
      ReadOnly = True
      TabOrder = 0
    end
  end
  object grpOptions: TGroupBox
    Left = 8
    Top = 5
    Width = 757
    Height = 116
    Caption = 'Options:'
    TabOrder = 1
    object Label4: TLabel
      Left = 13
      Top = 25
      Width = 55
      Height = 13
      Caption = 'User name:'
    end
    object lbl9: TLabel
      Left = 13
      Top = 53
      Width = 60
      Height = 13
      Caption = 'DropBox dir:'
    end
    object ChkFitToScreen: TCheckBox
      Left = 626
      Top = 69
      Width = 121
      Height = 17
      Caption = 'Fit To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 0
    end
    object ChkEscapeEnabled: TCheckBox
      Left = 626
      Top = 23
      Width = 121
      Height = 17
      Caption = 'Escape Enabled'
      Checked = True
      State = cbChecked
      TabOrder = 1
    end
    object ChkAutoPlay: TCheckBox
      Left = 495
      Top = 23
      Width = 125
      Height = 17
      Caption = 'Auto Play'
      Checked = True
      State = cbChecked
      TabOrder = 2
    end
    object ChkSkipLogo: TCheckBox
      Left = 495
      Top = 46
      Width = 125
      Height = 17
      Caption = 'Skip Logo'
      TabOrder = 3
    end
    object ChkHiddenPlayer: TCheckBox
      Left = 495
      Top = 69
      Width = 125
      Height = 17
      Caption = 'Hidden Player'
      TabOrder = 4
    end
    object ChkHiddenConsole: TCheckBox
      Left = 495
      Top = 92
      Width = 125
      Height = 17
      Caption = 'Hidden Console'
      TabOrder = 5
    end
    object CbxUserName: TComboBox
      Left = 93
      Top = 21
      Width = 283
      Height = 21
      ItemIndex = 0
      TabOrder = 6
      Text = 'Orien Star'
      OnChange = OnUserDirectoryChanged
      Items.Strings = (
        'Orien Star'
        'merli')
    end
    object CbxBookDir: TComboBox
      Left = 93
      Top = 50
      Width = 364
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 7
      Text = 'Dropbox\PubliBridge\Interactive\D'#283'jepis 6'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'Dropbox\PubliBridge\Interactive\D'#283'jepis 6')
    end
    object Button1: TButton
      Left = 13
      Top = 77
      Width = 444
      Height = 25
      Caption = 'SayHello( str )'
      TabOrder = 8
      OnClick = BtnSayHelloClick
    end
    object BtnAddUser: TButton
      Left = 382
      Top = 19
      Width = 35
      Height = 25
      Caption = '+'
      TabOrder = 9
      OnClick = BtnAddUserClick
    end
    object BtnRemoveUser: TButton
      Left = 423
      Top = 19
      Width = 35
      Height = 25
      Caption = '-'
      TabOrder = 10
      OnClick = BtnRemoveUserClick
    end
    object ChkResizable: TCheckBox
      Left = 626
      Top = 46
      Width = 121
      Height = 17
      Caption = 'Resizable'
      TabOrder = 11
    end
  end
  object grpWalkerPlayer: TGroupBox
    Left = 8
    Top = 127
    Width = 757
    Height = 178
    Caption = 'Methods:'
    TabOrder = 2
    object lbl1: TLabel
      Left = 174
      Top = 30
      Width = 42
      Height = 13
      Caption = 'Lessons:'
    end
    object lbl5: TLabel
      Left = 174
      Top = 60
      Width = 53
      Height = 13
      Caption = '3D Stages:'
    end
    object lbl6: TLabel
      Left = 174
      Top = 89
      Width = 30
      Height = 13
      Caption = 'Video:'
    end
    object lbl7: TLabel
      Left = 174
      Top = 119
      Width = 31
      Height = 13
      Caption = 'Audio:'
    end
    object lbl8: TLabel
      Left = 174
      Top = 149
      Width = 39
      Height = 13
      Caption = 'Images:'
    end
    object BtnPlayLesson: TButton
      Left = 13
      Top = 24
      Width = 122
      Height = 25
      Caption = ' Play Lesson'
      TabOrder = 0
      OnClick = BtnPlayLessonClick
    end
    object BtnPlay3D: TButton
      Left = 12
      Top = 54
      Width = 122
      Height = 25
      Caption = ' Play 3D'
      TabOrder = 1
      OnClick = BtnPlay3DClick
    end
    object BtnPlayVideo: TButton
      Left = 12
      Top = 83
      Width = 122
      Height = 25
      Caption = ' Play Video'
      TabOrder = 2
      OnClick = BtnPlayVideoClick
    end
    object BtnPlayAudio: TButton
      Left = 13
      Top = 114
      Width = 122
      Height = 25
      Caption = ' Play Audio'
      TabOrder = 3
      OnClick = BtnPlayAudioClick
    end
    object BtnPlayImages: TButton
      Left = 13
      Top = 143
      Width = 122
      Height = 25
      Caption = ' Play Images'
      TabOrder = 4
      OnClick = BtnPlayImagesClick
    end
    object CbxLessonList: TComboBox
      Left = 254
      Top = 26
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 5
    end
    object Cbx3DList: TComboBox
      Left = 254
      Top = 56
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 6
    end
    object CbxVideoList: TComboBox
      Left = 254
      Top = 85
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 7
    end
    object CbxAudioList: TComboBox
      Left = 254
      Top = 115
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 8
    end
    object CbxPhotoList: TComboBox
      Left = 254
      Top = 145
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 9
    end
  end
end