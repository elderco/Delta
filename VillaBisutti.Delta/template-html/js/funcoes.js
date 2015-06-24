function baseUrl(){
  var url = window.location.pathname.split('/');
  return baseurl = '/'+url[1]+'/'+url[2]+'/'+url[3]; 
}

function carregaPopup(url){

  left = (screen.width) ? (screen.width-850)/2 : 0;
  top = (screen.height) ? (screen.height-800)/2 : 0;

  window.open(url,
     '','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no,top='+top+',left='+left+', width=850, height=800')
}

function verifica_checkbox(){
  var itens = new Array();
  var i = 0;

    $("input[name='itens[]']:checked").each(function(){
        itens[i] = this.value;
        i++;
    });

    return itens;
}

function reload_page(){
  window.location.reload(false);
}

function sleep(milliseconds) {
  var start = new Date().getTime();
  for (var i = 0; i < 1e7; i++) {
    if ((new Date().getTime() - start) > milliseconds){
      break;
    }
  }
}

function updateProgress(){

	var width = $('.progress-bar').width();
        var newWidth = width+10;
	$('.progress-bar').width(newWidth);

}

function toUpper(value){

	var texto = $('#'+value+'').val();

	$('#'+value+'').val(texto.toUpperCase());
}

function trocaFormAviso(element_id) {
  var id = $('#avisos :selected').val();

  $('[id^=form]').css('display', 'none');
  $('#form-'+id).css('display', 'block');
}

function popup_classificar_propostas(){

  var itens = verifica_checkbox();

  if(itens.length == 0){
    alert('Selecione um item.');
    return false;
  }

  for(i = 0; i < itens.length; i++){
      carregaPopup(baseUrl()+'/proposta_pregoes/classificacao_propostas/item_pregao_id:'+itens[i]);
  }
}

function alterar_status_item(item_pregao_id, status_item_id, ordem){

  if(!confirm('Você tem certeza que deseja ABRIR o item #'+ordem+' para lances?'))
      return false

  $.post(
          baseUrl()+'/itens_pregoes/alterar_status_item/item_pregao_id:'+item_pregao_id+'/status_item_id:'+status_item_id,
          function (data){
            window.opener.location.reload(false);
            window.close();
          }
     );
}

function desclassificar_proposta(proposta_item_id, justificativa, item_pregao_id){

    if(!confirm('Confirma a desclassificação da proposta?'))
        return false

    if(!justificativa){
      alert('Por gentileza, insira uma justificativa para a desclassificação da proposta');
        return false;
    }

    $.post(
          baseUrl()+'/proposta_pregoes/desclassificar_proposta/proposta_item_id:'+proposta_item_id,
          {justificativa: justificativa, proposta_item_id: proposta_item_id},
          function (data){

            // Função de reload quando estiver utilizando modal
            // classificar_propostas(item_pregao_id);

            window.location.reload(true);
            alert('Proposta desclassificada com sucesso');
          }
     );

}


  function cancelar_desclassificar_proposta(proposta_item_id, justificativa, item_pregao_id){

    if(!confirm('Confirma cancelamento da desclassificação da proposta?'))
        return false

    if(!justificativa){
      alert('Por gentileza, insira uma justificativa para o cancelamento da desclassificação da proposta');
        return false;
    }

    $.post(
          baseUrl()+'/proposta_pregoes/cancelar_desclassificar_proposta/proposta_item_id:'+proposta_item_id,
          {justificativa: justificativa, proposta_item_id: proposta_item_id},
          function (data){

            // Função de reload quando estiver utilizando modal
            // classificar_propostas(item_pregao_id);

            window.location.reload(true);
            alert('Cancelamento da desclassificação da proposta realizado com sucesso');
          }
     );

}

function cadastra_mensagem_pregoeiro(){

    if($('#ChatMensagem').val() == ''){
      alert('Insira uma mensagem');
      return false;
    }


    form = $("#ChatPregoeiroOperarForm").serialize();

     $.post(
        baseUrl()+'/chats/add/',
        form,
       function(data){
           if(data == 'Erro')
              alert('Não foi possível enviar a mensagem.');

            $('#ChatMensagem').val('');
            window.location.reload();
       }

     );
     event.preventDefault();
     return false;  //stop the actual form post !important!


 }

 function popup_excluir_lance(){

    var itens = verifica_checkbox();

    if(itens.length == 0){
      alert('Selecione um item.');
      return false;
    }

    for(i = 0; i < itens.length; i++){
      carregaPopup(baseUrl()+'/proposta_pregoes/excluir_lance/item_pregao_id:'+itens[i]);
    }
 }

function excluir_lance(proposta_item_id, pregao_id, ordem_item){

    if(!confirm('Confirma a exclusão deste lance?'))
        return false;

    $.post(
          baseUrl()+'/proposta_pregoes/excluir_lance/pregao_id:'+pregao_id+'/ordem_item:'+ordem_item+'/proposta_item_id:'+proposta_item_id,
          {proposta_item_id: proposta_item_id},
          function (data){
              alert('Lance excluído com sucesso.');
              window.opener.location.reload(false);
              window.location.reload();
          }
      );

 }

function pregoeiro_encerrar_itens(pregao_id){

  itens = verifica_checkbox();

  if(itens.length == 0){
    alert('Selecione ao menos um item para ser encerrado.');
    return false;
  }
  
  if(!confirm('Ao término do tempo de iminência será iniciado o encerramento aleatório do item. Você tem certeza que deseja informar e iniciar o tempo de iminência?'))
    return false;

  var tempo = prompt('Sr(a) Pregoeiro(a). Informe o tempo (de 1 a 60 minutos) para iniciar o encerramento aleatório.');

  $.post(
      baseUrl()+'/itens_pregoes/periodo_iminencia/pregao_id:'+pregao_id+'/iminencia:'+tempo+'/item_pregao_id:'+itens,
      function (data){
        alert('Operação realizada com sucesso.');
        window.location.reload(false);
      }
    );

}











