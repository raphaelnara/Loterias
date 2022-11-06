using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Loterias.AnalisadorJogo
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            rbUmJogo_CheckedChanged(null, null);
            cbTipoDeJogo.SelectedIndex = 0;
            cbTamanhoBloco.SelectedIndex = 0;
        }

        private void rbUmJogo_CheckedChanged(object sender, EventArgs e)
        {
            lblDescricaoJogo.Text = "Insira os números do jogo no campo abaixo, separados por ponto e vírgula:";
            txtJogo.Enabled = true;
            btnAbrirArquivoJogos.Visible = false;
        }

        private void rbConjuntoJogos_CheckedChanged(object sender, EventArgs e)
        {
            lblDescricaoJogo.Text = "Selecione o arquivo CSV com os jogos:";
            txtJogo.Enabled = false;
            btnAbrirArquivoJogos.Visible = true;
        }

        private void btnAnalisar_Click(object sender, EventArgs e)
        {
            try
            {
                var caminhoArquivoHistorico = txtJogo.Text;
                if (string.IsNullOrWhiteSpace(caminhoArquivoHistorico))
                    throw new InvalidOperationException("Caminho de arquivo de histórico inválido");
                if (!File.Exists(caminhoArquivoHistorico))
                    throw new FileNotFoundException("Arquivo de historico inexistente!");

                //analisar historico

                var infoJogo = ObterInformacoesJogo();

                if (rbConjuntoJogos.Checked)
                {
                    var caminhoArquivoJogos = txtJogo.Text;
                    if (string.IsNullOrWhiteSpace(caminhoArquivoHistorico))
                        throw new InvalidOperationException("Caminho de arquivo de jogos inválido");
                    if (!File.Exists(caminhoArquivoJogos))
                        throw new FileNotFoundException("Arquivo inexistente!");

                    var dictNumeros = ObterDadosArquivo(caminhoArquivoJogos);
                    if (dictNumeros.Values.Any(n => n.Length != infoJogo.QuantidadeNumerosSorteio))
                        throw new InvalidOperationException($"Todas as linhas do arquivo devem ter {infoJogo.QuantidadeNumerosSorteio} números!");

                    //analisar medias dos numeros

                    return;
                }

                var numeros = txtJogo.Text.Split(';')
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(c =>
                    {
                        if (int.TryParse(c, out var num)) return num;
                        throw new InvalidCastException("Alguns dados inseridos não puderam ser convertidos em número!");
                    }).ToArray();

                // analisar esses numeros

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirArquivoJogos_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialogJogos.ShowDialog();
            if (dialogResult == DialogResult.OK) txtJogo.Text = openFileDialogJogos.FileName;
        }

        private void btnArquivoHistorico_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialogHistorico.ShowDialog();
            if (dialogResult == DialogResult.OK) txtArquivoHistorico.Text = openFileDialogHistorico.FileName;
        }

        private Dictionary<int, int[]> ObterDadosArquivo(string arquivo)
        {
            var dictLinhas = new Dictionary<int, int[]>();

            int iLine = 1;
            using (var reader = new StreamReader(arquivo, Encoding.UTF8))
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(';').Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
                    dictLinhas[iLine] = new int[parts.Length];
                    for (int iColumn = 0; iColumn < parts.Length; iColumn++)
                    {
                        if (!int.TryParse(parts[iColumn], out var num)) continue;
                        dictLinhas[iLine][iColumn] = num;
                    }
                    iLine++;
                }

            return dictLinhas;
        }

        private InformacoesJogo ObterInformacoesJogo()
        {
            switch (cbTipoDeJogo.SelectedText)
            {
                case "Lotofácil":
                    return new InformacoesJogo
                    {
                        QuantidadeNumerosDisponiveis = 25,
                        QuantidadeNumerosMarcados = 15,
                        QuantidadeNumerosSorteio = 15,
                        IncluiZero = false
                    };
                case "Lotomania":
                    return new InformacoesJogo
                    {
                        QuantidadeNumerosDisponiveis = 100,
                        QuantidadeNumerosMarcados = 50,
                        QuantidadeNumerosSorteio = 20,
                        IncluiZero = true
                    };
                default:
                    throw new ArgumentOutOfRangeException("Tipo de jogo não disponível");
            }
        }

        private IEnumerable<Sequencia> ObterSequenciasDeNumeros(int indiceLinha, int[] linha)
        {
            var linhaOrdenada = linha.OrderBy(n => n).ToArray();

            int iAtual = 0;
            while (iAtual < linhaOrdenada.Length)
            {
                var sequencia = new Sequencia(indiceLinha);

                int iProximo = iAtual + 1;
                while (iProximo < linhaOrdenada.Length)
                {
                    var atual = linhaOrdenada[iAtual];
                    var proximo = linhaOrdenada[iProximo];
                    if (atual + 1 == proximo)
                    {
                        sequencia.Add(atual);
                        sequencia.Add(proximo);

                        iAtual = iProximo;
                        iProximo = iAtual + 1;
                    }
                    else
                        break;
                }
                if (sequencia.Quantidade != 0) yield return sequencia;
                iAtual++;
            }
        }

        private IEnumerable<Intervalo> ObterIntervalos(int[] cartela, int[] resultado)
        {
            var cartelaOrdenada = cartela.OrderBy(n => n).ToArray();
            var intervalo = new Intervalo();
            for (int i = 0; i < cartelaOrdenada.Length; i++)
            {
                if (resultado.Contains(cartelaOrdenada[i]))
                {
                    if (intervalo.Numeros.Count() != 0)
                    {
                        yield return intervalo;
                        intervalo = new Intervalo();
                    }
                    continue;
                }
                intervalo.Add(cartelaOrdenada[i]);
                if (i + 1 == cartelaOrdenada.Length) yield return intervalo;
            }
        }

        private bool Primo(int num)
        {
            for (int i = 2; i < num; i++) if (num % i == 0) return false;
            return true;
        }
    }
}
