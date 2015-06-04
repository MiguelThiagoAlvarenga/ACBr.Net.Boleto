// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="BancoDoBrasil.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Utils;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes

namespace ACBr.Net.Boleto.Bancos
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("618EBC46-7D78-4F60-823F-8C2E88DBB2A8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoDoBrasil. Esta classe n�o pode ser herdada.
    /// </summary>
    public sealed class BancoDoBrasil : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
        /// </summary>
        /// <param name="parent">Classe Banco.</param>
        internal BancoDoBrasil(Banco parent):base(parent)
        {
            TipoCobranca = TipoCobranca.BancoDoBrasil;
            Digito = 9;
            Nome = "BANCO DO BRASIL S.A.";
            Numero = 1;
            TamanhoMaximoNossoNum = 0;
            TamanhoConta = 12;
            TamanhoAgencia = 4;
            TamanhoCarteira = 2;
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Informa a descri��o do tipo de ocorrencia informado.
        /// </summary>
        /// <param name="tipo">Tipo de ocorrencia</param>
        /// <returns>Descri��o da ocorrencia</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            var codOcorrencia = TipoOCorrenciaToCod(tipo).ToInt32();
            switch (codOcorrencia)
            {
                case 2: return "02-Confirma��o de Entrada de T�tulo";
                case 3: return "03-Comando recusado";
                case 5: return "05-Liquidado sem registro";
                case 6: return "06-Liquida��o Normal";
                case 7: return "07-Liquida��o por Conta";
                case 8: return "08-Liquida��o por Saldo";
                case 9: return "09-Baixa de T�tulo";
                case 10: return "10-Baixa Solicitada";
                case 11: return "11-Titulos em Ser";
                case 12: return "12-Abatimento Concedido";
                case 13: return "13-Abatimento Cancelado";
                case 14: return "14-Altera��o de Vencimento do Titulo";
                case 15: return "15-Liquida��o em Cart�rio";
                case 16: return "16-Confirma��o de altera��o de juros de mora";
                case 19: return "19-Confirma��o de recebimento de instru��es para protesto";
                case 20: return "20-D�bito em Conta";
                case 21: return "21-Altera��o do Nome do Sacado";
                case 22: return "22-Altera��o do Endere�o do Sacado";
                case 23: return "23-Indica��o de encaminhamento a cart�rio";
                case 24: return "24-Sustar Protesto";
                case 25: return "25-Dispensar Juros";
                case 26: return "26-Altera��o do n�mero do t�tulo dado pelo Cedente (Seu n�mero) - 10 e 15 posi��es";
                case 28: return "28-Manuten��o de titulo vencido";
                case 31: return "31-Conceder desconto";
                case 32: return "32-N�o conceder desconto";
                case 33: return "33-Retificar desconto";
                case 34: return "34-Alterar data para desconto";
                case 35: return "35-Cobrar multa";
                case 36: return "36-Dispensar multa";
                case 37: return "37-Dispensar indexador";
                case 38: return "38-Dispensar prazo limite para recebimento";
                case 39: return "39-Alterar prazo limite para recebimento";
                case 41: return "41-Altera��o do n�mero do controle do participante (25 posi��es)";
                case 42: return "42-Altera��o do n�mero do documento do sacado (CNPJ/CPF)";
                case 44: return "44-T�tulo pago com cheque devolvido";
                case 46: return "46-T�tulo pago com cheque, aguardando compensa��o";
                case 72: return "72-Altera��o de tipo de cobran�a";
                case 96: return "96-Despesas de Protesto";
                case 97: return "97-Despesas de Susta��o de Protesto";
                case 98: return "98-D�bito de Custas Antecipadas";                
                default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
            }
        }

        /// <summary>
        /// Transforma um codigo de ocorrencia em um Tipo de ocorrencia.
        /// </summary>
        /// <param name="codOcorrencia">Codigo da ocorrencia.</param>
        /// <returns>Retorna um TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia)
        {
            switch (codOcorrencia)
            {
                case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                case 6: return TipoOcorrencia.RetornoLiquidado;
                case 9: return TipoOcorrencia.RetornoBaixado;
                case 10: return TipoOcorrencia.RetornoBaixadoInstAgencia;
                case 11: return TipoOcorrencia.RetornoTituloEmSer;
                case 12: return TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento;
                case 13: return TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento;
                case 14: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento;
                case 15: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                case 17: return TipoOcorrencia.RetornoLiquidadoSemRegistro;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 22: return TipoOcorrencia.RetornoEnderecoSacadoAlterado;
                case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                case 24: return TipoOcorrencia.RetornoRetiradoDeCartorio;
                case 25: return TipoOcorrencia.RetornoProtestado;
                case 26: return TipoOcorrencia.RetornoInstrucaoRejeitada;
                case 27: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
                case 28: return TipoOcorrencia.RetornoDebitoTarifas;
                case 29: return TipoOcorrencia.RetornoOcorrenciasDoSacado;
                case 30: return TipoOcorrencia.RetornoAlteracaoDadosRejeitados;
                case 36: return TipoOcorrencia.RetornoRecebimentoInstrucaoConcederDesconto;
                case 37: return TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarDesconto;
                case 43: return TipoOcorrencia.RetornoProtestoOuSustacaoEstornado;
                case 44: return TipoOcorrencia.RetornoBaixaOuLiquidacaoEstornada;
                case 45: return TipoOcorrencia.RetornoDadosAlterados;
                default: return TipoOcorrencia.RetornoOutrasOcorrencias;
            }
        }

        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia tipo)
        {
            switch (tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                case TipoOcorrencia.RetornoComandoRecusado: return "03";
                case TipoOcorrencia.RetornoLiquidado: return "06";
                case TipoOcorrencia.RetornoBaixado: return "09";
                case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
                case TipoOcorrencia.RetornoTituloEmSer: return "11";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederAbatimento: return "12";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarAbatimento: return "13";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarVencimento: return "14";
                case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
                case TipoOcorrencia.RetornoLiquidadoSemRegistro: return "17";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                case TipoOcorrencia.RetornoAcertoControleParticipante: return "21";
                case TipoOcorrencia.RetornoEnderecoSacadoAlterado: return "22";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoRetiradoDeCartorio: return "24";
                case TipoOcorrencia.RetornoProtestado: return "25";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "27";
                case TipoOcorrencia.RetornoDebitoTarifas: return "28";
                case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "30";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoConcederDesconto: return "36";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoCancelarDesconto: return "37";
                case TipoOcorrencia.RetornoProtestoOuSustacaoEstornado: return "43";
                case TipoOcorrencia.RetornoBaixaOuLiquidacaoEstornada: return "44";
                case TipoOcorrencia.RetornoDadosAlterados: return "45";
                default: return "02";
            }
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <param name="codMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia tipo, int codMotivo)
        {
            switch (tipo)
            {
                case TipoOcorrencia.RetornoComandoRecusado:
                    switch (codMotivo)
                    {
                        case 1: return "01-Identifica��o inv�lida";
                        case 2: return "02-Varia��o da carteira inv�lida";
                        case 3: return "03-Valor dos juros por um dia inv�lido";
                        case 4: return "04-Valor do desconto inv�lido";
                        case 5: return "05-Esp�cie de t�tulo inv�lida para carteira";
                        case 6: return "06-Esp�cie de valor vari�vel inv�lido";
                        case 7: return "07-Prefixo da ag�ncia usu�ria inv�lido";
                        case 8: return "08-Valor do t�tulo/ap�lice inv�lido";
                        case 9: return "09-Data de vencimento inv�lida";
                        case 10: return "10-Fora do prazo";
                        case 11: return "11-Inexist�ncia de margem para desconto";
                        case 12: return "12-O Banco n�o tem ag�ncia na pra�a do sacado";
                        case 13: return "13-Raz�es cadastrais";
                        case 14: return "14-Sacado interligado com o sacador";
                        case 15: return "15-T�tulo sacado contra org�o do Poder P�blico";
                        case 16: return "16-T�tulo preenchido de forma irregular";
                        case 17: return "17-T�tulo rasurado";
                        case 18: return "18-Endere�o do sacado n�o localizado ou incompleto";
                        case 19: return "19-C�digo do cedente inv�lido";
                        case 20: return "20-Nome/endereco do cliente n�o informado /ECT/";
                        case 21: return "21-Carteira inv�lida";
                        case 22: return "22Quantidade de valor vari�vel inv�lida";
                        case 23: return "23-Faixa nosso n�mero excedida";
                        case 24: return "24-Valor do abatimento inv�lido";
                        case 25: return "25-Novo n�mero do t�tulo dado pelo cedente inv�lido";
                        case 26: return "26-Valor do IOF de seguro inv�lido";
                        case 27: return "27-Nome do sacado/cedente inv�lido ou n�o informado";
                        case 28: return "28-Data do novo vencimento inv�lida";
                        case 29: return "29-Endereco n�o informado";
                        case 30: return "30-Registro de t�tulo j� liquidado";
                        case 31: return "31-Numero do bordero inv�lido";
                        case 32: return "32-Nome da pessoa autorizada inv�lido";
                        case 33: return "33-Nosso n�mero j� existente";
                        case 34: return "34-Numero da presta��o do contrato inv�lido";
                        case 35: return "35-Percentual de desconto inv�lido";
                        case 36: return "36-Dias para fichamento de protesto inv�lido";
                        case 37: return "37-Data de emiss�o do t�tulo inv�lida";
                        case 38: return "38-Data do vencimento anterior a data da emiss�o do t�tulo";
                        case 39: return "39-Comando de altera��o indevido para a carteira";
                        case 40: return "40-Tipo de moeda inv�lido";
                        case 41: return "41-Abatimento n�o permitido";
                        case 42: return "42-CEP do sacado inv�lido /ECT/";
                        case 43: return "43-Codigo de unidade variavel incompativel com a data emiss�o do t�tulo";
                        case 44: return "44-Dados para debito ao sacado inv�lidos";
                        case 45: return "45-Carteira";
                        case 46: return "46-Convenio encerrado";
                        case 47: return "47-T�tulo tem valor diverso do informado";
                        case 48: return "48-Motivo de baixa inv�lido para a carteira";
                        case 49: return "49-Abatimento a cancelar n�o consta do t�tulo";
                        case 50: return "50-Comando incompativel com a carteira";
                        case 51: return "51-Codigo do convenente inv�lido";
                        case 52: return "52-Abatimento igual ou maior que o valor do t�tulo";
                        case 53: return "53-T�tulo j� se encontra situa��o pretendida";
                        case 54: return "54-T�tulo fora do prazo admitido para a conta 1";
                        case 55: return "55-Novo vencimento fora dos limites da carteira";
                        case 56: return "56-T�tulo n�o pertence ao convenente";
                        case 57: return "57-Varia��o incompativel com a carteira";
                        case 58: return "58-Impossivel a transferencia para a carteira indicada";
                        case 59: return "59-T�tulo vencido em transferencia para a carteira 51";
                        case 60: return "60-T�tulo com prazo superior a 179 dias em transferencia para carteira 51";
                        case 61: return "61-T�tulo j� foi fichado para protesto";
                        case 62: return "62-Altera��o da situa��o de debito inv�lida para o codigo de responsabilidade";
                        case 63: return "63-DV do nosso n�mero inv�lido";
                        case 64: return "64-T�tulo n�o passivel de debito/baixa - situa��o anormal";
                        case 65: return "65-T�tulo com ordem de n�o protestar-n�o pode ser encaminhado a cartorio";
                        case 67: return "66-T�tulo/carne rejeitado";
                        case 80: return "80-Nosso n�mero inv�lido";
                        case 81: return "81-Data para concess�o do desconto inv�lida";
                        case 82: return "82-CEP do sacado inv�lido";
                        case 83: return "83-Carteira/varia��o n�o localizada no cedente";
                        case 84: return "84-T�tulo n�o localizado na existencia";
                        case 99: return "99-Outros motivos";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }
                    
                case TipoOcorrencia.RetornoLiquidadoSemRegistro:  //05-Liquidado sem registro (carteira 17-tipo4)
                case TipoOcorrencia.RetornoLiquidado:             //06-Liquida��o Normal
                case TipoOcorrencia.RetornoLiquidadoPorConta:     //07-Liquida��o por Conta
                case TipoOcorrencia.RetornoLiquidadoEmCartorio:   //15-Liquida��o em Cart�rio
                case TipoOcorrencia.RetornoTituloPagoEmCheque:    //46�T�tulo pago com cheque, aguardando compensa��o
                    switch (codMotivo)
                    {
                        case 1: return "01-Liquida��o normal";
                        case 2: return "02-Liquida��o parcial";
                        case 3: return "03-Liquida��o por saldo";
                        case 4: return "04-Liquida��o com cheque a compensar";
                        case 5: return "05-Liquida��o de t�tulo sem registro (carteira 7 tipo 4)";
                        case 7: return "07-Liquida��o na apresenta��o";
                        case 9: return "09-Liquida��o em cart�rio";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (codMotivo)
                    {
                        case 0: return "00-Por meio magn�tico";
                        case 11: return "11-Por via convencional";
                        case 16: return "16-Por altera��o do c�digo do cedente";
                        case 17: return "17-Por altera��o da varia��o";
                        case 18: return "18-Por altera��o de carteira";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoBaixado:
                case TipoOcorrencia.RetornoBaixadoInstAgencia:
                    switch (codMotivo)
                    {
                        case 0: return "00-Solicitada pelo cliente";
                        case 15: return "15-Protestado";
                        case 18: return "18-Por altera��o de carteira";
                        case 19: return "19-D�bito autom�tico";
                        case 31: return "31-Liquidado anteriormente";
                        case 32: return "32-Habilitado em processo";
                        case 33: return "33-Incobr�vel por nosso interm�dio";
                        case 34: return "34-Transferido para cr�ditos em liquida��o";
                        case 46: return "46-Por altera��o da varia��o";
                        case 47: return "47-Por altera��o da varia��o";
                        case 51: return "51-Acerto";
                        case 90: return "90-Baixa autom�tica";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                default: return string.Format("{0:00} - Outros Motivos", codMotivo);
            }
        }

        /// <summary>
        /// Formata o campo nosso numero a partir do boleto informado
        /// </summary>
        /// <param name="titulo">boleto.</param>
        /// <returns>Nosso Numero.</returns>
        private string FormataNossoNumero(Titulo titulo)
        {
            var aConvenio = titulo.Parent.Cedente.Convenio;
            var aNossoNumero = titulo.NossoNumero.OnlyNumbers();
            var wNossoNumero = titulo.NossoNumero.OnlyNumbers();
            var wTamNossoNum = CalcularTamMaximoNossoNumero(titulo.Carteira, wNossoNumero);

            if ((titulo.Carteira == "16" || titulo.Carteira == "18") && aConvenio.Length == 6 && wTamNossoNum == 17)
                aNossoNumero = aNossoNumero.FillRight(17, '0');
            else if (titulo.Carteira == "18" && aConvenio.Length == 7 && wTamNossoNum == 11)
                aNossoNumero = aNossoNumero.FillRight(11, '0');
            else if (aConvenio.Length <= 4)
                aNossoNumero = aConvenio.FillRight(4, '0') + aNossoNumero.FillRight(7, '0');
            else if (aConvenio.Length > 4 && aConvenio.Length <= 6)
                aNossoNumero = aConvenio.FillRight(6, '0') + aNossoNumero.FillRight(5, '0');
            else if (aConvenio.Length == 7 && titulo.Carteira == "11")
                aNossoNumero = "0".FillRight(7, '0') + aNossoNumero.FillRight(10, '0');
            else if (aConvenio.Length == 7 && titulo.Carteira != "11")
                aNossoNumero = aConvenio.FillRight(7, '0') + aNossoNumero.FillRight(10, '0');

            return aNossoNumero;
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
			Modulo.CalculoPadrao();
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorInicial = 9;
            Modulo.Documento = FormataNossoNumero(titulo);
            Modulo.Calcular();

            return Modulo.ModuloFinal >= 10 ? "X" : Modulo.ModuloFinal.ToString();
		}

        /// <summary>
        /// Calculars the tam maximo nosso numero.
        /// </summary>
        /// <param name="carteira">The carteira.</param>
        /// <param name="nossoNumero">The nosso numero.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="Exception">Banco do Brasil requer que o Conv�nio do Cedente seja informado.
        /// or
        /// Banco do Brasil requer que a carteira seja informada antes do Nosso N�mero.</exception>
        public override int CalcularTamMaximoNossoNumero(string carteira, string nossoNumero = "")
        {
            var ret = 10;

            Guard.Against<ACBrException>(Banco.Parent.Cedente.Convenio.IsEmpty(),
				"Banco do Brasil requer que o Conv�nio do Cedente seja informado.");

            Guard.Against<ACBrException>(carteira.IsEmpty(),
				"Banco do Brasil requer que a carteira seja informada antes do Nosso N�mero.");

            var wCarteira = carteira.Trim();
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Trim().Length;

            if (wTamConvenio == 6 && (wCarteira == "16" || wCarteira == "18"))
                ret = 17;
            else if (wTamConvenio <= 4)
                ret = 7;
            else if (wTamConvenio > 4 && wTamConvenio <= 6)
                ret = 5;
            else if (wTamConvenio == 7)
                ret = 10;

            return ret;
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo titulo)
        {
            return string.Format("{0}-{1}/{2}-{3}", titulo.Parent.Cedente.Agencia,
                titulo.Parent.Cedente.AgenciaDigito, titulo.Parent.Cedente.Conta,
                titulo.Parent.Cedente.ContaDigito);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo titulo)
        {
            var aNossoNumero = FormataNossoNumero(titulo);
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Trim().Length;
            var wTamNossoNum = CalcularTamMaximoNossoNumero(titulo.Carteira, titulo.NossoNumero.OnlyNumbers());

            if (wTamConvenio == 7 || (wTamConvenio == 6 && wTamNossoNum == 17))
                return aNossoNumero;
	        return string.Format("{0}-{1}", aNossoNumero, CalcularDigitoVerificador(titulo));
        }

        /// <summary>
        /// Montars the codigo barras.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo titulo)
        {
            var aConvenio = titulo.Parent.Cedente.Convenio.Trim();
            var aNossoNumero = FormataNossoNumero(titulo);
            var wTamNossNum = CalcularTamMaximoNossoNumero(titulo.Carteira, titulo.NossoNumero.OnlyNumbers());
            var codigoBarras = string.Empty;

            //Codigo de Barras
            var fatorVencimento = titulo.Vencimento.CalcularFatorVencimento();
            if ((titulo.Carteira == "18" || titulo.Carteira == "16") && aConvenio.Length == 6 && wTamNossNum == 17)
            {
                codigoBarras = string.Format("{0:000}9{1}{2}{3}{4}21", Banco.Numero, fatorVencimento, titulo.ValorDocumento.ToDecimalString(10),
                    aConvenio, aNossoNumero);
            }
            else
            {
                codigoBarras = string.Format("{0:000}9{1}{2}{3}{4}{5}{6}{7}", Banco.Numero, fatorVencimento, titulo.ValorDocumento.ToDecimalString(10),
                    aConvenio.Length == 7 ? "000000" : "", aNossoNumero, aConvenio.Length < 7 ? titulo.Parent.Cedente.Agencia.FillRight(4, '0') : "",
                    aConvenio.Length < 7 ? titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8) : "", titulo.Carteira);
            }

            var digitoCodBarras = CalcularDigitoCodigoBarras(codigoBarras);                        
            return codigoBarras.Insert(4, digitoCodBarras);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
             
            var tamConvenioMaior6 = Banco.Parent.Cedente.Convenio.Trim().Length > 6;
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta  = Banco.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8);

            var wLinha = new StringBuilder();
            wLinha.Append('0');                                             // ID do Registro
            wLinha.Append('1');                                             // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                       // Literal de Remessa
            wLinha.Append("01");                                            // C�digo do Tipo de Servi�o
            wLinha.Append("COBRANCA".FillLeft(15));                          // Descri��o do tipo de servi�o
            wLinha.Append(aAgencia);                                        // Prefixo da ag�ncia/ onde esta cadastrado o convenente lider do cedente
            wLinha.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1));   // DV-prefixo da agencia
            wLinha.Append(aConta);                                          // Codigo do cedente/nr. da conta corrente que est� cadastro o convenio lider do cedente
            wLinha.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1));     // DV-c�digo do cedente

            
            if(tamConvenioMaior6)
              wLinha.Append("000000");                                         // Complemento
            else
                wLinha.Append(Banco.Parent.Cedente.Convenio.FillRight(6,'0'));  //Convenio;
            
            wLinha.Append(Banco.Parent.Cedente.Nome.FillLeft(30));    // Nome da Empresa
            wLinha.AppendFormat("{0:000}", Numero);                             // C�digo do Banco
            wLinha.Append("BANCO DO BRASIL".FillLeft(15));                       // Nome do Banco(BANCO DO BRASIL)
            wLinha.AppendFormat("{0:ddMMyy}", DateTime.Now);                    // Data de gera��o do arquivo
            wLinha.AppendFormat("{0:0000000}", numeroRemessa);                  // Numero Remessa
            
            if(tamConvenioMaior6)
            {
                wLinha.Append("".FillRight(22));                                        // Nr. Sequencial de Remessa + brancos
                wLinha.Append(Banco.Parent.Cedente.Convenio.Trim().FillRight(7,'0'));  //Nr. Convenio
                wLinha.Append("".FillRight(258));                                      //Brancos
            }
            else
            {
               wLinha.Append("".FillRight(287));
            }
            
            wLinha.AppendFormat("{0:000000}", 1);                               // Nr. Sequencial do registro-informar 000001

            aRemessa.Add(wLinha.ToString().ToUpper());

        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
        {
            var wCarteira = titulo.Carteira.ToInt32();
            string aNossoNumero;
            string aDigitoNossoNumero;
            if ((wCarteira == 11 || wCarteira == 31 || wCarteira == 51) ||
                ((wCarteira == 12 || wCarteira == 15 || wCarteira == 17) &&
                titulo.Parent.Cedente.ResponEmissao != ResponEmissao.CliEmite))
            {
               aNossoNumero = "00000000000000000000";
               aDigitoNossoNumero = string.Empty;
            }
            else
            {
               aNossoNumero = FormataNossoNumero(titulo);
               aDigitoNossoNumero = CalcularDigitoVerificador(titulo);
            }
            
            var tamConvenioMaior6 = titulo.Parent.Cedente.Convenio.Trim().Length > 6;
            var aAgencia = titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta = titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(8);
            var aModalidade = titulo.Parent.Cedente.Modalidade.Trim().ZeroFill(3);
            
            //Pegando C�digo da Ocorrencia}
            string aTipoOcorrencia;
            switch(titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar:
                    aTipoOcorrencia = "02"; //Pedido de Baixa
                    break;
                    
                case TipoOcorrencia.RemessaConcederAbatimento:
                    aTipoOcorrencia = "04"; //Concess�o de Abatimento
                    break;
                
                case TipoOcorrencia.RemessaCancelarAbatimento:
                    aTipoOcorrencia = "05"; //Cancelamento de Abatimento concedido}
                    break;
                    
                case TipoOcorrencia.RemessaAlterarVencimento: 
                    aTipoOcorrencia = "06"; //Altera��o de vencimento
                    break;
                
                case TipoOcorrencia.RemessaAlterarControleParticipante: 
                    aTipoOcorrencia = "07"; //Altera��o do n�mero de controle do participante
                    break;
                
                case TipoOcorrencia.RemessaAlterarNumeroControle:
                    aTipoOcorrencia = "08"; //Altera��o de seu n�mero
                    break;
                    
                case TipoOcorrencia.RemessaProtestar: 
                    aTipoOcorrencia = "09"; //Pedido de protesto
                    break;
                
                case TipoOcorrencia.RemessaCancelarInstrucaoProtestoBaixa: 
                    aTipoOcorrencia = "10"; //Sustar protesto e baixar
                    break;
                    
                case TipoOcorrencia.RemessaCancelarInstrucaoProtesto: 
                    aTipoOcorrencia = "10"; //Sustar protesto e manter na carteira
                    break;
                
                case TipoOcorrencia.RemessaDispensarJuros:
                    aTipoOcorrencia = "11"; //Instru��o para dispensar juros
                    break;
                    
                case TipoOcorrencia.RemessaAlterarNomeEnderecoSacado:
                    aTipoOcorrencia = "12"; //Altera��o de nome e endere�o do Sacado
                    break;

                case TipoOcorrencia.RemessaConcederDesconto:
                    aTipoOcorrencia = "31"; //Conceder desconto
                    break;
                    
                case TipoOcorrencia.RemessaCancelarDesconto:
                    aTipoOcorrencia = "32"; //N�o conceder desconto
                    break;
                    
                case TipoOcorrencia.RemessaAlterarModalidade:
                    aTipoOcorrencia = "40";
                    break;

                default:
                    aTipoOcorrencia = "01"; //Remessa
                    break;
            }
            
            //Pegando o Aceite do Titulo
            string aTipoAceite;
            switch (titulo.Aceite)
            {
                case AceiteTitulo.Sim:
                    aTipoAceite = "A";
                    break;

                default:
                    aTipoAceite = "N";
                    break;
            }

            //Pegando o tipo de EspecieDoc
            var aTipoEspecieDoc = string.Empty;            
            if (titulo.EspecieDoc == "DM")
                aTipoEspecieDoc = "01";
            else if (titulo.EspecieDoc == "RC")
                aTipoEspecieDoc = "05";
            else if (titulo.EspecieDoc == "NP")
                aTipoEspecieDoc = "02";
            else if (titulo.EspecieDoc == "NS")
                aTipoEspecieDoc = "03";
            else if (titulo.EspecieDoc == "ND")
                aTipoEspecieDoc = "13";
            else if (titulo.EspecieDoc == "DS")
                aTipoEspecieDoc = "12";
            else if (titulo.EspecieDoc == "LC")
                aTipoEspecieDoc = "08";
            
            //Pegando Tipo de Cobran�a
            string aTipoCobranca;
            switch(titulo.Carteira.ToInt32())
            {
                case 11:
                case 17:
                switch(titulo.Parent.Cedente.CaracTitulo)
                {
                    case CaracTitulo.Simples:
                        aTipoCobranca ="     ";
                        break;
                        
                    case CaracTitulo.Descontada:
                        aTipoCobranca = "04DSC";
                        break;
                    
                    case CaracTitulo.Vendor:
                        aTipoCobranca = "08VDR";
                        break;
                    
                    case CaracTitulo.Vinculada: 
                        aTipoCobranca = "02VIN";
                        break;
                    
                    default:
                        aTipoCobranca ="     ";
                        break;
                }
                break;
                
                default:
                    aTipoCobranca ="     ";
                    break;
            }
            
            var aInstrucao = string.Empty;
            var diasProtesto = "  ";
            if (titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento)
            {
                switch((int)(titulo.DataProtesto.Value - titulo.Vencimento).TotalDays)
                {
                    case 3: // Protestar no 3� dia util ap�s vencimento
                        if (string.IsNullOrEmpty(titulo.Instrucao1.Trim()) ||
                            titulo.Instrucao1 == "03")
                            aInstrucao = string.Format("03{0}", titulo.Instrucao2.FillRight(2,'0'));
                            break;
               
                    case 4: // Protestar no 3� dia util ap�s vencimento
                        if (string.IsNullOrEmpty(titulo.Instrucao1.Trim()) ||
                            titulo.Instrucao1 == "04")
                            aInstrucao = string.Format("04{0}", titulo.Instrucao2.FillRight(2,'0'));
                            break;
                    
                    case 5: // Protestar no 3� dia util ap�s vencimento
                        if (string.IsNullOrEmpty(titulo.Instrucao1.Trim()) ||
                            titulo.Instrucao1 == "05")
                            aInstrucao = string.Format("05{0}", titulo.Instrucao2.FillRight(2,'0'));
                            break;
                    
                    default: // Protestar no 3� dia util ap�s vencimento
                        if (string.IsNullOrEmpty(titulo.Instrucao1.Trim()) ||
                            titulo.Instrucao1 == "06")
                            aInstrucao = string.Format("06{0}", titulo.Instrucao2.FillRight(2,'0'));
                            break;
                }
            }
            else
            {
                titulo.Instrucao1 = "07"; //N�o Protestar
                aInstrucao = string.Format("{0}{1}", titulo.Instrucao1.Trim().FillRight(2,'0'), 
                    titulo.Instrucao2.Trim().FillRight(2,'0'));
                diasProtesto = "  ";
            }
            
            var aDataDesconto = "000000";
            if(titulo.ValorDesconto > 0)
            {
                if(titulo.DataDesconto > new DateTime(2000,01,01))
                    aDataDesconto = string.Format("{0:ddMMyy}", titulo.DataDesconto);
                else
                    aDataDesconto = "777777";
            }
            
            //Pegando Tipo de Sacado}
            string aTipoSacado;
            switch(titulo.Sacado.Pessoa)
            {
                case Pessoa.Fisica:
                   aTipoSacado = "01";
                    break;
                    
                case Pessoa.Juridica:
                    aTipoSacado = "02";
                    break;
                
                default:
                    aTipoSacado = "00";
                    break;
            }
            
            
            //Pegando Tipo de Cedente}
            var aTipoCendente = string.Empty;
            switch(titulo.Parent.Cedente.TipoInscricao)
            {
                case PessoaCedente.Fisica:
                    aTipoCendente = "01";
                    break;
                
                case PessoaCedente.Juridica:
                    aTipoCendente = "02";
                    break;
            }
            
            var aMensagem = string.Empty;
            if(titulo.Mensagem.Count > 0)
                aMensagem = titulo.Mensagem[0];
            
            var wLinha = new StringBuilder();
            
            if(tamConvenioMaior6)
                wLinha.Append('7');                                                         // ID Registro
            else
                wLinha.Append('1');                                                         // ID Registro
            
            wLinha.Append(aTipoCendente);                                                   // Tipo de inscri��o da empresa 01-CPF / 02-CNPJ
            wLinha.Append(titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));       //Inscri��o da empresa
            wLinha.Append(aAgencia);                                                        // Prefixo da agencia
            wLinha.Append(titulo.Parent.Cedente.AgenciaDigito.FillLeft(1));                 // DV-prefixo da agencia
            wLinha.Append(aConta);                                                          // C�digo do cendete/nr. conta corrente da empresa
            wLinha.Append(titulo.Parent.Cedente.ContaDigito.FillLeft(1));                   // DV-c�digo do cedente

            if(tamConvenioMaior6)
                wLinha.Append(titulo.Parent.Cedente.Convenio.Trim().FillRight(7));          // N�mero do convenio
            else
                wLinha.Append(titulo.Parent.Cedente.Convenio.Trim().FillRight(6));          // N�mero do convenio
            
            wLinha.Append(titulo.SeuNumero.FillLeft(25));                                   // Numero de Controle do Participante
            
            if(tamConvenioMaior6)
                wLinha.Append(aNossoNumero.ZeroFill(17));                                   // Nosso numero
            else
                wLinha.Append(aNossoNumero.FillRight(11) + aDigitoNossoNumero);


			wLinha.AppendFormat("0000{0}{1}", "".FillRight(7), aModalidade);                // Zeros + Brancos + Prefixo do titulo + Varia��o da carteira

            if(tamConvenioMaior6)
                wLinha.Append("".ZeroFill(7));                                             // Zero + Zeros + Zero + Zeros
            else
                wLinha.Append("".ZeroFill(13));
            
            wLinha.Append(aTipoCobranca);                                                  // Tipo de cobran�a - 11, 17 (04DSC, 08VDR, 02VIN, BRANCOS) 12,31,51 (BRANCOS)
            wLinha.Append(titulo.Carteira);                                                // Carteira
            wLinha.Append(aTipoOcorrencia);                                                // Ocorr�ncia "Comando"
            wLinha.Append(titulo.NumeroDocumento.FillLeft(10));                            // Seu Numero - Nr. titulo dado pelo cedente
            wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);                          // Data de vencimento
            wLinha.Append(titulo.ValorDocumento.ToDecimalString());                        // Valor do titulo
            wLinha.Append("0010000 ");                                                     // Numero do Banco - 001 + Prefixo da agencia cobradora + DV-pref. agencia cobradora
            wLinha.Append(aTipoEspecieDoc.FillRight(2, '0') + aTipoAceite);                // Especie de titulo + Aceite
            wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                       // Data de Emiss�o
            wLinha.Append(aInstrucao);                                                     // 1� e 2� instru��o codificada
            wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());                        // Juros de mora por dia
            wLinha.Append(aDataDesconto);                                                  // Data limite para concessao de desconto
            wLinha.Append(titulo.ValorDesconto.ToDecimalString());                         // Valor do desconto
            wLinha.Append(titulo.ValorIOF.ToDecimalString());                              // Valor do IOF
            wLinha.Append(titulo.ValorAbatimento.ToDecimalString());                       // Valor do abatimento permitido
            wLinha.Append(aTipoSacado);
            wLinha.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().FillRight(14,'0'));           // Tipo de inscricao do sacado + CNPJ ou CPF do sacado
            wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(37) + "   ");                   // Nome do sacado + Brancos
            wLinha.Append(string.Format("{0}, {1} {2}", titulo.Sacado.Logradouro.Trim(),
                       titulo.Sacado.Numero.Trim(), titulo.Sacado.Bairro.Trim())
                       .FillLeft(52));                                                      // Endere�o do sacado
            wLinha.Append(titulo.Sacado.CEP.OnlyNumbers().FillRight(8));                    // CEP do endere�o do sacado
            wLinha.Append(titulo.Sacado.Cidade.Trim().FillLeft(15));                        // Cidade do sacado
            wLinha.Append(titulo.Sacado.UF.FillLeft(2));                                    // UF da cidade do sacado
            wLinha.Append(aMensagem.FillLeft(40));                                          // Observa��es
            wLinha.Append(diasProtesto.FillRight(2,'0') + ' ');                             // N�mero de dias para protesto + Branco
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);

            
            wLinha.Append(Environment.NewLine);
            wLinha.Append('5');                                                           //Tipo Registro
            wLinha.Append("99");                                                          //Tipo de Servi�o (Cobran�a de Multa)
            wLinha.Append(titulo.PercentualMulta > 0 ?  '2' : '9');                       //Cod. Multa 2- Percentual 9-Sem Multa
            wLinha.Append(titulo.PercentualMulta > 0 ?
                string.Format("{0:ddMMyy}", titulo.DataMoraJuros) :
                "000000");                                                                //Data Multa
            wLinha.Append(titulo.PercentualMulta.ToDecimalString(12));                    //Perc. Multa
            wLinha.Append("".FillRight(372));                                              //Brancos
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 2);
            
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                        // ID Registro
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);  // Contador de Registros
            
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        /// <exception cref="Exception">@Agencia\Conta do arquivo inv�lido</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {            
            Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(77,79) != Numero,
				"{0} n�o � um arquivo de retorno do {1}", Banco.Parent.NomeArqRetorno, Nome);

            TamanhoMaximoNossoNum = 20;
            var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76);
            var rAgencia = aRetorno[0].ExtrairDaPosicao(27, 30).Trim();
            var rDigitoAgencia = aRetorno[0].ExtrairDaPosicao(31, 31);
            var rConta = aRetorno[0].ExtrairDaPosicao(32, 39).Trim();
            var rDigitoConta = aRetorno[0].ExtrairDaPosicao(40, 40).Trim();
            var rCodigoCedente = aRetorno[0].ExtrairDaPosicao(150, 156);
            
            Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(101, 107);
            Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100);
            
            Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno  && (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
                rConta != Banco.Parent.Cedente.Conta.OnlyNumbers()), @"Agencia\Conta do arquivo inv�lido");
            
            Banco.Parent.Cedente.Nome = rCedente;
            Banco.Parent.Cedente.Agencia = rAgencia;
            Banco.Parent.Cedente.AgenciaDigito = rDigitoAgencia;
            Banco.Parent.Cedente.Conta = rConta;
            Banco.Parent.Cedente.ContaDigito = rDigitoConta;
            Banco.Parent.Cedente.CodigoCedente = rCodigoCedente;
            Banco.Parent.ListadeBoletos.Clear();
            
            TamanhoMaximoNossoNum = 20;
            Titulo titulo;
            for (var contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
            {
                var linha = aRetorno[contLinha];

                if (linha.ExtrairDaPosicao(1, 1) != "7" && linha.ExtrairDaPosicao(1, 1) != "1")
                    continue;

                titulo = Banco.Parent.CriarTituloNaLista();

                titulo.SeuNumero = linha.ExtrairDaPosicao(39, 64);
                titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);
                titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(109, 110));

                var codOcorrencia = linha.ExtrairDaPosicao(109, 110) == "00" ? 0 : linha.ExtrairInt32DaPosicao(109, 110);
                int motivoLinha;
                int codMotivo;
                if (codOcorrencia >= 2 && codOcorrencia <= 10)
                {
                    motivoLinha = 87;
                    codMotivo = linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1) == "00" ? 0 :
                        linha.ExtrairInt32DaPosicao(motivoLinha, motivoLinha + 1);
                    titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(87, 88));
                    titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                }

                titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116);
                titulo.Vencimento = linha.ExtrairDataDaPosicao(147, 152);

                titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
                titulo.ValorIOF = linha.ExtrairDecimalDaPosicao( 215, 227);
                titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao( 228, 240);
                titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
                titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao( 254, 266);
                titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao( 267, 279);
                titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao( 280, 292);
                titulo.NossoNumero = linha.ExtrairDaPosicao( 64, 80);
                titulo.Carteira = linha.ExtrairDaPosicao( 92, 94);
                titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao( 182, 188); 
                titulo.ValorOutrasDespesas = linha.ExtrairDecimalDaPosicao( 189, 201);

                var tempdata = linha.ExtrairDataOpcionalDaPosicao(176, 181);
                if (tempdata.HasValue)
                    titulo.DataCredito = tempdata.Value;
            }

            TamanhoMaximoNossoNum = 10;
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroHeader240(int numeroRemessa)
        {
            string aTipoInscricao;
            switch (Banco.Parent.Cedente.TipoInscricao)
            {
                case PessoaCedente.Fisica:
                    aTipoInscricao = "1";
                    break;

                case PessoaCedente.Juridica:
                    aTipoInscricao = "2";
                    break;

                default:
                    aTipoInscricao = "1";
                    break;
            }

            var cnpjcic = Banco.Parent.Cedente.CNPJCPF.OnlyNumbers();
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            var aConta = Banco.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(12);
            var aModalidade = Banco.Parent.Cedente.Modalidade.Trim().ZeroFill(3);

            var result = new StringBuilder();
            result.AppendFormat("{0:000}", Banco.Numero);                                    //1 a 3 - C�digo do banco
            result.Append("0000");                                                           //4 a 7 - Lote de servi�o
            result.Append("0");                                                              //8 - Tipo de registro - Registro header de arquivo
            result.Append("".FillLeft(9));                                                    //9 a 17 Uso exclusivo FEBRABAN/CNAB
            result.Append(aTipoInscricao);                                                   //18 - Tipo de inscri��o do cedente
            result.Append(cnpjcic.FillRight(14, '0'));                                        //19 a 32 -N�mero de inscri��o do cedente
            result.Append(Banco.Parent.Cedente.Convenio.FillRight(9, '0') + "0014");          //33 a 45 - C�digo do conv�nio no banco [ Alterado conforme instru��es da CSO Bras�lia ] 27-07-09
            result.Append(Banco.Parent.ListadeBoletos[0].Carteira);                          //46 a 47 - Carteira
            result.Append(aModalidade + "  ");                                               //48 a 52 - Variacao Carteira
            result.Append(aAgencia);                                                         //53 a 57 - C�digo da ag�ncia do cedente
            result.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));               //58 - D�gito da ag�ncia do cedente
            result.Append(aConta);                                                           //59 a 70 - N�mero da conta do cedente
            result.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                 //71 - D�gito da conta do cedente
            result.Append(" ");                                                              //72 - D�gito verificador da ag�ncia / conta
            result.Append(Banco.Parent.Cedente.Nome.FillLeft(30).ToUpper());       //73 a 102 - Nome do cedente
            result.Append("BANCO DO BRASIL".FillLeft(30));                                    //103 a 132 - Nome do banco
            result.Append("".FillLeft(10));                                                   //133 a 142 - Uso exclusivo FEBRABAN/CNAB
            result.Append('1');                                                              //143 - C�digo de Remessa (1) / Retorno (2)
            result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);                               //144 a 151 - Data do de gera��o do arquivo
            result.AppendFormat("{0:hhmmss}", DateTime.Now);                                 //152 a 157 - Hora de gera��o do arquivo
            result.Append(numeroRemessa.ToString().FillRight(6, '0'));                        //158 a 163 - N�mero seq�encial do arquivo
            result.Append("030");                                                            //164 a 166 - N�mero da vers�o do layout do arquivo
            result.Append("".FillLeft(5, '0'));                                               //167 a 171 - Densidade de grava��o do arquivo (BPI)
            result.Append("".FillLeft(20));                                                   //172 a 191 - Uso reservado do banco
            result.Append("".FillLeft(20, '0'));                                              //192 a 211 - Uso reservado da empresa
            result.Append("".FillLeft(11));                                                   //212 a 222 - 11 brancos
            result.Append("CSP");                                                            //223 a 225 - 'CSP'
            result.Append("".FillLeft(3, '0'));                                               //226 a 228 - Uso exclusivo de Vans
            result.Append("".FillLeft(2));                                                    //229 a 230 - Tipo de servico
            result.Append("".FillLeft(10));                                                   //231 a 240 - titulo em carteira de cobranca

            // GERAR REGISTRO HEADER DO LOTE }
            result.Append(Environment.NewLine);
            result.AppendFormat("{0:000}", Banco.Numero);                                    //1 a 3 - C�digo do banco
            result.Append("0001");                                                           //4 a 7 - Lote de servi�o
            result.Append('1');                                                              //8 - Tipo de registro - Registro header de arquivo
            result.Append('R');                                                              //9 - Tipo de opera��o: R (Remessa) ou T (Retorno)
            result.Append("01");                                                             //10 a 11 - Tipo de servi�o: 01 (Cobran�a)
            result.Append("00");                                                             //12 a 13 - Forma de lan�amento: preencher com ZEROS no caso de cobran�a
            result.Append("020");                                                            //14 a 16 - N�mero da vers�o do layout do lote
            result.Append(" ");                                                              //17 - Uso exclusivo FEBRABAN/CNAB
            result.Append(aTipoInscricao);                                                   //18 - Tipo de inscri��o do cedente
            result.Append(cnpjcic.FillRight(15, '0'));                                        //19 a 32 -N�mero de inscri��o do cedente
            result.Append(Banco.Parent.Cedente.Convenio.FillRight(9, '0') + "0014");           //33 a 45 - C�digo do conv�nio no banco [ Alterado conforme instru��es da CSO Bras�lia ] 27-07-09
            result.Append(Banco.Parent.ListadeBoletos[0].Carteira);                          //46 a 47 - Carteira
            result.Append(aModalidade + "  ");                                               //48 a 52 - Variacao Carteira
            result.Append(aAgencia);                                                         //53 a 57 - C�digo da ag�ncia do cedente
            result.Append(Banco.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));              //58 - D�gito da ag�ncia do cedente
            result.Append(aConta);                                                           //59 a 70 - N�mero da conta do cedente
            result.Append(Banco.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                 //71 - D�gito da conta do cedente
            result.Append(" ");                                                              //72 - D�gito verificador da ag�ncia / conta
            result.Append(Banco.Parent.Cedente.Nome.FillLeft(30));                            //73 a 102 - Nome do cedente
            result.Append("".FillLeft(40));                                                   //104 a 143 - Mensagem 1 para todos os boletos do lote
            result.Append("".FillLeft(40));                                                   //144 a 183 - Mensagem 2 para todos os boletos do lote
            result.Append(numeroRemessa.ToString().FillRight(8, '0'));                        //184 a 191 - N�mero do arquivo
            result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);                               //192 a 199 - Data de gera��o do arquivo
            result.Append("".FillLeft(8, '0'));                                               //200 a 207 - Data do cr�dito - S� para arquivo retorno
            result.Append("".FillLeft(33));                                                   //208 a 240 - Uso exclusivo FEBRABAN/CNAB  

            return result.ToString();
        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTransacao240(Titulo titulo)
        {
            var aNossoNumero = FormataNossoNumero(titulo);
            var wTamConvenio = Banco.Parent.Cedente.Convenio.Length;
            var wTamNossoNum = CalcularTamMaximoNossoNumero(titulo.Carteira, titulo.NossoNumero);
            string aDv;

            if ((wTamConvenio == 7 || wTamConvenio == 6) && wTamNossoNum == 17)
                aDv = string.Empty;
            else
                aDv = CalcularDigitoVerificador(titulo);

            if (aNossoNumero == "0")
            {
                aNossoNumero = string.Empty;
                aDv = string.Empty;
            }

            var aAgencia = titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            var aConta = titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(12);

            //SEGMENTO P
            //Pegando o Tipo de Ocorrencia

            var aTipoOcorrencia = string.Empty;
            switch (titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar:
                    aTipoOcorrencia = "02";
                    break;

                case TipoOcorrencia.RemessaConcederAbatimento:
                    aTipoOcorrencia = "04";
                    break;

                case TipoOcorrencia.RemessaCancelarAbatimento:
                    aTipoOcorrencia = "05";
                    break;

                case TipoOcorrencia.RemessaAlterarVencimento:
                    aTipoOcorrencia = "06";
                    break;

                case TipoOcorrencia.RemessaConcederDesconto:
                    aTipoOcorrencia = "07";
                    break;

                case TipoOcorrencia.RemessaCancelarDesconto:
                    aTipoOcorrencia = "08";
                    break;

                case TipoOcorrencia.RemessaProtestar:
                    aTipoOcorrencia = "09";
                    break;

                case TipoOcorrencia.RemessaCancelarInstrucaoProtesto:
                    aTipoOcorrencia = "10";
                    break;

                case TipoOcorrencia.RemessaAlterarNomeEnderecoSacado:
                    aTipoOcorrencia = "12";
                    break;

                case TipoOcorrencia.RemessaDispensarJuros:
                    aTipoOcorrencia = "31";
                    break;

                default:
                    aTipoOcorrencia = "01";
                    break;
            }

            //Pegando o tipo de EspecieDoc
            var aTipoEspecieDoc = string.Empty;
            if (titulo.EspecieDoc == "DM")
                aTipoEspecieDoc = "02";
            else if (titulo.EspecieDoc == "RC")
                aTipoEspecieDoc = "17";
            else if (titulo.EspecieDoc == "NP")
                aTipoEspecieDoc = "12";
            else if (titulo.EspecieDoc == "NS")
                aTipoEspecieDoc = "16";
            else if (titulo.EspecieDoc == "ND")
                aTipoEspecieDoc = "19";
            else if (titulo.EspecieDoc == "DS")
                aTipoEspecieDoc = "04";

            //Pegando o Aceite do Titulo
            string aTipoAceite;
            switch (titulo.Aceite)
            {
                case AceiteTitulo.Sim:
                    aTipoAceite = "A";
                    break;

                default:
                    aTipoAceite = "N";
                    break;
            }

            //Pegando Tipo de Bancario
            //Quem emite e quem distribui o boleto?
            var aTipoBoleto = string.Empty;
            switch (titulo.Parent.Cedente.ResponEmissao)
            {
                case ResponEmissao.CliEmite:
                    aTipoBoleto = "22";
                    break;

                case ResponEmissao.BancoEmite:
                    aTipoBoleto = "11";
                    break;

                case ResponEmissao.BancoReemite:
                    aTipoBoleto = "41";
                    break;

                case ResponEmissao.BancoNaoReemite:
                    aTipoBoleto = "52";
                    break;
            }
                        
            var aCaracTitulo = string.Empty;
            switch (titulo.Parent.Cedente.CaracTitulo)
            {
                case CaracTitulo.Simples:
                    aCaracTitulo = "1";
                    break;

                case CaracTitulo.Vinculada:
                    aCaracTitulo = "2";
                    break;

                case CaracTitulo.Caucionada:
                    aCaracTitulo = "3";
                    break;

                case CaracTitulo.Descontada:
                    aCaracTitulo = "4";
                    break;

                case CaracTitulo.Vendor:
                    aCaracTitulo = "5";
                    break;
            }

            var wCarteira = titulo.Carteira.ToInt32();
            string wTipoCarteira;

            if ((wCarteira == 11 || wCarteira == 12 || wCarteira == 17) && aCaracTitulo == "1")
                wTipoCarteira = "1";
            else if (((wCarteira == 11 || wCarteira == 17) && (aCaracTitulo == "2" || aCaracTitulo == "3")) || wCarteira == 31)
                wTipoCarteira = aCaracTitulo;
            else if (((wCarteira == 11 || wCarteira == 17) && aCaracTitulo == "4") || wCarteira == 51)
                wTipoCarteira = aCaracTitulo;
            else
                wTipoCarteira = "7";

            //Mora Juros
            string aDataMoraJuros;
            if (titulo.ValorMoraJuros > 0)
            {
                if (titulo.DataMoraJuros.HasValue && titulo.DataMoraJuros > DateTime.Now)
                    aDataMoraJuros = string.Format("{0:ddMMyyyy}", titulo.DataMoraJuros);
                else
                    aDataMoraJuros = "".FillLeft(8, '0');
            }
            else
                aDataMoraJuros = "".FillLeft(8, '0');

            //Descontos
            string aDataDesconto;
            if (titulo.ValorDesconto > 0)
            {
                if (titulo.DataDesconto.HasValue && titulo.DataDesconto > DateTime.Now)
                    aDataDesconto = string.Format("{0:ddMMyyyy}", titulo.DataDesconto);
                else
                    aDataDesconto = "".FillLeft(8, '0');
            }
            else
                aDataDesconto = "".FillLeft(8, '0');

			//Data Protesto
			string aDataProtesto;
			if (titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento)
				aDataProtesto = string.Format("{0:dd}", titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date));
			else
				aDataProtesto = "00";

            //SEGMENTO P
            var result = new StringBuilder();
            result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - C�digo do banco
            result.Append("0001");                                                                        //4 a 7 - Lote de servi�o
            result.Append("3");                                                                           //8 - Tipo do registro: Registro detalhe
            result.AppendFormat("{0:00000}", (3 * titulo.Parent.ListadeBoletos.IndexOf(titulo) + 1));     //9 a 13 - N�mero seq�encial do registro no lote - Cada t�tulo tem 2 registros (P e Q)
            result.Append("P");                                                                           //14 - C�digo do segmento do registro detalhe
            result.Append(" ");                                                                           //15 - Uso exclusivo FEBRABAN/CNAB: Branco
            result.Append(aTipoOcorrencia);                                                               //16 a 17 - C�digo de movimento
            result.Append(aAgencia);                                                                      //18 a 22 - Ag�ncia mantenedora da conta
            result.Append(titulo.Parent.Cedente.AgenciaDigito.FillLeft(1, '0'));                           //23 -D�gito verificador da ag�ncia
            result.Append(aConta);                                                                        //24 a 35 - N�mero da conta corrente
            result.Append(titulo.Parent.Cedente.ContaDigito.FillLeft(1, '0'));                             //36 - D�gito verificador da conta
            result.Append(" ");                                                                           //37 - D�gito verificador da ag�ncia / conta
            result.Append(aNossoNumero + aDv.FillLeft(20));                                                //38 a 57 - Nosso n�mero - identifica��o do t�tulo no banco
            result.Append(wTipoCarteira);                                                                 //58 - Cobran�a Simples
            result.Append('1');                                                                           //59 - Forma de cadastramento do t�tulo no banco: com cadastramento
            result.Append(((int)titulo.Parent.Cedente.TipoDocumento).ToString());                         //60 - Tipo de documento: Tradicional
            result.Append(aTipoBoleto);                                                                   //61 a 62 - Quem emite e quem distribui o boleto?
            result.Append(titulo.NumeroDocumento.FillLeft(15));                                            //63 a 77 - N�mero que identifica o t�tulo na empresa [ Alterado conforme instru��es da CSO Bras�lia ] {27-07-09}
            result.AppendFormat("{0:ddMMyyyy}", titulo.Vencimento);                                       //78 a 85 - Data de vencimento do t�tulo
            result.Append(titulo.ValorDocumento.ToDecimalString(15));                                     //86 a 100 - Valor nominal do t�tulo
            result.Append("000000");                                                                      //101 a 106 - Ag�ncia cobradora + Digito. Se ficar em branco, a caixa determina automaticamente pelo CEP do sacado
            result.Append(aTipoEspecieDoc.FillLeft(2));                                                    //107 a 108 - Esp�cie do documento
            result.Append(aTipoAceite);                                                                   //109 - Identifica��o de t�tulo Aceito / N�o aceito
            result.AppendFormat("{0:ddMMyyyy}", titulo.DataDocumento);                                    //110 a 117 - Data da emiss�o do documento
            result.Append(titulo.ValorMoraJuros > 0 ? '1' : '3');                                         //118 - C�digo de juros de mora: Valor por dia
            result.Append(aDataMoraJuros);                                                                //119 a 126 - Data a partir da qual ser�o cobrados juros
            result.Append(titulo.ValorMoraJuros > 0 ? titulo.ValorMoraJuros.ToDecimalString(15) :
                                                        "0".ZeroFill(15));                                //127 a 141 - Valor de juros de mora por dia
            result.Append(titulo.ValorDesconto > 0 ?
                titulo.DataDesconto > DateTime.Now ? '1' : '3' : '0');                                    //142 - C�digo de desconto: 1 - Valor fixo at� a data informada 4-Desconto por dia de antecipacao 0 - Sem desconto
            result.Append(titulo.ValorDesconto > 0 ?
                titulo.DataDesconto > DateTime.Now ? aDataDesconto : "00000000" : "00000000");            //143 a 150 - Data do desconto
            result.Append(titulo.ValorDesconto > 0 ? titulo.ValorDesconto.ToDecimalString(15) : 
                                                        "0".ZeroFill(15));                                //151 a 165 - Valor do desconto por dia
            result.Append(titulo.ValorIOF.ToDecimalString(15));                                           //166 a 180 - Valor do IOF a ser recolhido
            result.Append(titulo.ValorAbatimento.ToDecimalString(15));                                    //181 a 195 - Valor do abatimento
            result.Append(titulo.SeuNumero.FillLeft(25));                                                 //196 a 220 - Identifica��o do t�tulo na empresa

            result.Append(titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento ?
				titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days > 5 ?
				'1' : '2' : '3');																		  //221 - C�digo de protesto: Protestar em XX dias corridos

			result.Append(aDataProtesto);                                                                 //222 a 223 - Prazo para protesto (em dias corridos)

            result.Append("0");                                                                           //224 - Campo n�o tratado pelo BB [ Alterado conforme instru��es da CSO Bras�lia ] {27-07-09}
            result.Append("000");                                                                         //225 a 227 - Campo n�o tratado pelo BB [ Alterado conforme instru��es da CSO Bras�lia ] {27-07-09}
            result.Append("09");                                                                          //228 a 229 - C�digo da moeda: Real
            result.Append("".FillLeft(10, '0'));                                                           //230 a 239 - Uso exclusivo FEBRABAN/CNAB
            result.Append(" ");                                                                           //240 - Uso exclusivo FEBRABAN/CNAB

            //SEGMENTO Q
            result.Append(Environment.NewLine);
            result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - C�digo do banco
            result.Append("0001");                                                                        //N�mero do lote
            result.Append("3");                                                                           //Tipo do registro: Registro detalhe
            result.AppendFormat("{0:00000}", (3 * titulo.Parent.ListadeBoletos.IndexOf(titulo) + 1));     //9 a 13 - N�mero seq�encial do registro no lote - Cada t�tulo tem 2 registros (P e Q)
            result.Append("Q");                                                                           //C�digo do segmento do registro detalhe
            result.Append(" ");                                                                           //Uso exclusivo FEBRABAN/CNAB: Branco
            result.Append(aTipoOcorrencia);                                                               //Tipo Ocorrencia

            //Dados do sacado
            result.Append(titulo.Sacado.Pessoa == Pessoa.Juridica ? '2' : '1');                           //Tipo inscricao
            result.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().FillLeft(15, '0'));
            result.Append(titulo.Sacado.NomeSacado.FillLeft(40));
            result.Append((string.Format("{0} {1} {2}", titulo.Sacado.Logradouro,
                titulo.Sacado.Numero, titulo.Sacado.Complemento)).FillLeft(40));
            result.Append(titulo.Sacado.Bairro.FillLeft(15));
            result.Append(titulo.Sacado.CEP.OnlyNumbers().FillRight(8, '0'));
            result.Append(titulo.Sacado.Cidade.FillLeft(15));
            result.Append(titulo.Sacado.UF.FillLeft(2));

            //Dados do sacador/avalista
            result.Append('0');                                                                           //Tipo de inscri��o: N�o informado
            result.Append("".FillLeft(15, '0'));                                                           //N�mero de inscri��o
            result.Append("".FillLeft(40));                                                                //Nome do sacador/avalista
            result.Append("".FillLeft(3, '0'));                                                            //Uso exclusivo FEBRABAN/CNAB
            result.Append("".FillLeft(20));                                                                //Uso exclusivo FEBRABAN/CNAB
            result.Append("".FillLeft(8));                                                                 //Uso exclusivo FEBRABAN/CNAB

            //SEGMENTO R
            result.Append(Environment.NewLine);
            result.AppendFormat("{0:000}", Banco.Numero);                                                 //1 a 3 - C�digo do banco
            result.Append("0001");                                                                        //N�mero do lote
            result.Append("3");                                                                           //Tipo do registro: Registro detalhe
            result.AppendFormat("{0:00000}", (3 * titulo.Parent.ListadeBoletos.IndexOf(titulo) + 1));     //9 a 13 - N�mero seq�encial do registro no lote - Cada t�tulo tem 2 registros (P e Q)
            result.Append('R');                                                                           // 14 - 14 C�digo do segmento do registro detalhe
            result.Append(" ");                                                                           // 15 - 15 Uso exclusivo FEBRABAN/CNAB: Branco
            result.Append(aTipoOcorrencia);                                                               // 16 - 17 Tipo Ocorrencia
            result.Append("".FillRight(48, '0'));                                                         // 18 - 65 Brancos (N�o definido pelo FEBRAN)
			result.Append(titulo.PercentualMulta > 0 ? titulo.CodigoMora : '0');                          // 66 - 66 1-Valor Fixo / 2-Percentual
            result.Append(titulo.PercentualMulta > 0 ?
                string.Format("{0:ddMMyyyy}", titulo.DataMoraJuros) : "00000000");                        // 67 - 74 Se cobrar informe a data para iniciar a cobran�a ou informe zeros se n�o cobrar

            result.Append(titulo.PercentualMulta > 0 ? titulo.PercentualMulta.ToDecimalString(15) :
                    "".FillLeft(15, '0'));                                                                 // 75 - 89 Percentual de multa. Informar zeros se n�o cobrar

            result.Append("".FillLeft(110));                                                               // 90 - 199
            result.Append("".FillLeft(8, '0'));                                                            // 200 - 207
            result.Append("".FillRight(33));                                                               // 208 - 240 Brancos (N�o definido pelo FEBRAN)

            return result.ToString();
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> aRemessa)
        {
            //REGISTRO TRAILER DO LOTE}
            var result = new StringBuilder();
            result.AppendFormat("{0:000}", Banco.Numero);                               //C�digo do banco
            result.Append("0001");                                                      //N�mero do lote
            result.Append('5');                                                         //Tipo do registro: Registro trailer do lote
            result.Append("".FillLeft(9));                                              //Uso exclusivo FEBRABAN/CNAB
            result.AppendFormat("{0:000000}", aRemessa.Count - 2);                      //Quantidade de Registro da Remessa
            result.Append("".FillLeft(6, '0'));                                         //Quantidade t�tulos em cobran�a
            result.Append("".FillLeft(17, '0'));                                        //Valor dos t�tulos em carteiras}
            result.Append("".FillLeft(6, '0'));                                         //Quantidade t�tulos em cobran�a
            result.Append("".FillLeft(17, '0'));                                        //Valor dos t�tulos em carteiras}
            result.Append("".FillLeft(6, '0'));                                         //Quantidade t�tulos em cobran�a
            result.Append("".FillLeft(17, '0'));                                        //Valor dos t�tulos em carteiras}
            result.Append("".FillLeft(6, '0'));                                         //Quantidade t�tulos em cobran�a
            result.Append("".FillLeft(17, '0'));                                        //Valor dos t�tulos em carteiras}
            result.Append("".FillLeft(8));                                              //Uso exclusivo FEBRABAN/CNAB}
            result.Append("".FillLeft(117));

            //ERAR REGISTRO TRAILER DO ARQUIVO}
            result.Append(Environment.NewLine);
            result.AppendFormat("{0:000}", Banco.Numero);                               //C�digo do banco
            result.Append("9999");                                                      //Lote de servi�o
            result.Append('9');                                                         //Tipo do registro: Registro trailer do arquivo
            result.Append("".FillLeft(9));                                              //Uso exclusivo FEBRABAN/CNAB}
            result.Append("000001");                                                    //Quantidade de lotes do arquivo}
			result.AppendFormat("{0:000000}", aRemessa.Count + 2);                      //Quantidade de registros do arquivo, inclusive este registro que est� sendo criado agora}
            result.Append("".FillLeft(6));                                              //Uso exclusivo FEBRABAN/CNAB}
            result.Append("".FillLeft(205));                                            //Uso exclusivo FEBRABAN/CNAB}      

            return result.ToString();
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="aRetorno">A retorno.</param>
        /// <exception cref="Exception">@CNPJ\CPF do arquivo inv�lido</exception>
        public override void LerRetorno240(List<string> aRetorno)
        {
            Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(1, 3) != Numero,
                "{0} n�o � um arquivo de retorno do {1}'", Banco.Parent.NomeArqRetorno, Nome);
            
            Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(144, 151);
            Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(158, 163);
            
            var rCedente = aRetorno[0].ExtrairDaPosicao(73, 102).Trim();
            var rCNPJCPF = aRetorno[0].ExtrairDaPosicao(19, 32).OnlyNumbers();
            
            Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers(),
				"CNPJ\\CPF do arquivo inv�lido");
            
            Banco.Parent.Cedente.Nome = rCedente;
            Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
            
            switch(aRetorno[0].ExtrairInt32DaPosicao(18, 18))
            {
                case 1:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
                    break;

                default:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;
            }
            
            Banco.Parent.ListadeBoletos.Clear();
            
            TamanhoMaximoNossoNum = 20;
            Titulo titulo = null;

            for(var contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
            {
               var linha = aRetorno[contLinha];
                
                 // verifica se o registro (linha) � um registro detalhe (segmento J)
                if(linha.ExtrairInt32DaPosicao(8, 8) != 3)
                    continue;
                
                // se for segmento T cria um novo titulo                
                if(linha.ExtrairDaPosicao(14, 14) == "T")
                {
                    titulo = Banco.Parent.CriarTituloNaLista();

                    switch (linha.ExtrairDaPosicao(133, 133))
                    {
                        case "1":
                            titulo.Sacado.Pessoa = Pessoa.Fisica;
                            break;
                        case "2":
                            titulo.Sacado.Pessoa = Pessoa.Juridica;
                            break;
                        default:
                            titulo.Sacado.Pessoa = Pessoa.Outras;
                            break;
                    }

                    switch (titulo.Sacado.Pessoa)
                    {
                        case Pessoa.Fisica:
                            titulo.Sacado.CNPJCPF = linha.ExtrairDaPosicao(137, 148);
                            break;

                        case Pessoa.Juridica:
                            titulo.Sacado.CNPJCPF = linha.ExtrairDaPosicao(135, 148);
                            break;

                        default:
                            titulo.Sacado.CNPJCPF = linha.ExtrairDaPosicao(134, 148);
                            break;
                    }

                    titulo.Sacado.NomeSacado = linha.ExtrairDaPosicao(149, 188).Trim();

                    titulo.SeuNumero = linha.ExtrairDaPosicao(106, 130);
                    titulo.NumeroDocumento = linha.ExtrairDaPosicao(59, 73);
                    titulo.Carteira = linha.ExtrairDaPosicao(58, 58);
                    
                    var dt = linha.ExtrairDataOpcionalDaPosicao(74, 81);
                    if(dt.HasValue)
                        titulo.Vencimento = dt.Value;

                    titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(82, 96);
                    titulo.NossoNumero = linha.ExtrairDaPosicao(38, 57);
                    titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(199, 213);                    
                    titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(16, 17));
                    
                    var idxMotivo = 214;                    
                    while (idxMotivo < 223)
                    {
						if (!string.IsNullOrEmpty(linha.ExtrairDaPosicao(idxMotivo, idxMotivo + 1)) ||
							!linha.ExtrairDaPosicao(idxMotivo, idxMotivo + 1).Equals("00"))
                        {
                            titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(idxMotivo, idxMotivo+1));
                            titulo.DescricaoMotivoRejeicaoComando.Add(
                                CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, 
                                linha.ExtrairInt32DaPosicao(idxMotivo, idxMotivo+1)));
                        }
                        idxMotivo += 2;
                    }
                }
                else
                { 
                    // segmento U
                    titulo.ValorIOF = linha.ExtrairDecimalDaPosicao(63, 77);
                    titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(48, 62);
                    titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(33, 47);
                    titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(18, 32);
                    titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao(123, 137);
                    titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(78, 92);
                    titulo.ValorOutrasDespesas = linha.ExtrairDecimalDaPosicao(108, 113); 
                    
                    var tempData = linha.ExtrairDataOpcionalDaPosicao(138, 145);
                    if(tempData.HasValue)
                        titulo.DataOcorrencia = tempData.Value;

                    tempData = linha.ExtrairDataOpcionalDaPosicao(146, 153);
                    if(tempData.HasValue)
                        titulo.DataCredito = tempData.Value;
                }
            }
            
            TamanhoMaximoNossoNum = 10;
        }

        /// <summary>
        /// Gerars the registro headerDBT627.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroHeaderDBT627(int numeroRemessa)
        {
            var retorno = new StringBuilder();
            retorno.Append("A1");
            retorno.Append(Banco.Parent.Cedente.Convenio.FillLeft(20));
            retorno.Append(Banco.Parent.Cedente.Nome.FillLeft(20));
            retorno.AppendFormat("{0:000}", Numero);
            retorno.Append(Nome.FillRight(20));
            retorno.AppendFormat("{0:yyyyMMdd}", DateTime.Now);
            retorno.AppendFormat("{0:000000}", numeroRemessa);
            retorno.Append("04DEBITO AUTOMATICO");
            retorno.Append("".FillRight(52));

            return retorno.ToString().ToUpper();
        }

        /// <summary>
        /// Gerars the registro transacaoDBT627.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTransacaoDBT627(Titulo titulo)
        {
            var retorno = new StringBuilder();
            retorno.Append("E");
            retorno.Append(titulo.NumeroDocumento.Trim().FillLeft(25));
            retorno.Append(titulo.Sacado.Agencia.Trim().ZeroFill(4));
            retorno.Append(titulo.Sacado.Conta.Trim().ZeroFill(14));
            retorno.Append(titulo.Vencimento.ToString("yyyyMMdd"));
            retorno.Append(titulo.ValorDocumento.ToDecimalString(15));
            retorno.Append("03");
            retorno.Append(titulo.Sacado.NomeSacado.RemoveCe().FillLeft(60));
            retorno.Append("".FillRight(20));
            retorno.Append("0");

            return retorno.ToString().ToUpper();
        }

        /// <summary>
        /// Gerars the registro traillerDBT627.
        /// </summary>
        /// <param name="aRemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTraillerDBT627(List<string> aRemessa)
        {
            var valortotal = Banco.Parent.ListadeBoletos.Sum(titulo => titulo.ValorDocumento);
            var retorno = new StringBuilder();
            retorno.AppendFormat("Z{0:000000}", aRemessa.Count + 1);
            retorno.Append(valortotal.ToDecimalString(17));
            retorno.Append("".FillRight(126));

            return retorno.ToString().ToUpper();
        }

        #endregion Methods
    }
}