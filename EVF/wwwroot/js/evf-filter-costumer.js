let timeoutId = null;
function initEventTableCustomer() {
    let focusedElement = null;

    // Subscription event for search input
    $("#customerSearchName, #customerSearchCode").on("input", function (event) {
        console.log("Updated searched column = ", event.currentTarget.id);
        const params = getCommonParameters();
        focusedElement = $(":focus").attr("id");
        console.log(params);

        clearTimeout(timeoutId);
        timeoutId = setTimeout(function () {
            updateCustomersTable(params.monthStart, params.monthEnd, params.yearStart, params.yearEnd, null, params.searchedName, params.searchedCode, params.idStatus, null, params.idCommercial, focusedElement);
        }, 600);
    });

    // Subscription event for pagination
    $(".pagination").on("click", function (event) {
        const params = getCommonParameters();
        var targetPageNumber = $(event.currentTarget).attr('target-page');
        updateCustomersTable(params.monthStart, params.monthEnd, params.yearStart, params.yearEnd, null, params.searchedName, params.searchedCode, params.idStatus, targetPageNumber, params.idCommercial, null);
    });

    // Subscription event for status selection
    $("#entryStatus").on("change", function () {
        console.log("Status selected = ", $("#entryStatus option:selected").text());
        const params = getCommonParameters();
        updateCustomersTable(params.monthStart, params.monthEnd, params.yearStart, params.yearEnd, null, params.searchedName, params.searchedCode, params.idStatus, null, params.idCommercial, null);
    });

    // Subscription event for commercial selection
    $("#entryCommercial").on("change", function () {
        const params = getCommonParameters();
        updateCustomersTable(params.monthStart, params.monthEnd, params.yearStart, params.yearEnd, null, params.searchedName, params.searchedCode, params.idStatus, null, params.idCommercial, null);
    });

    // Subscription event for sorting table
    $("#sortCustomerName, #sortCustomerCode, #sortLastUpdate").on("click", function (event) {
        console.log("Clicked sort column = ", event.currentTarget.id);
        const params = getCommonParameters();
        var sortType = $(event.currentTarget).attr('customer-sort');
        updateCustomersTable(params.monthStart, params.monthEnd, params.yearStart, params.yearEnd, sortType, params.searchedName, params.searchedCode, params.idStatus, null, params.idCommercial, null);
    });

    // Subscription event for selecting a customer
    $('.customerLine').on('click', function (event) {
        var customerCode = $(event.currentTarget).attr('target-customer');
        var idCommercial = $(event.currentTarget).attr('target-commercial');
        console.log("Clicked on customer n° ", customerCode);

        var url = $(event.currentTarget).attr('target-url');
        var monthStart = $('#startMonthSelec').val();
        var yearStart = $('#startYearSelec').val();
        var monthEnd = $('#endMonthSelec').val();
        var yearEnd = $('#endYearSelec').val();

        goToCustomerProducts(url, monthStart, monthEnd, yearStart, yearEnd);
    });

    // Handle last focused element
    var searchedName = $("#customerSearchName").val();
    var searchedCode = $("#customerSearchCode").val();
    var focusedInputId = $("#focusedElement").val();

    if (focusedInputId === "customerSearchName") {
        putFocusBackInput(searchedName, "#customerSearchName");
    }
    if (focusedInputId === "customerSearchCode") {
        putFocusBackInput(searchedCode, "#customerSearchCode");
    }
}

// Initialize the event handlers when the document is ready
$(document).ready(function () {
    initEventTableCustomer();
});

// Helper functions
function putFocusBackInput(searchedElement, inputId) {
    if (searchedElement === "") {
        $(inputId).focus();
    } else {
        $(inputId).focus();
        $(inputId)[0].setSelectionRange($(inputId).val().length, $(inputId).val().length);
    }
}

function goToCustomerProducts(url, monthStart, monthEnd, yearStart, yearEnd) {
    window.location = url + "?monthStart=" + monthStart + "&yearStart=" + yearStart + "&monthEnd=" + monthEnd + "&yearEnd=" + yearEnd;
}

function getCommonParameters() {
    return {
        idStatus: $("#entryStatus option:selected").val(),
        searchedName: $("#customerSearchName").val(),
        searchedCode: $("#customerSearchCode").val(),
        idCommercial: $("#entryCommercial option:selected").val() ?? "1",
        monthStart: $('#startMonthSelec').val(),
        monthEnd: $('#endMonthSelec').val(),
        yearStart: $('#startYearSelec').val(),
        yearEnd: $('#endYearSelec').val(),
    };
}

function updateCustomersTable(monthStart, monthEnd, yearStart, yearEnd, sortType, searchedName, searchedCode, idStatus, targetPageNumber, idCommercial, focusedElement) {
    $.ajax({
        url: urlFilteredCustomers,  // Using the URL passed from Razor
        datatype: 'html',
        method: "GET",
        data: {
            monthStart: monthStart,
            monthEnd: monthEnd,
            yearStart: yearStart,
            yearEnd: yearEnd,
            sortOrder: sortType,
            searchName: searchedName,
            searchCode: searchedCode,
            selectStatus: idStatus,
            page: targetPageNumber,
            selectedCommercial: idCommercial,
            focusedElement: focusedElement
        },
        success: function (res) {
            $("#customersTab").html('').html(res);
            initEventTableCustomer();  // Reinitialize events after table update
        },
        error: function (err) {
            console.error("Error updating customer table", err);
        }
    });
}
