object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Call Dll Methods:'
  ClientHeight = 256
  ClientWidth = 425
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label2: TLabel
    Left = 8
    Top = 89
    Width = 42
    Height = 13
    Caption = 'Console:'
  end
  object BtnMin: TButton
    Left = 8
    Top = 8
    Width = 138
    Height = 25
    Caption = 'Call Min()'
    TabOrder = 0
    OnClick = BtnMinClick
  end
  object EdtValA: TEdit
    Left = 169
    Top = 26
    Width = 121
    Height = 21
    TabOrder = 1
    Text = '5'
  end
  object EdtValB: TEdit
    Left = 296
    Top = 26
    Width = 121
    Height = 21
    TabOrder = 2
    Text = '10'
  end
  object BtnMax: TButton
    Left = 8
    Top = 39
    Width = 138
    Height = 25
    Caption = 'Call Max()'
    TabOrder = 3
    OnClick = BtnMaxClick
  end
  object Panel1: TPanel
    Left = 8
    Top = 74
    Width = 409
    Height = 9
    Caption = 'Panel1'
    TabOrder = 4
  end
  object TxtConsole: TMemo
    Left = 8
    Top = 108
    Width = 409
    Height = 138
    Lines.Strings = (
      '')
    ReadOnly = True
    TabOrder = 5
  end
end
