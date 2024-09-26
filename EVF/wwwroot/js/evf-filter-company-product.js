$(document).ready(function () {
    initEventTableProduct();
});

function initEventTableProduct() {
    var concatenatedCodeSAP = "";
    let timeout = null;
    let focusedElement = null;

    // SOUSCRIPTION EVENT RECHERCHE TABLEAU
    $("#productSearchDescriptionSoc, #productSearchCodeSoc").on("keyup", function (event) {
        if ($("#selectedProductsId tr").length > 0) {
            alert(warningMessage);
        } else {
            const params = getCommonParameters();
            var selectedProductsIds = "";

            focusedElement = $(":focus").attr("id");

            $("input:checkbox:checked").map(function () {
                selectedProductsIds += $(this).attr('id') + ",";
            });

            clearTimeout(timeout);
            timeout = setTimeout(function () {
                updateProductsTable(null, params.searchedDescription, params.searchedCode, null, selectedProductsIds, focusedElement);
            }, 600);
        }
    });

    // SOUSCRIPTION EVENT PAGINATION
    $(".pagination").on("click", function (event) {
        if ($("#selectedProductsId tr").length > 0) {
            alert(warningMessage);
        } else {
            const params = getCommonParameters();
            var targetPageNumber = $(event.currentTarget).attr('target-page');
            var selectedProductsIds = "";

            $("input:checkbox:checked").map(function () {
                selectedProductsIds += $(this).attr('id') + ",";
            });

            updateProductsTable(null, params.searchedDescription, params.searchedCode, targetPageNumber, selectedProductsIds, null);
        }
    });

    // SOUSCRIPTION EVENT TRI TABLEAU
    $("#sortCProductDescription, #sortCProductCode").on("click", function (event) {
        if ($("#selectedProductsId tr").length > 0) {
            alert("Veuillez ajouter les articles sélectionnés");
        } else {
            const params = getCommonParameters();
            var sortType = $(event.currentTarget).attr('product-sort');
            var selectedProductsIds = "";

            $("input:checkbox:checked").map(function () {
                selectedProductsIds += $(this).attr('id') + ",";
            });

            updateProductsTable(sortType, params.searchedDescription, params.searchedCode, null, selectedProductsIds, null);
        }
    });

    // SOUSCRIPTION EVENT SELECTION DE TOUS LES ARTICLES
    $("#selectAllCheckbox").on("click", function () {
        $('#selectedProductsId').html('');
        $('.addReturn-btn').removeAttr("disabled");
        $('.addStay-btn').removeAttr("disabled");
        $(".check").prop('checked', $(this).prop('checked'));

        $("input:checkbox:checked").map(function () {
            if ($(this).attr('id') != "selectAllCheckbox") {
                $(this).closest('tr').addClass('d-none');
                $(this).prop('checked', false);
                var description = $(this).closest('tr').find(`[data-type='Description']`)[0].innerText;
                var codeSAP = $(this).attr('id');
                let dynamicRowHTML = `<tr class="checked align-middle"><td>${description}</td><td>${codeSAP}</td>
                    <td><input class="selectOneProduct check pointer-cursor" type="checkbox" value="${codeSAP}" id="${codeSAP}" name="check1" checked hidden /></td>
                    <td class="removeSelectedProduct pointer-cursor"><i class="bi bi-trash3-fill text-danger removeSelectedProduct cursor-pointer"></i></td></tr>`;
                $('#selectedProductsId').append(dynamicRowHTML);

                concatenatedCodeSAP += codeSAP + ",";
                $("#productsToAdd").val(concatenatedCodeSAP);
            }
        });

        $("input#selectAllCheckbox").prop('checked', false);
    });

    // SOUSCRIPTION EVENT SELECTION ARTICLE
    $('#tableK tbody').on('click', 'input[type="checkbox"], .addToSecondTab', function (event) {
        $(this).closest('tr').toggleClass('d-none');
        var description = $(this).closest('tr').find(`[data-type='Description']`)[0].innerText;
        var codeSAP = $(this).closest('tr').find(`[data-type='CodeSAP']`)[0].innerText;

        let dynamicRowHTML = `<tr class="checked align-middle"><td>${description}</td><td>${codeSAP}</td>
            <td><input class="selectOneProduct check pointer-cursor" type="checkbox" value="${codeSAP}" id="${codeSAP}" name="check1" checked hidden /></td>
            <td class="removeSelectedProduct pointer-cursor"><i class="bi bi-trash3-fill text-danger"></i></td></tr>`;
        $('#selectedProductsId').append(dynamicRowHTML);

        $(event.currentTarget).prop('checked', false);

        concatenatedCodeSAP += codeSAP + ",";
        $("#productsToAdd").val(concatenatedCodeSAP);

        $('.addReturn-btn').removeAttr("disabled");
        $('.addStay-btn').removeAttr("disabled");
    });

    // SOUSCRIPTION EVENT SUPPRESSION DE L'ARTICLE AJOUTE
    $("#selectedProductsId").on('click', '.removeSelectedProduct', function (event) {
        var idSAP = "#" + $(this).prev('td').find('input').val();

        $(this).closest("tr").remove();
        $(idSAP).closest("tr").toggleClass('d-none');

        var productsList = $("#productsToAdd").val();
        var cleanIdSAP = idSAP.replace('#', '');
        var newProductsList = removeProduct(productsList, cleanIdSAP);

        $("#productsToAdd").val(newProductsList);

        $(idSAP).prop('checked', false);

        if ($("#selectedProductsId > tr").length == 0) {
            $('.addReturn-btn').prop("disabled", true);
            $('.addStay-btn').prop("disabled", true);
        }


    })

    // FOCUS INPUT
    var searchedDescription = $("#productSearchDescriptionSoc").val();
    var searchedCode = $("#productSearchCodeSoc").val();
    var focusedInputId = $("#focusedElement").val();

    if (focusedInputId === "productSearchDescriptionSoc") {
        putFocusBackInput(searchedDescription, "#productSearchDescriptionSoc");
    } else if (focusedInputId === "productSearchCodeSoc") {
        putFocusBackInput(searchedCode, "#productSearchCodeSoc");
    }
}

function removeProduct(productsList, productToRemove) {
    let arrayProducts = productsList.split(',');
    arrayProducts = arrayProducts.filter(productId => productId.trim() !== productToRemove);
    return arrayProducts.join(',');
}

function putFocusBackInput(searchedElement, inputId) {
    if (searchedElement === "") {
        $(`${inputId}`).focus();
    } else {
        $(`${inputId}`).focus();
        $(`${inputId}`)[0].setSelectionRange($(`${inputId}`).val().length, $(`${inputId}`).val().length);
    }
}

function getCommonParameters() {
    return {
        searchedDescription: $("#productSearchDescriptionSoc").val(),
        searchedCode: $("#productSearchCodeSoc").val(),
    };
}

function updateProductsTable(sortType, searchedDescription, searchedCode, targetPageNumber, selectedProductsIds, focusedElementId) {
    $.ajax({
        url: ajaxUrl,
        datatype: 'html',
        traditional: true,
        method: "GET",
        data: {
            id: customerCodeSAP,
            sortOrder: sortType,
            searchDescription: searchedDescription,
            searchCode: searchedCode,
            page: targetPageNumber,
            stringSelectedProducts: selectedProductsIds,
            idCommercial: idCommercial,
            focusedElementId: focusedElementId
        },
        success: function (res) {
            $("#productsTab").html('').html(res);
            initEventTableProduct(); // Rebind event handlers after AJAX update
        },
        error: function (err) {
        }
    });
}
