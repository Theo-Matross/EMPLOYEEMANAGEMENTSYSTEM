﻿Imports MySql.Data.MySqlClient

Public Class EmployeeDetails

    Dim Conn As New MySqlConnection
    Dim COMMAND As New MySqlCommand


    Private Sub EmployeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub FetchEmployeeData()
        If EmpId.Text = "" Then
            MsgBox("Enter employee id to search for")
        Else
            Conn = New MySqlConnection With {
                .ConnectionString = "server=localhost; userid=root; password=lost1234; database=employee_db"
                }
            Conn.Open()
            Dim query = "SELECT * FROM employee WHERE id='" & EmpId.Text & "'"
            COMMAND = New MySqlCommand(query, Conn)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As MySqlDataAdapter
            sda = New MySqlDataAdapter(COMMAND)
            sda.Fill(dt)
            For Each dr As DataRow In dt.Rows
                NameTb.Text = dr(1).ToString()
                AddressTb.Text = dr(2).ToString()
                PhoneTb.Text = dr(3).ToString()
                GenderTb.Text = dr(4).ToString()
                PosTb.Text = dr(5).ToString()
                EdlevTb.Text = dr(6).ToString()
                DOBTb.Text = dr(7).ToString()

                NameTb.Visible = True
                AddressTb.Visible = True
                PhoneTb.Visible = True
                GenderTb.Visible = True
                PosTb.Visible = True
                EdlevTb.Visible = True
                DOBTb.Visible = True

            Next
            Conn.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FetchEmployeeData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim main = New MainForm
        main.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("Employee Management System", New Font("Century Gothic", 25), Brushes.DarkGreen, 180, 40)
        e.Graphics.DrawString("******EMPLOYEE DETAILS********", New Font("Arial", 20), Brushes.Crimson, 330, 100)
        e.Graphics.DrawString("Name: " + NameTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Employee Id: " + EmpId.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Address: " + AddressTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Phone: " + PhoneTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Position: " + PosTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Education: " + EdlevTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("Gender: " + GenderTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("DOB: " + DOBTb.Text, New Font("century Gothic", 20), Brushes.Black, 150, 190)
        e.Graphics.DrawString("=================", New Font("Century Gothic", 15), Brushes.DarkGreen, 150, 150)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Application.Exit()
    End Sub
End Class