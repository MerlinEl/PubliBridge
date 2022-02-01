object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'WalkerPlayer.dll > CSharp Methods Call:'
  ClientHeight = 836
  ClientWidth = 770
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = OnFormShown
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox6: TGroupBox
    Left = 8
    Top = 569
    Width = 757
    Height = 263
    Caption = 'Console:'
    TabOrder = 0
    object TxtConsole: TMemo
      Left = 3
      Top = 13
      Width = 747
      Height = 239
      ReadOnly = True
      TabOrder = 0
    end
  end
  object grp1: TGroupBox
    Left = 8
    Top = 72
    Width = 757
    Height = 137
    Caption = 'Test:'
    TabOrder = 1
    object lbl4: TLabel
      Left = 17
      Top = 53
      Width = 41
      Height = 13
      Caption = 'SWF dir:'
    end
    object lbl2: TLabel
      Left = 16
      Top = 24
      Width = 60
      Height = 13
      Caption = 'DropBox dir:'
    end
    object lbl3: TLabel
      Left = 16
      Top = 82
      Width = 48
      Height = 13
      Caption = 'SWF files:'
    end
    object BtnLoadFile2D: TButton
      Left = 161
      Top = 104
      Width = 141
      Height = 25
      Caption = 'LoadFile2D( fpath )'
      TabOrder = 0
      OnClick = BtnLoadFile2DClick
    end
    object BtnSayHello: TButton
      Left = 13
      Top = 104
      Width = 142
      Height = 25
      Caption = 'SayHello( str )'
      TabOrder = 1
      OnClick = BtnSayHelloClick
    end
    object CbxBookDirAll: TComboBox
      Left = 96
      Top = 21
      Width = 654
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 2
      Text = 'Dropbox\PubliBridge\InteractiveAll\D'#283'jepis 6'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'Dropbox\PubliBridge\InteractiveAll\D'#283'jepis 6')
    end
    object CbxSwfDirs: TComboBox
      Left = 96
      Top = 50
      Width = 654
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 3
      Text = 'root'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'root'
        'lessons'
        '3d'
        'audio'
        'video'
        'photos')
    end
    object CbxSwfFiles: TComboBox
      Left = 96
      Top = 77
      Width = 654
      Height = 21
      Style = csDropDownList
      TabOrder = 4
    end
    object BtnLoadFile3D: TButton
      Left = 308
      Top = 104
      Width = 141
      Height = 25
      Caption = 'LoadFile3D( fpath )'
      TabOrder = 5
      OnClick = BtnLoadFile3DClick
    end
  end
  object grpOptions: TGroupBox
    Left = 8
    Top = 438
    Width = 757
    Height = 125
    Caption = 'Options:'
    TabOrder = 2
    object ChkFullScreen: TCheckBox
      Left = 144
      Top = 94
      Width = 141
      Height = 17
      Caption = 'Full Screen'
      Checked = True
      State = cbChecked
      TabOrder = 0
    end
    object ChkFitToScreen: TCheckBox
      Left = 144
      Top = 71
      Width = 86
      Height = 17
      Caption = 'Fit To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 1
    end
    object ChkCenterToScreen: TCheckBox
      Left = 144
      Top = 48
      Width = 141
      Height = 17
      Caption = 'Center To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 2
    end
    object ChkEscapeEnabled: TCheckBox
      Left = 144
      Top = 25
      Width = 141
      Height = 17
      Caption = 'Escape Enabled'
      Checked = True
      State = cbChecked
      TabOrder = 3
    end
    object ChkAutoPlay: TCheckBox
      Left = 13
      Top = 25
      Width = 125
      Height = 17
      Caption = 'Auto Play'
      Checked = True
      State = cbChecked
      TabOrder = 4
    end
    object ChkSkipLogo: TCheckBox
      Left = 13
      Top = 48
      Width = 125
      Height = 17
      Caption = 'Skip Logo'
      TabOrder = 5
    end
    object ChkHiddenPlayer: TCheckBox
      Left = 13
      Top = 71
      Width = 125
      Height = 17
      Caption = 'Hidden Player'
      TabOrder = 6
    end
    object ChkHiddenConsole: TCheckBox
      Left = 13
      Top = 94
      Width = 125
      Height = 17
      Caption = 'Hidden Console'
      TabOrder = 7
    end
  end
  object grpWalkerPlayer: TGroupBox
    Left = 8
    Top = 215
    Width = 757
    Height = 217
    Caption = 'Methods:'
    TabOrder = 3
    object lbl1: TLabel
      Left = 174
      Top = 62
      Width = 42
      Height = 13
      Caption = 'Lessons:'
    end
    object lbl5: TLabel
      Left = 174
      Top = 92
      Width = 53
      Height = 13
      Caption = '3D Stages:'
    end
    object lbl6: TLabel
      Left = 174
      Top = 121
      Width = 30
      Height = 13
      Caption = 'Video:'
    end
    object lbl7: TLabel
      Left = 174
      Top = 151
      Width = 31
      Height = 13
      Caption = 'Audio:'
    end
    object lbl8: TLabel
      Left = 174
      Top = 181
      Width = 39
      Height = 13
      Caption = 'Images:'
    end
    object lbl9: TLabel
      Left = 24
      Top = 32
      Width = 60
      Height = 13
      Caption = 'DropBox dir:'
    end
    object BtnPlayLesson: TButton
      Left = 13
      Top = 56
      Width = 122
      Height = 25
      Caption = ' Play Lesson'
      TabOrder = 0
      OnClick = BtnPlayLessonClick
    end
    object BtnPlay3D: TButton
      Left = 12
      Top = 86
      Width = 122
      Height = 25
      Caption = ' Play 3D'
      TabOrder = 1
      OnClick = BtnPlay3DClick
    end
    object BtnPlayVideo: TButton
      Left = 12
      Top = 115
      Width = 122
      Height = 25
      Caption = ' Play Video'
      TabOrder = 2
      OnClick = BtnPlayVideoClick
    end
    object BtnPlayAudio: TButton
      Left = 13
      Top = 146
      Width = 122
      Height = 25
      Caption = ' Play Audio'
      TabOrder = 3
      OnClick = BtnPlayAudioClick
    end
    object BtnPlayImages: TButton
      Left = 13
      Top = 175
      Width = 122
      Height = 25
      Caption = ' Play Images'
      TabOrder = 4
      OnClick = BtnPlayImagesClick
    end
    object CbxLessonList: TComboBox
      Left = 254
      Top = 58
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 5
    end
    object Cbx3DList: TComboBox
      Left = 254
      Top = 88
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 6
    end
    object CbxVideoList: TComboBox
      Left = 254
      Top = 117
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 7
    end
    object CbxAudioList: TComboBox
      Left = 254
      Top = 147
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 8
    end
    object CbxPhotosList: TComboBox
      Left = 254
      Top = 177
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 9
    end
    object cbb1: TComboBox
      Left = 104
      Top = 29
      Width = 646
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 10
      Text = 'Dropbox\PubliBridge\Interactive\D'#283'jepis 6'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'Dropbox\PubliBridge\Interactive\D'#283'jepis 6')
    end
  end
  object grp2: TGroupBox
    Left = 8
    Top = 8
    Width = 757
    Height = 49
    Caption = 'Global Parameters:'
    TabOrder = 4
    object Label4: TLabel
      Left = 24
      Top = 19
      Width = 55
      Height = 13
      Caption = 'User name:'
    end
    object CbxUserName: TComboBox
      Left = 104
      Top = 15
      Width = 177
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 0
      Text = 'Orien Star'
      OnChange = OnUserDirectoryChanged
      Items.Strings = (
        'Orien Star'
        'merli')
    end
  end
end
