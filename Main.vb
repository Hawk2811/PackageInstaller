Public Class Main
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Title = "Abrir pacote" ' Configurando Titulo
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then ' Verifica se o resultado foi OK
            TextBox1.Text = OpenFileDialog1.FileName ' Se sim coloca o nome do arquivo na textbox1
        ElseIf DialogResult.Cancel Then ' Se não for OK
            'Faz Nada
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Mesma coisa do Button2 mas trocando o OpenFileDialog para FolderBrowserDialog
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        ElseIf DialogResult.Cancel Then
            'Nada para fazer
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Operação de Instalar o Programa
        ' o Arquivo .pkg do Instalador de Pacote e nada mais que um zip
        ' então o programa vai fazer uso do info-zip embutido no programa
        Try ' Tenta executar o codigo 
            If IO.Directory.Exists(TextBox2.Text) = False Then
                IO.Directory.CreateDirectory(TextBox2.Text) ' Cria a pasta se não existir
            End If
            Shell("cmd /c " + Application.StartupPath + "\unzip.exe " + TextBox1.Text + " -d " + TextBox2.Text) ' Tenta Extrair o pacote zip para a pasta selecionada
            MessageBox.Show("O pacote foi instalado sem erros")
        Catch ex As Exception ' Em caso de erro ele ira mostrar na tela do usuario
            MessageBox.Show("Erro ao instalar o pacote" + ex.Message, "Instalador de Pacote")
        End Try

    End Sub
End Class
