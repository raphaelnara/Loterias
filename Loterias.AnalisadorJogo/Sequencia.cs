namespace Loterias.AnalisadorJogo
{
    public class Sequencia : Intervalo
    {
        public int IndiceLinha { get; }

        public Sequencia(int indiceLinha)
        {
            IndiceLinha = indiceLinha;
        }
    }
}
