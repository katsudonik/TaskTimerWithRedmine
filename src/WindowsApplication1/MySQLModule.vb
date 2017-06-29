Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Module MySQLModule
    Public gotDatabaseInformation As Collection
    Public Connection As New MySqlConnection
    Public Command As MySqlCommand

    Function openDatabase()
        Dim databaseHost As String = gotDatabaseInformation("databaseHost")
        Dim databaseName As String = gotDatabaseInformation("databaseName")
        Dim databaseUser As String = gotDatabaseInformation("databaseUser")
        Dim databasePassword As String = gotDatabaseInformation("databasePassword")

        Connection = New MySqlConnection
        '接続文字列を設定
        Dim seikei As String = "Database=" + databaseName + ";Data Source=" + databaseHost + ";User Id=" + databaseUser + ";Password=" + databasePassword + ";charset=utf8"
        Connection.ConnectionString = seikei

        openDatabase = True
        Try
            'オープン
            Connection.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("MySQL接続エラー：接続設定を確認して下さい")
            openDatabase = False
        End Try

        'コマンド作成
        Command = Connection.CreateCommand
    End Function
    Function closeDatabase()
        Command.Dispose()
        Connection.Close()
        Connection.Dispose()
    End Function
    Function connectTest(ByVal databaseInformation As Collection)
        gotDatabaseInformation = databaseInformation
        Dim openStatus As Boolean = openDatabase()
        If openStatus <> False Then
            MsgBox("接続が確認されました。")
        End If
    End Function

    Function mysqlSelect(ByVal selectItems As Array, ByVal strSELECT As String)
        Dim DataReader As MySqlDataReader

        Dim openStatus As Boolean = openDatabase()
        If openStatus <> False Then

            Command.CommandText = strSELECT

            'データリーダーにデータ取得
            DataReader = Command.ExecuteReader

            'データを全件出力
            Dim selectItemsResult As New Collection()
            Dim results As New Collection()

            Dim number As Integer
            Do Until Not DataReader.Read
                selectItemsResult = New Collection
                For Each selectItem In selectItems
                    selectItemsResult.Add(DataReader.Item(selectItem).ToString, selectItem)
                Next
                results.Add(selectItemsResult, number)
                number = number + 1
            Loop
            '破棄
            DataReader.Close()
            Call closeDatabase()
            mysqlSelect = results
        End If
    End Function
    Function mysqlInsert(ByVal strINSERT As String)
        Call openDatabase()

        'コメント、時間を記録
        Command.CommandText = strINSERT
        Dim ret As Integer = Command.ExecuteNonQuery()
        'MsgBox("登録件数:" + ret.ToString())
        'MsgBox("登録しました:" + ret.ToString())
        Call closeDatabase()
    End Function



    Function getTicketList(ByVal ticketComboBoxes As Array, ByVal databaseInformation As Collection)
        If databaseInformation Is Nothing Then
        Else
            gotDatabaseInformation = databaseInformation

            Dim strSELECT = "SELECT issues.id as id,issues.subject as subject FROM issues"

            Dim selectItem() As String = {"id", "subject"}
            Dim results As Collection
            results = mysqlSelect(selectItem, strSELECT)

            Dim dataCnt As Integer = 0
            If results Is Nothing Then
            Else
                dataCnt = results.Count
                For Each ticketComboBox In ticketComboBoxes
                    ticketComboBox.Items.Clear()
                    For Each result In results
                        ticketComboBox.Items.Add(result("subject"))
                    Next
                Next
            End If
            MsgBox("取得データ：" + dataCnt.ToString + "件")
        End If
    End Function
    'Function registUsedTime(ByVal taskName As TextBox, ByVal hour As TextBox, ByVal ticketComboBox As ComboBox)
    '    Dim comments As String = taskName.Text
    '    Dim hours As String = hour.Text
    '    Dim issue_id As String = ticketComboBox.SelectedIndex + 1
    '    Dim strINSERT As String = "INSERT INTO `redmine_development`.`time_entries` ( `project_id`, `user_id`, `issue_id`, `hours`, `comments`, `activity_id`, `spent_on`, `tyear`, `tmonth`, `tweek`, `created_on`, `updated_on`) VALUES ( '2', '1', '" + issue_id + "', '" + hours + "', '" + comments + "', '8', '2014-03-09', '2014', '3', '10', '2014-03-09 16:49:55', '2014-03-09 16:49:55');"
    '    If ticketComboBox.SelectedItem = "" Then
    '        MsgBox("チケットを選択して下さい")
    '    Else
    '        Call mysqlInsert(strINSERT)
    '    End If
    'End Function
    Function registUsedTime(ByVal taskName As TextBox, ByVal hour As TextBox, ByVal num As String, ByVal ticketData As Collection)
        If (ticketData.Contains(num)) Then
            Dim comments As String = taskName.Text
            Dim hours As String = hour.Text
            Dim issue_id As String = ticketData(num)
            ' 現在の日付を取得する
            Dim dtToday As DateTime = DateTime.Today
            Dim today As String = dtToday.Year.ToString + "-" + dtToday.Month.ToString + "-" + dtToday.Day.ToString
            Dim now As String = "'" + today + " " + System.DateTime.Now.Hour.ToString + ":" + System.DateTime.Now.Minute.ToString + ":" + System.DateTime.Now.Second.ToString + "'"



            Dim strINSERT As String = "INSERT INTO `redmine_development`.`time_entries` ( `project_id`, `user_id`, `issue_id`, `hours`, `comments`, `activity_id`, `spent_on`, `tyear`, `tmonth`, `tweek`, `created_on`, `updated_on`) VALUES ( '2', '1', '" + issue_id + "', '" + hours + "', '" + comments + "', '8', '" + today + "', " + dtToday.Year.ToString + "," + dtToday.Month.ToString + "," + dtToday.Day.ToString + "," + now + "," + now + ");"
            Call mysqlInsert(strINSERT)

            Dim strSELECT As String = "SELECT LAST_INSERT_ID() As id"
            Dim selectItems() As String = {"id"}
            Dim results As New Collection()
            results = mysqlSelect(selectItems, strSELECT)
            If results Is Nothing Then
            Else
                For Each result In results
                    MsgBox("登録しました（id:" + result("id") + ")")
                Next
            End If

        Else
            MsgBox("チケットを選択して下さい")
        End If
    End Function
    Function getTrackerId(ByVal trackerName As String)
        Dim strSELECT As String = "SELECT id as id,name as name FROM trackers where trackers.name='" + trackerName + "'"
        Dim selectItem() As String = {"id", "name"}
        Dim tracker_id As String
        Dim results As Collection
        results = mysqlSelect(selectItem, strSELECT)
        If results Is Nothing Then
        Else
            For Each result In results
                tracker_id = result("id")
            Next
        End If
        getTrackerId = tracker_id
    End Function
    Function getTicketNameCollection(ByVal tracker_id As String, ByVal project_id As String, Optional ByVal parent_id As String = "") As Collection
        Dim strSELECT As String
        Dim selectItem() As String
        Dim results As Collection
        '選択されたプロジェクトのtrackerがタスクであるチケットを抽出
        'strSELECT = "SELECT issues.id as id,issues.subject as subject FROM issues where project_id=" + project_id + " and tracker_id=" + tracker_id + ""
        strSELECT = "SELECT issues.id as id,issues.subject as subject FROM issues where "
        If project_id <> "" Then
            strSELECT = strSELECT + "project_id=" + project_id + " and tracker_id=" + tracker_id + " and "
        End If
        strSELECT = strSELECT + "tracker_id=" + tracker_id + ""


        If parent_id <> "" Then
            strSELECT = strSELECT + " and parent_id = " + parent_id + ""
        End If

        selectItem = {"id", "subject"}
        results = New Collection
        getTicketNameCollection = mysqlSelect(selectItem, strSELECT)
    End Function


    Public databaseInformationElement() As String

    Function saveDatabaseInformation(ByVal databaseInformation)
        'Shift JISで書き込む
        '書き込むファイルが既に存在している場合は、上書きする
        Dim filePath = getFilePath("database_setting.csv")
        Try
            Dim sw As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.GetEncoding("shift_jis"))
            Dim delemiter As String = ","

            Dim Cnt As Integer = 0
            Dim strElement As String = ""
            For Each element In databaseInformationElement
                If Cnt > 0 Then
                    strElement = strElement + delemiter + element
                Else
                    strElement = element
                End If
                Cnt = Cnt + 1
            Next
            '列名書き
            sw.WriteLine(strElement)
            Cnt = 0
            Dim thisData As String = ""
            For Each element As String In databaseInformationElement
                If Cnt > 0 Then
                    thisData = thisData + delemiter + databaseInformation(element)
                Else
                    thisData = databaseInformation(element)
                End If
                Cnt = Cnt + 1
            Next
            sw.WriteLine(thisData)
            '閉じる
            sw.Close()
            saveDatabaseInformation = True
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox("ファイル：" + filePath + "を閉じてください。")
            filePath.close()
            saveDatabaseInformation = False
        End Try
    End Function
    Function getDatabaseInformation()
        databaseInformationElement = {"databaseHost", "databaseName", "databaseUser", "databasePassword"}
        Dim filePath = getFilePath("database_setting.csv")
        If System.IO.File.Exists(filePath) Then
            Dim gotData As New Collection()
            gotData = csvLoad(filePath, "Shift_JIS", databaseInformationElement)
            gotDatabaseInformation = New Collection
            For Each element In databaseInformationElement
                gotDatabaseInformation.Add(gotData(element), element)
            Next
        End If
        getDatabaseInformation = gotDatabaseInformation
    End Function
    Function csvLoad(ByVal filePath As String, ByVal encode As String, ByVal getElement As Array)
        Dim delemiter As String = ","
        Dim parser As New TextFieldParser(filePath, _
        System.Text.Encoding.GetEncoding(encode))
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(delemiter)

        Dim RowsData As New Collection()
        Dim ColumnsData As New Collection()
        Dim Row = 0
        While Not parser.EndOfData
            Dim thisRowStr As String() = parser.ReadFields() ' 1行読み込み
            If Row > 0 Then
                For Column = 0 To thisRowStr.Length - 1
                    ColumnsData.Add(thisRowStr(Column), getElement(Column))
                Next
            End If
            Row = Row + 1
        End While
        csvLoad = ColumnsData
    End Function
    Function getFilePath(ByVal fileName As String)
        Dim appPath As String = _
        System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim directoryName As String
        directoryName = Path.GetDirectoryName(appPath)
        Dim filePath As String = directoryName + "\" + fileName
            getFilePath = filePath
    End Function
End Module
