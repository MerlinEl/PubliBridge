object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'WalkerPlayer.dll > CSharp Methods Call:'
  ClientHeight = 296
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
    Left = 5
    Top = 79
    Width = 757
    Height = 210
    Caption = 'Console:'
    TabOrder = 0
    object TxtConsole: TMemo
      Left = 3
      Top = 21
      Width = 747
      Height = 180
      ReadOnly = True
      TabOrder = 0
    end
  end
  object grpOptions: TGroupBox
    Left = 8
    Top = 5
    Width = 757
    Height = 68
    Caption = 'CSharp DLL:'
    TabOrder = 1
    object Button1: TButton
      Left = 3
      Top = 21
      Width = 121
      Height = 25
      Caption = 'SayHello( str )'
      TabOrder = 0
      OnClick = BtnSayHelloClick
    end
    object BtnOpenCSharpPanel: TButton
      Left = 626
      Top = 21
      Width = 121
      Height = 25
      Caption = ' Open CSharp Panel'
      TabOrder = 1
      OnClick = BtnOpenCSharpPanelClick
    end
    object EdtUserName: TLabeledEdit
      Left = 130
      Top = 23
      Width = 121
      Height = 21
      EditLabel.Width = 59
      EditLabel.Height = 13
      EditLabel.Caption = ' User Name:'
      TabOrder = 2
      Text = 'MerlinEl'
    end
  end
end
