'コンボボックスに追加する項目となるクラス
Public Class MyComboBoxItem

    Private m_id As String = ""
    Private m_name As String = ""

    'コンストラクタ
    Public Sub New(ByVal id As String, ByVal name As String)
        m_id = id
        m_name = name
    End Sub

    '実際の値
    Public ReadOnly Property Id() As String
        Get
            Return m_id
        End Get
    End Property

    '表示名称
    '（このプロパティはこのサンプルでは使わないのでなくても良い）
    Public ReadOnly Property Name() As String
        Get
            Return m_name
        End Get
    End Property

    'オーバーライドしたメソッド
    'これがコンボボックスに表示される
    Public Overrides Function ToString() As String
        Return m_name
    End Function

End Class
