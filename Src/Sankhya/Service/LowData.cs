using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

/// <summary>
/// Class LowData. This class cannot be inherited.
/// </summary>
[Serializable]
[XmlRoot("dadosBaixa")]
public sealed class LowData
{
    /// <summary>
    /// The financial numbers list
    /// </summary>
    private string _financialNumbersList;

    /// <summary>
    /// The financial numbers list set
    /// </summary>
    private bool _financialNumbersListSet;

    /// <summary>
    /// The dt baixa
    /// </summary>
    private string _dtBaixa;

    /// <summary>
    /// The dt baixa set
    /// </summary>
    private bool _dtBaixaSet;

    /// <summary>
    /// The empresa
    /// </summary>
    private string _empresa;

    /// <summary>
    /// The empresa set
    /// </summary>
    private bool _empresaSet;

    /// <summary>
    /// The conta bco
    /// </summary>
    private string _contaBco;

    /// <summary>
    /// The conta bco set
    /// </summary>
    private bool _contaBcoSet;

    /// <summary>
    /// The ordem carga
    /// </summary>
    private string _ordemCarga;

    /// <summary>
    /// The ordem carga set
    /// </summary>
    private bool _ordemCargaSet;

    /// <summary>
    /// The CHK receita
    /// </summary>
    private string _chkReceita;

    /// <summary>
    /// T/// he CHK rece/// ita set
    /// </summary>
    private bool _chkReceitaSet;

    /// <summary>
    /// The CHK despesa
    /// </summary>
    private string _chkDespesa;

    /// <summary>
    /// The CHK despesa set
    /// </summary>
    private bool _chkDespesaSet;

    /// <summary>
    /// The CHK baixa separada
    /// </summary>
    private string _chkBaixaSeparada;

    /// <summary>
    /// The CHK baixa separada set
    /// </summary>
    private bool _chkBaixaSeparadaSet;

    /// <summary>
    /// The chk usar hist
    /// </summary>
    private string _chkUsarHist;

    /// <summary>
    /// The chk usar hist set
    /// </summary>
    private bool _chkUsarHistSet;

    /// <summary>
    /// The chk nosso num
    /// </summary>
    private string _chkNossoNum;

    /// <summary>
    /// The chk nosso num set
    /// </summary>
    private bool _chkNossoNumSet;

    /// <summary>
    /// The CHK VLR liq zero
    /// </summary>
    private string _chkVlrLiqZero;

    /// <summary>
    /// The CHK VLR liq zero set
    /// </summary>
    private bool _chkVlrLiqZeroSet;

    /// <summary>
    /// The RBD concat sobrepor hist fin
    /// </summary>
    private string _rbdConcatSobreporHistFin;

    /// <summary>
    /// The RBD concat sobrepor hist fin set
    /// </summary>
    private bool _rbdConcatSobreporHistFinSet;

    /// <summary>
    /// The cor despesa
    /// </summary>
    private string _corDespesa;

    /// <summary>
    /// The cor despesa set
    /// </summary>
    private bool _corDespesaSet;

    /// <summary>
    /// The cor receita
    /// </summary>
    private string _corReceita;

    /// <summary>
    /// The cor receita set
    /// </summary>
    private bool _corReceitaSet;

    /// <summary>
    /// The CHK usa venc
    /// </summary>
    private string _chkUsaVenc;

    /// <summary>
    /// The CHK usa venc set
    /// </summary>
    private bool _chkUsaVencSet;

    /// <summary>
    /// The text number document
    /// </summary>
    private string _txtNumDoc;

    /// <summary>
    /// The text number document set
    /// </summary>
    private bool _txtNumDocSet;

    /// <summary>
    /// The CHK sub inf
    /// </summary>
    private string _chkSubInf;

    /// <summary>
    /// The CHK sub inf set
    /// </summary>
    private bool _chkSubInfSet;

    /// <summary>
    /// The text historico
    /// </summary>
    private string _txtHistorico;

    /// <summary>
    /// The text historico set
    /// </summary>
    private bool _txtHistoricoSet;

    /// <summary>
    /// The tip lanc rec
    /// </summary>
    private string _tipLancRec;

    /// <summary>
    /// The tip lanc rec set
    /// </summary>
    private bool _tipLancRecSet;

    /// <summary>
    /// The top baixa rec
    /// </summary>
    private string _topBaixaRec;

