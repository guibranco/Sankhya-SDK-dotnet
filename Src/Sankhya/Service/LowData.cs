namespace Sankhya.Service;

using System.ComponentModel;
using System.Xml.Serialization;

//TODO: issue #60
/// <summary>
/// Class LowData. This class cannot be inherited.
/// </summary>
public sealed class LowData
{
    #region Private Members

    /// <summary>
    /// The financial numbers list
    /// </summary>
    private string _financialNumbersList;

    /// <summary>
    /// The financial numbers list set
    /// </summary>
    private bool _financialNumbersListSet;

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the financial numbers list.
    /// </summary>
    /// <value>The financial numbers list.</value>
    [XmlAttribute("listaNuFins")]
    public string FinancialNumbersList
    {
        get => _financialNumbersList;
        set
        {
            _financialNumbersList = value;
            _financialNumbersListSet = true;
        }
    }

    #endregion

    #region Serializer Helpers

    /// <summary>
    /// Should the serialize financial numbers list.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumbersList() => _financialNumbersListSet;

    #endregion

    /// <summary>
    /// Gets or sets the dt baixa.
    /// </summary>
    /// <value>The dt baixa.</value>
    [XmlAttribute("dtBaixa")]
    public string DtBaixa { get; set; }

    /// <summary>
    /// Gets or sets the empresa.
    /// </summary>
    /// <value>The empresa.</value>
    [XmlAttribute("empresa")]
    public string Empresa { get; set; }

    /// <summary>
    /// Gets or sets the conta bco.
    /// </summary>
    /// <value>The conta bco.</value>
    [XmlAttribute("contaBco")]
    public string ContaBco { get; set; }

    /// <summary>
    /// Gets or sets the ordem carga.
    /// </summary>
    /// <value>The ordem carga.</value>
    [XmlAttribute("ordemCarga")]
    public string OrdemCarga { get; set; }

    /// <summary>
    /// Gets or sets the CHK receita.
    /// </summary>
    /// <value>The CHK receita.</value>
    [XmlAttribute("chkReceita")]
    public string ChkReceita { get; set; }

    /// <summary>
    /// Gets or sets the CHK despesa.
    /// </summary>
    /// <value>The CHK despesa.</value>
    [XmlAttribute("chkDespesa")]
    public string ChkDespesa { get; set; }

    /// <summary>
    /// Gets or sets the CHK baixa separada.
    /// </summary>
    /// <value>The CHK baixa separada.</value>
    [XmlAttribute("chkBaixaseparada")]
    public string ChkBaixaSeparada { get; set; }

    /// <summary>
    /// Gets or sets the chk usar hist.
    /// </summary>
    /// <value>The chk usar hist.</value>
    [XmlAttribute("chkusarHist")]
    public string ChkUsarHist { get; set; }

    /// <summary>
    /// Gets or sets the chk nosso number.
    /// </summary>
    /// <value>The chk nosso number.</value>
    [XmlAttribute("chknossoNum")]
    public string ChkNossoNum { get; set; }

    /// <summary>
    /// Gets or sets the CHK VLR liq zero.
    /// </summary>
    /// <value>The CHK VLR liq zero.</value>
    [XmlAttribute("chkvlrLiqZero")]
    public string ChkVlrLiqZero { get; set; }

    /// <summary>
    /// Gets or sets the RBD concat sobrepor hist fin.
    /// </summary>
    /// <value>The RBD concat sobrepor hist fin.</value>
    [XmlAttribute("rbdConcatSobreporHistFin")]
    public string RbdConcatSobreporHistFin { get; set; }

    /// <summary>
    /// Gets or sets the cor despesa.
    /// </summary>
    /// <value>The cor despesa.</value>
    [XmlAttribute("corDespesa")]
    public string CorDespesa { get; set; }

    /// <summary>
    /// Gets or sets the cor receita.
    /// </summary>
    /// <value>The cor receita.</value>
    [XmlAttribute("corReceita")]
    public string CorReceita { get; set; }

    /// <summary>
    /// Gets or sets the CHK usa venc.
    /// </summary>
    /// <value>The CHK usa venc.</value>
    [XmlAttribute("chkUsaVenc")]
    public string ChkUsaVenc { get; set; }

    /// <summary>
    /// Gets or sets the text number document.
    /// </summary>
    /// <value>The text number document.</value>
    [XmlAttribute("txtNumDoc")]
    public string TxtNumDoc { get; set; }

