namespace EletronicSystem.Business.ViewModels
{
    public class BaseViewModel
    {
        public string Msg { get; set; }
        public Dictionary<string, string> MsgErro { get; set; } = new Dictionary<string, string>();
        public bool OperacaoValida { get; set; }
    }
}