    /// <summary>
    /// The top baixa rec set
    /// </summary>
    private bool _topBaixaRecSet;

    /// <summary>
    /// The tip lanc desp
    /// </summary>
    private string _tipLancDesp;

    /// <summary>
    /// The tip lanc desp set
    /// </summary>
    private bool _tipLancDespSet;

    /// <summary>
    /// The top baixa desp
    /// </summary>
    private string _topBaixaDesp;

    /// <summary>
    /// The top baixa desp set
    /// </summary>
    private bool _topBaixaDespSet;

    /// <summary>
    /// The tem filtro antecipacao bx
    /// </summary>
    private string _temFiltroAntecipacaoBx;

    /// <summary>
    /// The tem filtro antecipacao bx set
    /// </summary>
    private bool _temFiltroAntecipacaoBxSet;

    /// <summary>
    /// The nu antecipa
    /// </summary>
    private string _nuAntecipa;

    /// <summary>
    /// The nu antecipa set
    /// </summary>
    private bool _nuAntecipaSet;

    /// <summary>
    /// The parc antecipa
    /// </summary>
    private string _parcAntecipa;

    /// <summary>
    /// The parc antecipa set
    /// </summary>
    private bool _parcAntecipaSet;

    /// <summary>
    /// The ant bx top
    /// </summary>
    private string _antBxTop;

    /// <summary>
    /// The ant bx top set
    /// </summary>
    private bool _antBxTopSet;

    /// <summary>
    /// The ant bx tip tit
    /// </summary>
    private string _antBxTipTit;

    /// <summary>
    /// The ant bx tip tit set
    /// </summary>
    private bool _antBxTipTitSet;

    /// <summary>
    /// The ant bx natureza
    /// </summary>
    private string _antBxNatureza;

    /// <summary>
    /// The ant bx natureza set
    /// </summary>
    private bool _antBxNaturezaSet;

    /// <summary>
    /// The ant bx cen cus
    /// </summary>
    private string _antBxCenCus;

    /// <summary>
    /// The ant bx cen cus set
    /// </summary>
    private bool _antBxCenCusSet;

    /// <summary>
    /// The ant bx conta baixa
    /// </summary>
    private string _antBxContaBaixa;

    /// <summary>
    /// The ant bx conta baixa set
    /// </summary>
    private bool _antBxContaBaixaSet;

    /// <summary>
    /// The ant bx top baixa
    /// </summary>
    private string _antBxTopBaixa;

    /// <summary>
    /// The ant bx top baixa set
    /// </summary>
    private bool _antBxTopBaixaSet;

    /// <summary>
    /// The ant bx lanc baixa
    /// </summary>
    private string _antBxLancBaixa;

    /// <summary>
    /// The ant bx lanc baixa set
    /// </summary>
    private bool _antBxLancBaixaSet;

    /// <summary>
    /// The ant bx hist baixa
    /// </summary>
    private string _antBxHistBaixa;

    /// <summary>
    /// The ant bx hist baixa set
    /// </summary>
    private bool _antBxHistBaixaSet;

    /// <summary>
    /// The ant bx impressora
    /// </summary>
    private string _antBxImpressora;

    /// <summary>
    /// The ant bx impressora set
    /// </summary>
    private bool _antBxImpressoraSet;

    /// <summary>
    /// The param imprime boleto
    /// </summary>
    private string _paramImprimeBoleto;

    /// <summary>
    /// The param imprime boleto set
    /// </summary>
    private bool _paramImprimeBoletoSet;

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

