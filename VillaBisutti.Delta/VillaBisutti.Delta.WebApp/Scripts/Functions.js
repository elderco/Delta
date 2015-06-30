function LoadPage(url, target) {
	target = target.replace("#", "") == target ? "#" + target : target;
	$(target).load(url, function (response, status, xhr) {
		HandleResponse(response, status, xhr.status, xhr.statusText, target);
	});
}
function ShowPopUp(url, title, w, h) {
	var $div = $("<div/>").attr("id", "PopUp");
	$("body").append($div);
	var URL = url.indexOf("?") >= 0 ? "&" : "?";
	URL = url + URL + "sid=" + Math.random();
	var pw = !w || isNaN(w) ? $(window).width() - 100 : w;
	var ph = !h || isNaN(h) ? $(window).height() - 100 : h;
	$("#PopUp").attr("title", title).dialog({
		modal: true,
		width: pw,
		height: ph,
		resizable: false,
		draggable: false,
		position: {
			of: $(window),
			my: "center center",
			at: "center center"
		},
		close: function (event, ui) {
			$("#PopUp").remove();
		}
	}).load(URL, function (response, status, xhr) {
		HandleResponse(response, status, xhr.status, xhr.statusText, "#PopUp");
	}).css("overflow", "auto");
}
function ClosePopUp() {
	$("#PopUp").dialog('close');
}
function HandleResponse(responseText, statusResponse, statusCode, statusText, containerId) {
	if (statusResponse == "error") {
		var id = "ErrorDetail_" + Math.random();
		id = id.replace(".", "");
		var $errorContent = $("<div/>")
					.attr("id", id)
					.append(responseText)
					.addClass("ui-helper-hidden");
		id = "#" + id;
		var $header = $("<div/>")
					.addClass("ui-state-highlight")
					.css("cursor", "pointer")
					.append("<p>")
					.append("<h3>Ihhh! xalefaram o servidor...</h3>")
					.append("Tente novamente mais tarde ou clique para ver os detalhes do erro.<br />")
					.append("Código do erro: " + statusCode + " | Resposta: " + statusText + ".")
					.append("</p>")
					.click(function () {
						if ($(id).hasClass("ui-helper-hidden")) {
							$(id).removeClass("ui-helper-hidden");
						} else {
							$(id).addClass("ui-helper-hidden");
						}
					});
		$(containerId).html("").css("overflow", "auto").append($header).append($errorContent);
		if ($(containerId).hasClass("ui-helper-hidden")) {
			$(containerId).removeClass("ui-helper-hidden");
		}
	}
}
function MostrarAlerta(text, title) {
	if (!title) { title = "Atenção:"; }
	var $background = $("<div/>")
		.attr("id", "AlertBoxOverlay")
		.css("padding", "50px")
		.css("z-index", GetTopMostIndex())
		.addClass("ui-widget-overlay")
	var $container = $("<div/>")
		.attr("id", "AlertBox")
		.addClass("ui-state-highlight")
		.addClass("ui-corner-all")
		.css("width", "400px")
		.css("padding", "5px")
		.css("text-align", "center")
		.css("z-index", GetTopMostIndex())
		.append("<h3 class=\"ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix\" style=\"margin-top: 0px;\">" + title + "</h3>")
		.append("<p>" + text + "</p>")
		.draggable({ handle: "h3" })
		.position({
			of: $(window),
			my: "center top",
			at: "center top+50"
		});
	var $btn = $("<a/>")
		.attr("href", "javascript:void(0)")
		.append("Ok")
		.button({
			icons: {
				primary: "ui-icon-check"
			}
		}).click(function () {
			$("#AlertBox").remove();
			$("#AlertBoxOverlay").remove();
		});
	$container.append($btn);
	$("body").append($background);
	$("body").append($container);
}
function GetTopMostIndex() {
	return Math.max(0, Math.max.apply(null, $.map($.makeArray(document.getElementsByTagName("*")),
		function (v) {
			return parseFloat($(v).css("z-index")) || null;
		})));
}
var currentY = 30;
function GetCurrentY() {
	return $(window).height() - currentY;
}
function SetCurrentY(increase) {
	if (increase) {
		currentY += 30;
	} else {
		currentY -= 30;
	}
	if (currentY < 5) {
		currentY = 5;
	}
}
function AddStack(url) {
	var $stackContainer;
	if ($("#StackContainer").length) {
		$stackContainer = $("#StackContainer");
	} else {
		$stackContainer = $("<div/>");
		$stackContainer.attr("id", "StackContainer")
			.css("position", "absolute")
			.css("left", "5px")
			.css("top", GetCurrentY())
			.css("z-index", GetTopMostIndex());
		$stackContainer.appendTo($("body"));
	}
	var id = ("stackBox" + Math.random()).replace(".", "_");
	url += (url.replace("?", "") == url ? "?" : "&") + "HTMLElementId=" + id
	var $container = $("<div/>")
		.attr("id", id)
		.addClass("ui-corner-all")
		.addClass("ui-widget-content")
		.addClass("ui-state-highlight")
		.addClass("stack-item")
		.css("padding", "5px")
		.css("margin", "5px")
		.css("text-align", "justify")
		.css("z-index", GetTopMostIndex());
	SetCurrentY(true);
	$container.appendTo($stackContainer);
	RepositionStack();
	LoadPage(url, id);
}
function RepositionStack() {
	$("#StackContainer").css("top", GetCurrentY() + "px");
}
function RemoveStack(id) {
	window.setTimeout("$('#" + id + "').remove();SetCurrentY();RepositionStack();", 8000);
}
function CreateHorarioEditor(itemId) {
	var item = itemId.replace("#", "") == itemId ? "#" + itemId : itemId;
	$(item).addClass("hide");
	var $hour = $("<input/>")
		.attr("type", "number")
		.attr("min", "0")
		.attr("max", "23")
		.attr("id", itemId + "_h")
		.keyup(function () {
			FormatTextBox(itemId + "_h", "0", 2, 23);
		})
		.focusout(function () {
			FormatTextBox(itemId + "_h", "0", 2, 23);
		})
		.change(function () {
			ConvertHorarioBack(itemId);
			FormatTextBox(itemId + "_h", "0", 2, 23);
		});
	var $minute = $("<input/>")
		.attr("type", "number")
		.attr("min", "0")
		.attr("max", "59")
		.attr("step", "5")
		.attr("id", itemId + "_m")
		.keyup(function () {
			FormatTextBox(itemId + "_m", "0", 2, 59);
		})
		.focusout(function () {
			FormatTextBox(itemId + "_m", "0", 2, 59);
		})
		.change(function () {
			ConvertHorarioBack(itemId);
			FormatTextBox(itemId + "_m", "0", 2, 59);
		});
	var $texto = $("<span/>").html(":");
	$hour.insertBefore($(item));
	$texto.insertBefore($(item));
	$minute.insertBefore($(item));
	ConvertHorario(item);
	FormatTextBox(item + "_h", "0", 2, 23);
	FormatTextBox(item + "_m", "0", 2, 59);
}
function ConvertHorario(itemId) {
	itemId = itemId.replace("#", "") == itemId ? "#" + itemId : itemId;
	var horas = Math.floor($(itemId).val() / 60);
	var minutos = $(itemId).val() - (horas * 60);
	$(itemId + "_h").val(horas);
	$(itemId + "_m").val(minutos);
}
function ConvertHorarioBack(itemId) {
	itemId = itemId.replace("#", "") == itemId ? "#" + itemId : itemId;
	var horas = parseInt($(itemId + "_h").val());
	var minutos = parseInt($(itemId + "_m").val());
	$(itemId).val((horas * 60) + minutos);
}
function FormatTextBox(itemId, char, len, limit)
{
	itemId = itemId.replace("#", "") == itemId ? "#" + itemId : itemId;
	var txt = parseInt($(itemId).val()) + "";
	if (isNaN(txt))
		txt = "0";
	if (parseInt(txt) > limit)
		txt = limit;
	while (txt.length < len)
		txt = char + txt;
	if (txt.length > len)
		txt = txt.substr(0, len);
	$(itemId).val(txt);
}
function InitializeLoading() {
	var $background = $("<div/>")
		.attr("id", "LoadingOverlay")
		.css("z-index", GetTopMostIndex())
		.addClass("ui-widget-overlay")
		.hide();
	var $container = $("<div/>")
		.attr("id", "LoadingImage")
		.css("position", "absolute")
		.css("z-index", GetTopMostIndex())
		.position({
			of: $(window),
			my: "center center",
			at: "center center"
		})
		.append("<img src=\"" + document.location.protocol + "//" + document.location.host + "/Content/Images/ajax-loader.gif\" alt=\"Página carregando\" />")
		.hide();
	$("body").append($background);
	$("body").append($container);
}
function ShowLoading() {
	$("#LoadingOverlay").show();
	$("#LoadingImage").show();
}
function HideLoading() {
	window.setTimeout("$(\"#LoadingOverlay\").hide();$(\"#LoadingImage\").hide();", 500);
}
$(document)
	.ajaxStart(function () {
		ShowLoading();
	})
	.ajaxStop(function () {
		HideLoading();
	})
	.ready(function () {
		InitializeLoading();
		ShowLoading();
		HideLoading();
	})
	.error(function () {
		HideLoading();
	});
