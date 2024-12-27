using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Sankhya.Service;

[Serializable]
[XmlRoot("dadosBaixa")]
public sealed class LowData
{
    private string _financialNumbersList;

    private bool _financialNumbersListSet;

    private string _dtBaixa;

    private bool _dtBaixaSet;

    private string _empresa;

    private bool _empresaSet;

    private string _contaBco;

    private bool _contaBcoSet;

    private string _ordemCarga;

    private bool _ordemCargaSet;

    private string _chkReceita;

    private bool _chkReceitaSet;

    private string _chkDespesa;

    private bool _chkDespesaSet;

    private string _chkBaixaSeparada;

    private bool _chkBaixaSeparadaSet;

    private string _chkUsarHist;

    private bool _chkUsarHistSet;

    private string _chkNossoNum;

    private bool _chkNossoNumSet;

    private string _chkVlrLiqZero;

    private bool _chkVlrLiqZeroSet;

    private string _rbdConcatSobreporHistFin;

    private bool _rbdConcatSobreporHistFinSet;

    private string _corDespesa;

    private bool _corDespesaSet;

    private string _corReceita;

    private bool _corReceitaSet;

    private string _chkUsaVenc;

    private bool _chkUsaVencSet;

    private string _txtNumDoc;

    private bool _txtNumDocSet;

    private string _chkSubInf;

    private bool _chkSubInfSet;

    private string _txtHistorico;

    private bool _txtHistoricoSet;

    private string _tipLancRec;

    private bool _tipLancRecSet;

    private string _topBaixaRec;

    private bool _topBaixaRecSet;

    private string _tipLancDesp;

    private bool _tipLancDespSet;

    private string _topBaixaDesp;

    private bool _topBaixaDespSet;

    private string _temFiltroAntecipacaoBx;

    private bool _temFiltroAntecipacaoBxSet;

    private string _nuAntecipa;

    private bool _nuAntecipaSet;

    private string _parcAntecipa;

    private bool _parcAntecipaSet;

    private string _antBxTop;

    private bool _antBxTopSet;

    private string _antBxTipTit;

    private bool _antBxTipTitSet;

    private string _antBxNatureza;

    private bool _antBxNaturezaSet;

    private string _antBxCenCus;

    private bool _antBxCenCusSet;

    private string _antBxContaBaixa;

    private bool _antBxContaBaixaSet;

    private string _antBxTopBaixa;

    private bool _antBxTopBaixaSet;

    private string _antBxLancBaixa;

    private bool _antBxLancBaixaSet;

    private string _antBxHistBaixa;

    private bool _antBxHistBaixaSet;

    private string _antBxImpressora;

    private bool _antBxImpressoraSet;

    private string _paramImprimeBoleto;

    private bool _paramImprimeBoletoSet;

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

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeFinancialNumbersList() => _financialNumbersListSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeDtBaixa() => _dtBaixaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeEmpresa() => _empresaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeContaBco() => _contaBcoSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeOrdemCarga() => _ordemCargaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkReceita() => _chkReceitaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkDespesa() => _chkDespesaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkBaixaSeparada() => _chkBaixaSeparadaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkUsarHist() => _chkUsarHistSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkNossoNum() => _chkNossoNumSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkVlrLiqZero() => _chkVlrLiqZeroSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeRbdConcatSobreporHistFin() => _rbdConcatSobreporHistFinSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCorDespesa() => _corDespesaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCorReceita() => _corReceitaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkUsaVenc() => _chkUsaVencSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTxtNumDoc() => _txtNumDocSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeChkSubInf() => _chkSubInfSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTxtHistorico() => _txtHistoricoSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTipLancRec() => _tipLancRecSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTopBaixaRec() => _topBaixaRecSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTipLancDesp() => _tipLancDespSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTopBaixaDesp() => _topBaixaDespSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeTemFiltroAntecipacaoBx() => _temFiltroAntecipacaoBxSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeNuAntecipa() => _nuAntecipaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParcAntecipa() => _parcAntecipaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTop() => _antBxTopSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTipTit() => _antBxTipTitSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxNatureza() => _antBxNaturezaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxCenCus() => _antBxCenCusSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxContaBaixa() => _antBxContaBaixaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxTopBaixa() => _antBxTopBaixaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxLancBaixa() => _antBxLancBaixaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxHistBaixa() => _antBxHistBaixaSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeAntBxImpressora() => _antBxImpressoraSet;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeParamImprimeBoleto() => _paramImprimeBoletoSet;
}