    /// <summary>
    /// Gets or sets the dt baixa.
    /// </summary>
    /// <value>The dt baixa .</value>
    [XmlAttribute("dtBaixa")]
    public string DtBaixa
    {
        get => _dtBaixa;
        set
        {
            _dtBaixa = value;
            _dtBaixaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the empresa.
    /// </summary>
    /// <value>The empresa.</value>
    [XmlAttribute("empresa")]
    public string Empresa
    {
        get => _empresa;
        set
        {
            _empresa = value;
            _empresaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the conta bco.
    /// </summary>
    /// <value>The conta bco.</value>
    [XmlAttribute("contaBco")]
    public string ContaBco
    {
        get => _contaBco;
        set
        {
            _contaBco = value;
            _contaBcoSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ordem carga.
    /// </summary>
    /// <value>The ordem carga.</value>
    [XmlAttribute("ordemCarga")]
    public string OrdemCarga
    {
        get => _ordemCarga;
        set
        {
            _ordemCarga = value;
            _ordemCargaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk receita.
    /// </summary>
    /// <value>The chk receita.</value>
    [XmlAttribute("chkReceita")]
    public string ChkReceita
    {
        get => _chkReceita;
        set
        {
            _chkReceita = value;
            _chkReceitaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk despesa.
    /// </summary>
    /// <value>The chk despesa.</value>
    [XmlAttribute("chkDespesa")]
    public string ChkDespesa
    {
        get => _chkDespesa;
        set
        {
            _chkDespesa = value;
            _chkDespesaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk baixa separada.
    /// </summary>
    /// <value>The chk baixa separada.</value>
    [XmlAttribute("chkBaixaseparada")]
    public string ChkBaixaSeparada
    {
        get => _chkBaixaSeparada;
        set
        {
            _chkBaixaSeparada = value;
            _chkBaixaSeparadaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk usar hist.
    /// </summary>
    /// <value>The chk usar hist.</value>
    [XmlAttribute("chkusarHist")]
    public string ChkUsarHist
    {
        get => _chkUsarHist;
        set
        {
            _chkUsarHist = value;
            _chkUsarHistSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk nosso number.
    /// </summary>
    /// <value>The chk nosso number.</value>
    [XmlAttribute("chknossoNum")]
    public string ChkNossoNum
    {
        get => _chkNossoNum;
        set
        {
            _chkNossoNum = value;
            _chkNossoNumSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk VLR liq zero.
    /// </summary>
    /// <value>The chk VLR liq zero.</value>
    [XmlAttribute("chkvlrLiqZero")]
    public string ChkVlrLiqZero
    {
        get => _chkVlrLiqZero;
        set
        {
            _chkVlrLiqZero = value;
            _chkVlrLiqZeroSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the rbd concat sobrepor hist fin.
    /// </summary>
    /// <value>The rbd concat sobrepor hist fin.</value>
    [XmlAttribute("rbdConcatSobreporHistFin")]
    public string RbdConcatSobreporHistFin
    {
        get => _rbdConcatSobreporHistFin;
        set
        {
            _rbdConcatSobreporHistFin = value;
            _rbdConcatSobreporHistFinSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the cor despesa.
    /// </summary>
    /// <value>The cor despesa.</value>
    [XmlAttribute("corDespesa")]
    public string CorDespesa
    {
        get => _corDespesa;
        set
        {
            _corDespesa = value;
            _corDespesaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the cor receita.
    /// </summary>
    /// <value>The cor receita.</value>
    [XmlAttribute("corReceita")]
    public string CorReceita
    {
        get => _corReceita;
        set
        {
            _corReceita = value;
            _corReceitaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk usa venc.
    /// </summary>
    /// <value>The chk usa venc.</value>
    [XmlAttribute("chkUsaVenc")]
    public string ChkUsaVenc
    {
        get => _chkUsaVenc;
        set
        {
            _chkUsaVenc = value;
            _chkUsaVencSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the text number document.
    /// </summary>
    /// <value>The text number document.</value>
    [XmlAttribute("txtNumDoc")]
    public string TxtNumDoc
    {
        get => _txtNumDoc;
        set
        {
            _txtNumDoc = value;
            _txtNumDocSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the chk sub inf.
    /// </summary>
    /// <value>The chk sub inf.</value>
    [XmlAttribute("chkSubInf")]
    public string ChkSubInf
    {
        get => _chkSubInf;
        set
        {
            _chkSubInf = value;
            _chkSubInfSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the text historico.
    /// </summary>
    /// <value>The text historico.</value>
    [XmlAttribute("txtHistorico")]
    public string TxtHistorico
    {
        get => _txtHistorico;
        set
        {
            _txtHistorico = value;
            _txtHistoricoSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the tip lanc record.
    /// </summary>
    /// <value>The tip lanc record.</value>
    [XmlAttribute("tiplancRec")]
    public string TipLancRec
    {
        get => _tipLancRec;
        set
        {
            _tipLancRec = value;
            _tipLancRecSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the top baixa rec.
    /// </summary>
    /// <value>The top baixa rec.</value>
    [XmlAttribute("topBaixaRec")]
    public string TopBaixaRec
    {
        get => _topBaixaRec;
        set
        {
            _topBaixaRec = value;
            _topBaixaRecSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the tip lanc desp.
    /// </summary>
    /// <value>The tip lanc desp.</value>
    [XmlAttribute("tiplancDesp")]
    public string TipLancDesp
    {
        get => _tipLancDesp;
        set
        {
            _tipLancDesp = value;
            _tipLancDespSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the top baixa desp.
    /// </summary>
    /// <value>The top baixa desp.</value>
    [XmlAttribute("topBaixaDesp")]
    public string TopBaixaDesp
    {
        get => _topBaixaDesp;
        set
        {
            _topBaixaDesp = value;
            _topBaixaDespSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the tem filtro antecipacao bx.
    /// </summary>
    /// <value>The tem filtro antecipacao bx.</value>
    [XmlAttribute("temFiltroAntecipacaoBx")]
    public string TemFiltroAntecipacaoBx
    {
        get => _temFiltroAntecipacaoBx;
        set
        {
            _temFiltroAntecipacaoBx = value;
            _temFiltroAntecipacaoBxSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the nu antecipa.
    /// </summary>
    /// <value>The nu antecipa.</value>
    [XmlAttribute("nuAntecipa")]
    public string NuAntecipa
    {
        get => _nuAntecipa;
        set
        {
            _nuAntecipa = value;
            _nuAntecipaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the parc antecipa.
    /// </summary>
    /// <value>The parc antecipa.</value>
    [XmlAttribute("parcAntecipa")]
    public string ParcAntecipa
    {
        get => _parcAntecipa;
        set
        {
            _parcAntecipa = value;
            _parcAntecipaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx top.
    /// </summary>
    /// <value>The ant bx top.</value>
    [XmlAttribute("antBxTop")]
    public string AntBxTop
    {
        get => _antBxTop;
        set
        {
            _antBxTop = value;
            _antBxTopSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx tip tit.
    /// </summary>
    /// <value>The ant bx tip tit.</value>
    [XmlAttribute("antBxTipTit")]
    public string AntBxTipTit
    {
        get => _antBxTipTit;
        set
        {
            _antBxTipTit = value;
            _antBxTipTitSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx natureza.
    /// </summary>
    /// <value>The ant bx natureza.</value>
    [XmlAttribute("antBxNatureza")]
    public string AntBxNatureza
    {
        get => _antBxNatureza;
        set
        {
            _antBxNatureza = value;
            _antBxNaturezaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx cen cus.
    /// </summary>
    /// <value>The ant bx cen cus.</value>
    [XmlAttribute("antBxCenCus")]
    public string AntBxCenCus
    {
        get => _antBxCenCus;
        set
        {
            _antBxCenCus = value;
            _antBxCenCusSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx conta baixa.
    /// </summary>
    /// <value>The ant bx conta baixa.</value>
    [XmlAttribute("antBxContaBaixa")]
    public string AntBxContaBaixa
    {
        get => _antBxContaBaixa;
        set
        {
            _antBxContaBaixa = value;
            _antBxContaBaixaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx top baixa.
    /// </summary>
    /// <value>The ant bx top baixa.</value>
    [XmlAttribute("antBxTopBaixa")]
    public string AntBxTopBaixa
    {
        get => _antBxTopBaixa;
        set
        {
            _antBxTopBaixa = value;
            _antBxTopBaixaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx lanc baixa.
    /// </summary>
    /// <value>The ant bx lanc baixa.</value>
    [XmlAttribute("antBxLancBaixa")]
    public string AntBxLancBaixa
    {
        get => _antBxLancBaixa;
        set
        {
            _antBxLancBaixa = value;
            _antBxLancBaixaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx hist baixa.
    /// </summary>
    /// <value>The ant bx hist baixa.</value>
    [XmlAttribute("antBxHistBaixa")]
    public string AntBxHistBaixa
    {
        get => _antBxHistBaixa;
        set
        {
            _antBxHistBaixa = value;
            _antBxHistBaixaSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the ant bx impressora.
    /// </summary>
    /// <value>The ant bx impressora.</value>
    [XmlAttribute("antBxImpressora")]
    public string AntBxImpressora
    {
        get => _antBxImpressora;
        set
        {
            _antBxImpressora = value;
            _antBxImpressoraSet = true;
        }
    }

    /// <summary>
    /// Gets or sets the parameter imprime boleto.
    /// </summary>
    /// <value>The parameter imprime boleto.</value>
    [XmlAttribute("paramImprimeBoleto")]
    public string ParamImprimeBoleto
    {
        get => _paramImprimeBoleto;
        set
        {
            _paramImprimeBoleto = value;
            _paramImprimeBoletoSet = true;
        }
    }

    /// <summary>
    /// Should the serialize financial numbers list.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumbersList() => _financialNumbersListSet;

    /// <summary>
    /// Should the serialize dt baixa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDtBaixa() => _dtBaixaSet;

    /// <summary>
    /// Should the serialize empresa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmpresa() => _empresaSet;

    /// <summary>
    /// Should the serialize conta bco.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeContaBco() => _contaBcoSet;

    /// <summary>
    /// Should the serialize ordem carga.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOrdemCarga() => _ordemCargaSet;

    /// <summary>
    /// Should the serialize chk receita.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkReceita() => _chkReceitaSet;

    /// <summary>
    /// Should the serialize chk despesa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkDespesa() => _chkDespesaSet;

    /// <summary>
    /// Should the serialize chk baixa separada.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkBaixaSeparada() => _chkBaixaSeparadaSet;

    /// <summary>
    /// Should the serialize chk usar hist.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkUsarHist() => _chkUsarHistSet;

    /// <summary>
    /// Should the serialize chk nosso num.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkNossoNum() => _chkNossoNumSet;

    /// <summary>
    /// Should the serialize chk vlr liq zero.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkVlrLiqZero() => _chkVlrLiqZeroSet;

    /// <summary>
    /// Should the serialize rbd concat sobrepor hist fin.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRbdConcatSobreporHistFin() => _rbdConcatSobreporHistFinSet;

    /// <summary>
    /// Should the serialize cor despesa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCorDespesa() => _corDespesaSet;

    /// <summary>
    /// Should the serialize cor receita.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCorReceita() => _corReceitaSet;

    /// <summary>
    /// Should the serialize chk usa venc.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkUsaVenc() => _chkUsaVencSet;

    /// <summary>
    /// Should the serialize text number document.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTxtNumDoc() => _txtNumDocSet;

    /// <summary>
    /// Should the serialize chk sub inf.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkSubInf() => _chkSubInfSet;

    /// <summary>
    /// Should the serialize text historico.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTxtHistorico() => _txtHistoricoSet;

    /// <summary>
    /// Should the serialize tip lanc rec.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTipLancRec() => _tipLancRecSet;

    /// <summary>
    /// Should the serialize top baixa rec.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTopBaixaRec() => _topBaixaRecSet;

    /// <summary>
    /// Should the serialize tip lanc desp.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTipLancDesp() => _tipLancDespSet;

    /// <summary>
    /// Should the serialize top baixa desp.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTopBaixaDesp() => _topBaixaDespSet;

    /// <summary>
    /// Should the serialize tem filtro antecipacao bx.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTemFiltroAntecipacaoBx() => _temFiltroAntecipacaoBxSet;

    /// <summary>
    /// Should the serialize nu antecipa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNuAntecipa() => _nuAntecipaSet;

    /// <summary>
    /// Should the serialize parc antecipa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParcAntecipa() => _parcAntecipaSet;

    /// <summary>
    /// Should the serialize ant bx top.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTop() => _antBxTopSet;

    /// <summary>
    /// Should the serialize ant bx tip
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTipTit() => _antBxTipTitSet;

    /// <summary>
    /// Should the serialize ant bx natureza.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxNatureza() => _antBxNaturezaSet;

    /// <summary>
    /// Should the serialize ant bx cen cus.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxCenCus() => _antBxCenCusSet;

    /// <summary>
    /// Should the serialize ant bx conta baixa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxContaBaixa() => _antBxContaBaixaSet;

    /// <summary>
    /// Should the serialize ant bx top baixa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTopBaixa() => _antBxTopBaixaSet;

    /// <summary>
    /// Should the serialize ant bx lanc baixa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxLancBaixa() => _antBxLancBaixaSet;

    /// <summary>
    /// Should the serialize ant bx hist baixa.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxHistBaixa() => _antBxHistBaixaSet;

    /// <summary>
    /// Should the serialize ant bx impressora.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxImpressora() => _antBxImpressoraSet;

    /// <summary>
    /// Should the serialize param imprime boleto.
    /// </summary>
    /// <returns>Boolean.</returns>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParamImprimeBoleto() => _paramImprimeBoletoSet;
}
