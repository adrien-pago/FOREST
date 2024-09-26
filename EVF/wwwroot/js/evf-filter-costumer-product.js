//$(document).ready(function () {
//    initEventTableProduct();
//});

function initEventTableProduct() {
    var listForecastsToAdd = "";
    var listArticles = "";
    let timeoutId = null;
    let focusedElement = null;

    // SOUSCRIPTION EVENT RECHERCHE TABLEAU
    $("#productSearchDescription, #productSearchCode").on("keyup", function (event) {
        const params = getCommonParameters();
        var collapsedSubtableId = $("#currentArticle").val();

        if (localStorage.getItem('VolumeModifié') == '1') {
            return $('#openForecastModal').click();
        }

        if (!$(collapsedSubtableId).hasClass("show")) {
            $("#currentArticle").val('');
            collapsedSubtableId = null;
        }

        focusedElement = $(":focus").attr("id");

        $("#entryStatusProToSend").val(params.idStatus);
        $("#productSearchDescriptionToSend").val(params.searchedDescription);
        $("#productSearchCodeToSend").val(params.searchedCode);

        clearTimeout(timeoutId);
        timeoutId = setTimeout(function () {
            updateProductsTable(null, params.searchedDescription, params.searchedCode, params.idStatus, null, focusedElement, collapsedSubtableId);
        }, 600);
    });

    // SOUSCRIPTION EVENT PAGINATION
    $(".pagination").on("click", function (event) {
        const params = getCommonParameters();
        var targetPageNumber = $(event.currentTarget).attr('target-page');
        var collapsedSubtableId = $("#currentArticle").val();

        if (!$(collapsedSubtableId).hasClass("show")) {
            $("#currentArticle").val('');
            collapsedSubtableId = null;
        }

        if (localStorage.getItem('VolumeModifié') == '1') {
            return $('#openForecastModal').click();
        }

        $(`#targetPageId_${collapsedSubtableId}`).val(targetPageNumber);
        $("#entryStatusProToSend").val(params.idStatus);
        $("#productSearchDescriptionToSend").val(params.searchedDescription);
        $("#productSearchCodeToSend").val(params.searchedCode);
        $("#currentPage").val(targetPageNumber);

        updateProductsTable(null, params.searchedDescription, params.searchedCode, params.idStatus, targetPageNumber, null, collapsedSubtableId);
    });

    // SOUSCRIPTION EVENT CHOIX STATUT TABLEAU
    $("#entryStatusPro").on("change", function () {
        const params = getCommonParameters();
        $('#entryStatusPro option[selected]').removeAttr("selected");
        $(this).find(":selected").attr("selected", "selected");
        var collapsedSubtableId = $("#currentArticle").val();

        if (!$(collapsedSubtableId).hasClass("show")) {
            $("#currentArticle").val('');
            collapsedSubtableId = null;
        }

        if (localStorage.getItem('VolumeModifié') == '1') {
            return $('#openForecastModal').click();
        }

        $("#productSearchDescriptionToSend").val(params.searchedDescription);
        $("#productSearchCodeToSend").val(params.searchedCode);

        updateProductsTable(null, params.searchedDescription, params.searchedCode, params.idStatus, null, null, collapsedSubtableId);
    });

    // SOUSCRIPTION EVENT TRI TABLEAU
    $("#sortProductDescription, #sortProductCode, #sortLastUpdate").on("click", function (event) {
        const params = getCommonParameters();
        var sortType = $(event.currentTarget).attr('product-sort');
        var collapsedSubtableId = $("#currentArticle").val();

        if (!$(collapsedSubtableId).hasClass("show")) {
            $("#currentArticle").val('');
            collapsedSubtableId = null;
        }

        if (localStorage.getItem('VolumeModifié') == '1') {
            return $('#openForecastModal').click();
        }

        $("#sortTypeId").val(sortType);
        $("#entryStatusProToSend").val(params.idStatus);
        $("#productSearchDescriptionToSend").val(params.searchedDescription);
        $("#productSearchCodeToSend").val(params.searchedCode);

        updateProductsTable(sortType, params.searchedDescription, params.searchedCode, params.idStatus, null, null, collapsedSubtableId);
    });

    // SOUSCRIPTION EVENT SAISIE PREVISIONS, VOLUME PAS EGAL A 0
    $(".dbVolume").on("keyup", function (event) {
        $(event.currentTarget).removeClass("dbVolume").addClass("dbVolumeOnChange");
    });

    // SOUSCRIPTION EVENT SAISIE PREVISIONS
    $(".input-values-forecasts, .decimalInputPrice").on("keyup", function (event) {
        localStorage.setItem('VolumeModifié', '1');
        localStorage.setItem("EditedArticle", $(event.currentTarget).attr('article-SAP'));
        listArticles += $(event.currentTarget).attr('article-SAP') + ",";
        localStorage.setItem("listArticles", listArticles);
    });

    // SOUSCRIPTION EVENT REMETTRE LES PREVISIONS INITIALES
    $(".undoChangesBtn").on("click", function () {
        $('.collapse.show').find('.input-values-forecasts').each(function (i) {
            if ($(this).hasClass("dbVolumeOnChange")) {
                $(this).removeClass("dbVolumeOnChange").addClass("dbVolume");
            }
            $(this).val($(this).attr('old-values'));
        });
    });

    // SOUSCRIPTION EVENT ENREGISTREMENT DERNIER SOUS TABLEAU OUVERT
    $(".article-row").on("click", event => {
        var idArticle = $(event.currentTarget).attr("aria-controls");
        var target = "#AR_" + idArticle;
        var idStatus = $("#entryStatusPro option:selected").val();

        if ($(event.currentTarget).attr("data-bs-target") !== null) {

            $(event.currentTarget).attr("data-bs-target", '')
        }
        else {

            $(event.currentTarget).attr("data-bs-target", target);
        }



        if (localStorage.getItem('VolumeModifié') !== '1' && $('#defaultSaveType').val() == 'Individual') {
            $(target).collapse('toggle');
        }

        if ($('#defaultSaveType').val() == 'Global') {
            $(target).collapse('toggle');
        }


        else if (localStorage.getItem('VolumeModifié') == '1' && $('#defaultSaveType').val() == 'Individual') {

            $('#openForecastModal').click();

        }



        $(target).find(`#collapsed_${idArticle}`).val(target);
        $("#currentArticle").val(target);


        $(`#entryStatusProToSend_${idArticle}`).val(idStatus);


        var targetPage = $('.active a').attr('target-page');
        $(target).find(`#targetPageId_${idArticle}`).val(targetPage);

    })

    // SOUSCRIPTION EVENT ENREGISTRER LES PREVISIONS SAISIES
    $("#saveForecastModal").on("click", function () {
        $(".btn-close").click();

        if ($('#defaultSaveType').val() == "Individual") {
            var codeArticle = localStorage.getItem("EditedArticle");
            $('form[form-article="' + codeArticle + '"]').submit();
        } else {
            $(".saveAllForecastDB-btn").click();
        }
    });

    // SOUSCRIPTION EVENT ENREGISTRER TOUTES LES PREVISIONS (GLOBALE)
    $(".saveAllForecastDB-btn").on("click", function () {
        $("#overlay").show();
        $('.spinner-loading-list').show();
        var allProducts = localStorage.getItem("listArticles").split(",").slice(0, -1);
        var allUniqueProducts = [...new Set(allProducts)];
        var count = 0;

        for (var product of allUniqueProducts) {
            count += 1;
            var data = $('form[form-article="' + product + '"]').serialize();

            $.ajax({
                url: ajaxUrlSaveProduct,
                datatype: 'html',
                method: "POST",
                data: data,
                success: function (res) {
                    if (count == allUniqueProducts.length) {
                        $("#overlay").addClass("d-none");
                        $('.spinner-loading-list').addClass("d-none");
                        window.location.reload();
                        initEventTableProduct();
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    });

    // SOUSCRIPTION EVENT ANNULER LES MODIFICATIONS PREVISIONS
    $("#cancelEditionModal").on("click", function () {
        if (localStorage.getItem("listArticles") !== null) {
            window.location.reload();
        }

        if (localStorage.getItem("backClicked") == "1") {
            localStorage.removeItem("backClicked");
            localStorage.removeItem("VolumeModifié");
            $("#backtoIndex").trigger('click');
        } else {
            $(".btn-close").click();
            var target = "#AR_" + $("#currentArticle").val().split("_")[1];
            $(target).collapse('toggle');
        }

        localStorage.removeItem("VolumeModifié");
        localStorage.removeItem("listArticles");

        $("#productSearchDescription").val("");
        $("#productSearchCode").val("");
    });

    // SOUSCRIPTION EVENT CONTINUER LES MODIFICATIONS PREVISIONS
    $("#continueEditionModal").on("click", function () {
        $(".btn-close").click();
    });

    // SOUSCRIPTION EVENT SUPPRIMER ARTICLE
    //$(".deleteNewProductBtn").on("click", function (event) {
    //    $(this).closest('tr').attr('aria-controls', '');

    //    var targetPageNumber = $(event.currentTarget).attr('target-page');
    //    $("#entryStatusProToSend").val(idStatus);

    //    event.preventDefault();
    //    event.stopPropagation();

    //    var url = $(this).attr('href') + "&selectedStatus=" + idStatus;
    //    window.location.href = url;

    //    event.preventDefault();
    //    event.stopPropagation();
    //});

    // SOUSCRIPTION EVENT RETOURNER PAGE D'ACCUEIL
    $("#backtoIndex").on("click", function (event) {
        if (localStorage.getItem('VolumeModifié') == '1') {
            event.preventDefault();
            $('#openForecastModal').click();
            localStorage.setItem("backClicked", "1");
        } else {
            window.location = $(event.currentTarget).attr('href');
        }
    });

    // SOUSCRIPTION CHANGEMENT DE COULEUR DU CHAMP DE SAISIE DES PREVISIONS ET REPORT DES PREVISIONN_UN
    $(document).on('click', '.forecastToAdd, .livresN1ToAdd', function () {
        var idArticle = $(this).attr('article-id');
        var inputs = $(`input.input-values-forecasts[article-id=${idArticle}]`);
        var valuesToAdd = $(this).hasClass('forecastToAdd') ? '.vol-PrevisionN_un' : '.vol-livreeN_un';
        var prevValues = $(`${valuesToAdd}[article-id=${idArticle}]`);

        inputs.each(function (index) {
            if ($(this).val() != 0) {
                $(this).removeClass("dbVolume").addClass("dbVolumeOnChange");
                $(this).val(prevValues.eq(index).text());
            } else {
                $(this).val(prevValues.eq(index).text());
            }
        });
    });

    // REAFFICHAGE DU SOUS TABLEAU TRAITE
    const collapsedArtId = $("#currentArticle").val();
    if (collapsedArtId !== null) {
        $(collapsedArtId).addClass("show");
    }

    // FOCUS ON INPUT
    var searchedDescription = $("#productSearchDescription").val();
    var searchedCode = $("#productSearchCode").val();
    var focusedInputId = $("#focusedElement").val();

    if (focusedInputId === "productSearchDescription") {
        putFocusBackInput(searchedDescription, "#productSearchDescription");
    } else if (focusedInputId === "productSearchCode") {
        putFocusBackInput(searchedCode, "#productSearchCode");
    }

    localStorage.removeItem("openedTab");
    localStorage.removeItem("lastClickedProduct");
    localStorage.removeItem("VolumeModifié");
    localStorage.removeItem("EditedArticle");
    localStorage.removeItem("backClicked");
}

$(() => {

    initEventTableProduct();
})

function putFocusBackInput(searchedElement, inputId) {
    if (searchedElement == "") {
        $(`${inputId}`).focus();
    }
    else {
        $(`${inputId}`).focus();
        $(`${inputId}`)[0].setSelectionRange($(`${inputId}`).val().length, $(`${inputId}`).val().length);
    }
}

// Get common search and status parameters
function getCommonParameters() {
    return {
        idStatus: $("#entryStatusPro option:selected").val(),
        searchedDescription: $("#productSearchDescription").val(),
        searchedCode: $("#productSearchCode").val(),
        collapsedSubtableId: $("#currentArticle").val(),
    };
}

// AJAX request to update the products table
function updateProductsTable(sortType, searchedDescription, searchedCode, idStatus, targetPageNumber, focusedElementId, collapsedSubtableId) {
    $.ajax({
        url: ajaxUrlFilterProducts,
        datatype: 'html',
        method: "GET",
        data: {
            id: customerCodeSAP,
            sortOrder: sortType,
            searchDescription: searchedDescription,
            searchCode: searchedCode,
            selectedStatus: idStatus,
            page: targetPageNumber,
            idCommercial: idCommercial,
            focusedElementId: focusedElementId,
            collapsedSubtableId: collapsedSubtableId
        },
        success: function (res) {
            $("#productsTab").html('').html(res);
            initEventTableProduct(); // Rebind event handlers after AJAX update
        },
        error: function (err) {
        }
    });
}

// Restore input focus after updating table
function putFocusBackInput(searchedElement, inputId) {
    if (searchedElement === "") {
        $(`${inputId}`).focus();
    } else {
        $(`${inputId}`).focus();
        $(`${inputId}`)[0].setSelectionRange($(`${inputId}`).val().length, $(`${inputId}`).val().length);
    }
}