    /// <summary>
    /// Gets or sets the CHK sub inf.
    /// </summary>
    /// <value>The CHK sub inf.</value>
    [XmlAttribute("chkSubInf")]
    public string ChkSubInf { get; set; }

    /// <summary>
    /// Gets or sets the text historico.
    /// </summary>
    /// <value>The text historico.</value>
    [XmlAttribute("txtHistorico")]
    public string TxtHistorico { get; set; }

    /// <summary>
    /// Gets or sets the tip lanc record.
    /// </summary>
    /// <value>The tip lanc record.</value>
    [XmlAttribute("tiplancRec")]
    public string TipLancRec { get; set; }

    /// <summary>
    /// Gets or sets the top baixa record.
    /// </summary>
    /// <value>The top baixa record.</value>
    [XmlAttribute("topBaixaRec")]
    public string TopBaixaRec { get; set; }

    /// <summary>
    /// Gets or sets the tip lanc desp.
    /// </summary>
    /// <value>The tip lanc desp.</value>
    [XmlAttribute("tiplancDesp")]
    public string TipLancDesp { get; set; }

    /// <summary>
    /// Gets or sets the top baixa desp.
    /// </summary>
    /// <value>The top baixa desp.</value>
    [XmlAttribute("topBaixaDesp")]
    public string TopBaixaDesp { get; set; }

    /// <summary>
    /// Gets or sets the tem filtro antecipacao bx.
    /// </summary>
    /// <value>The tem filtro antecipacao bx.</value>
    [XmlAttribute("temFiltroAntecipacaoBx")]
    public string TemFiltroAntecipacaoBx { get; set; }

    /// <summary>
    /// Gets or sets the nu antecipa.
    /// </summary>
    /// <value>The nu antecipa.</value>
    [XmlAttribute("nuAntecipa")]
    public string NuAntecipa { get; set; }

    /// <summary>
    /// Gets or sets the parc antecipa.
    /// </summary>
    /// <value>The parc antecipa.</value>
    [XmlAttribute("parcAntecipa")]
    public string ParcAntecipa { get; set; }

    /// <summary>
    /// Gets or sets the ant bx top.
    /// </summary>
    /// <value>The ant bx top.</value>
    [XmlAttribute("antBxTop")]
    public string AntBxTop { get; set; }

    /// <summary>
    /// Gets or sets the ant bx tip tit.
    /// </summary>
    /// <value>The ant bx tip tit.</value>
    [XmlAttribute("antBxTipTit")]
    public string AntBxTipTit { get; set; }

    /// <summary>
    /// Gets or sets the ant bx natureza.
    /// </summary>
    /// <value>The ant bx natureza.</value>
    [XmlAttribute("antBxNatureza")]
    public string AntBxNatureza { get; set; }

    /// <summary>
    /// Gets or sets the ant bx cen cus.
    /// </summary>
    /// <value>The ant bx cen cus.</value>
    [XmlAttribute("antBxCenCus")]
    public string AntBxCenCus { get; set; }

    /// <summary>
    /// Gets or sets the ant bx conta baixa.
    /// </summary>
    /// <value>The ant bx conta baixa.</value>
    [XmlAttribute("antBxContaBaixa")]
    public string AntBxContaBaixa { get; set; }

    /// <summary>
    /// Gets or sets the ant bx top baixa.
    /// </summary>
    /// <value>The ant bx top baixa.</value>
    [XmlAttribute("antBxTopBaixa")]
    public string AntBxTopBaixa { get; set; }

    /// <summary>
    /// Gets or sets the ant bx lanc baixa.
    /// </summary>
    /// <value>The ant bx lanc baixa.</value>
    [XmlAttribute("antBxLancBaixa")]
    public string AntBxLancBaixa { get; set; }

    /// <summary>
    /// Gets or sets the ant bx hist baixa.
    /// </summary>
    /// <value>The ant bx hist baixa.</value>
    [XmlAttribute("antBxHistBaixa")]
    public string AntBxHistBaixa { get; set; }

    /// <summary>
    /// Gets or sets the ant bx impressora.
    /// </summary>
    /// <value>The ant bx impressora.</value>
    [XmlAttribute("antBxImpressora")]
    public string AntBxImpressora { get; set; }

    /// <summary>
    /// Gets or sets the parameter imprime boleto.
    /// </summary>
    /// <value>The parameter imprime boleto.</value>
    [XmlAttribute("paramImprimeBoleto")]
    public string ParamImprimeBoleto { get; set; }
}
