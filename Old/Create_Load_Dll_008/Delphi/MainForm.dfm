object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Call CSharpDll Methods:'
  ClientHeight = 555
  ClientWidth = 842
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
    Top = 292
    Width = 826
    Height = 255
    Caption = 'Console:'
    TabOrder = 0
    object TxtConsole: TMemo
      Left = 3
      Top = 13
      Width = 820
      Height = 239
      ReadOnly = True
      TabOrder = 0
    end
  end
  object grp1: TGroupBox
    Left = 8
    Top = 8
    Width = 826
    Height = 278
    Caption = '( DLL ) Walker Player Methods:'
    TabOrder = 1
    object lbl4: TLabel
      Left = 169
      Top = 116
      Width = 41
      Height = 13
      Caption = 'SWF dir:'
    end
    object Label4: TLabel
      Left = 168
      Top = 27
      Width = 55
      Height = 13
      Caption = 'User name:'
    end
    object lbl2: TLabel
      Left = 168
      Top = 87
      Width = 42
      Height = 13
      Caption = 'Book dir:'
    end
    object lbl3: TLabel
      Left = 168
      Top = 145
      Width = 48
      Height = 13
      Caption = 'SWF files:'
    end
    object BtnShowPlayer: TButton
      Left = 12
      Top = 82
      Width = 141
      Height = 25
      Caption = 'LoadFile( fpath )'
      TabOrder = 0
      OnClick = BtnShowPlayerClick
    end
    object BtnSayHello: TButton
      Left = 12
      Top = 22
      Width = 142
      Height = 25
      Caption = 'SayHello( str )'
      TabOrder = 1
      OnClick = BtnSayHelloClick
    end
    object CbxBookDirs: TComboBox
      Left = 248
      Top = 84
      Width = 496
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 2
      Text = 'E:\Aprog\Orien\FlashC#\PubliBridge\Interactive\D'#283'jepis 6'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'E:\Aprog\Orien\FlashC#\PubliBridge\Interactive\D'#283'jepis 6'
        'C:\Aprog\Orien\FlashC#\PubliBridge\Interactive\D'#283'jepis 6')
    end
    object BtnBrowseDir: TButton
      Left = 750
      Top = 82
      Width = 59
      Height = 25
      Caption = 'Add Dir...'
      TabOrder = 3
      OnClick = BtnBrowseDirClick
    end
    object EdtName: TEdit
      Left = 248
      Top = 24
      Width = 496
      Height = 21
      TabOrder = 4
      Text = 'Mr.Dalibor and Mr.Rene'
    end
    object CbxSwfDirs: TComboBox
      Left = 248
      Top = 113
      Width = 496
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 5
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
    object ChkAutoPlay: TCheckBox
      Left = 12
      Top = 121
      Width = 141
      Height = 17
      Caption = 'Auto Play'
      Checked = True
      State = cbChecked
      TabOrder = 6
    end
    object CbxSwfFiles: TComboBox
      Left = 248
      Top = 140
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 7
    end
    object ChkFullScreen: TCheckBox
      Left = 12
      Top = 144
      Width = 141
      Height = 17
      Caption = 'Full Screen'
      Checked = True
      State = cbChecked
      TabOrder = 8
    end
    object ChkHidden: TCheckBox
      Left = 12
      Top = 167
      Width = 141
      Height = 17
      Caption = 'Hidden'
      TabOrder = 9
    end
    object ChkFitToScreen: TCheckBox
      Left = 12
      Top = 189
      Width = 141
      Height = 17
      Caption = 'Fit To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 10
    end
    object ChkCenterToScreen: TCheckBox
      Left = 13
      Top = 212
      Width = 141
      Height = 17
      Caption = 'Center To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 11
    end
    object ChkEscapeEnabled: TCheckBox
      Left = 13
      Top = 235
      Width = 141
      Height = 17
      Caption = 'Escape Enabled'
      Checked = True
      State = cbChecked
      TabOrder = 12
    end
  end
end
