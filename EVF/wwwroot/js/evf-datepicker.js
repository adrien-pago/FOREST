class Datepicker {
    #monthInput = "<div class='col-3 mb-2'><span id='month[MONTHNUM]' type='text' class='form-control text-center border-2 rounded-2' >[MONTH]</span></div>";
    #monthList = [];
    #selectedMonth = 0;

    #minYear = 0;
    #maxYear = 0;

    #yearStart = 0;
    #monthStart = 0;
    #yearEnd = 0;
    #monthEnd = 0;

    constructor(previousStartYear, nextStartYear, startYear, previousEndYear, nextEndYear, endYear, monthList, startMonthsdiv, endMonthsdiv) {
        this.#monthList = monthList;

        this.#minYear = $(startYear).text();
        this.#maxYear = $(endYear).text();

        this.#yearStart = $('#startYearSelec').val();
        this.#monthStart = $('#startMonthSelec').val();
        this.#yearEnd = $('#endYearSelec').val();
        this.#monthEnd = $("#endMonthSelec").val();

        this.init(startMonthsdiv, endMonthsdiv, this.#monthInput);

        $(previousStartYear + "," + previousEndYear).on("click", () => this.AddYears($(startYear), $(endYear), -1));
        $(nextStartYear + "," + nextEndYear).on("click", () => this.AddYears($(startYear), $(endYear), 1));


        $(".ongoing-campaignBtn").on('click', (event) => {
            this.#minYear = $(event.currentTarget).attr('campaign-startyear');
            this.#maxYear = $(event.currentTarget).attr('campaign-endyear');

            $(startYear).text(this.#minYear);
            $(endYear).text(this.#maxYear);

            this.SelectMonth($("#month9"));
            this.SelectMonth($("#month20"));
        });

        $(".next-campaignBtn").on('click', (event) => {
            this.#minYear = $(event.currentTarget).attr('nextcampaign-startyear');
            this.#maxYear = $(event.currentTarget).attr('nextcampaign-endyear');

            $(startYear).text(this.#minYear);
            $(endYear).text(this.#maxYear);

            this.SelectMonth($("#month9"));
            this.SelectMonth($("#month20"));
        })
    }

    init(startMonthsDiv, endMonthsDiv) {

        var monthNum = 1;

        // FILL CALENDAR WITH TRANSLATED MONTHS
        this.#monthList.forEach(function (month) {

            var monthElement = $(this.#monthInput.replace("[MONTH]", month).replace("[MONTHNUM]", monthNum));
            $(startMonthsDiv).append(monthElement);

            monthElement.find('span').on("click", () => this.SelectMonth(monthElement.find('span')));
            monthNum++;

        }, this);

        this.#monthList.forEach(function (month) {

            var monthElement = $(this.#monthInput.replace("[MONTH]", month).replace("[MONTHNUM]", monthNum));
            $(endMonthsDiv).append(monthElement);

            monthElement.find('span').on("click", () => this.SelectMonth(monthElement.find('span')));
            monthNum++;
        }, this);

        // APPLY STYLE FOR MONTH INTERVAL
        var defaultMonthStartIndex = this.#yearStart == this.#yearEnd ? parseInt(this.#monthStart) + 12 : this.#monthStart;
        var defaultStartMonth = $('#month' + defaultMonthStartIndex);
        this.CountMonthsSelected(defaultStartMonth)

        var defaultMonthEndIndex = this.#yearStart == this.#yearEnd ? this.#monthEnd : parseInt(this.#monthEnd) + 12;
        var defaultEndMonth = $('#month' + defaultMonthEndIndex);
        this.CountMonthsSelected(defaultEndMonth)

        // FILL INPUT WITH DEFAULT VALUE (CURRENT CAMPAIN)
        $("#prevRange").attr("value", (this.#monthList[this.#monthStart - 1] + " - " + $('#startYearSelec').val() + " / " + this.#monthList[this.#monthEnd - 1] + " - " + $('#endYearSelec').val()));

    }

    AddYears(startYearElement, endYearElement, year) {
        var startYear = parseInt(startYearElement.text()) + year;
        var endYear = parseInt(endYearElement.text()) + year;

        this.#minYear = startYear;
        this.#maxYear = endYear;

        startYearElement.text(startYear);
        endYearElement.text(endYear)
    }

    SelectMonth(inputElement) {

        this.CountMonthsSelected(inputElement);
        if (this.#selectedMonth == 2) {

            $("#prevRange").attr("value", $('.monthsDiv span[selected="selected"]')[0].innerHTML + " - " + this.#yearStart + " / " + $('.monthsDiv span[selected="selected"]')[1].innerHTML + " - " + this.#yearEnd);

            //Store chosen period in the 4 hidden inputs
            $('#startYearSelec').attr("value", this.#yearStart);
            $('#endYearSelec').attr("value", this.#yearEnd);

            $('#startMonthSelec').attr("value", this.#monthStart);
            $('#endMonthSelec').attr("value", this.#monthEnd);

            myModal.hide();
            this.SubmitMonthPicker();
        
        }
    }

    CountMonthsSelected(inputElement) {

        if (inputElement[0].hasAttribute("selected") != "") { this.ClearMonthInterval(inputElement) }

        inputElement.attr("selected", "true");

        this.#selectedMonth = $('.monthsDiv span[selected="selected"]').length;

        if (this.#selectedMonth == 2) {

            var monthStartIndex = parseInt($('.monthsDiv span[selected="selected"]')[0].id.replace("month", ""));

            this.#monthStart = monthStartIndex > 12 ? monthStartIndex - 12 : monthStartIndex;
            this.#yearStart = monthStartIndex > 12 ? this.#maxYear : this.#minYear;

            var monthEndIndex = parseInt($('.monthsDiv span[selected="selected"]')[1].id.replace("month", ""));

            this.#monthEnd = monthEndIndex > 12 ? monthEndIndex - 12 : monthEndIndex;
            this.#yearEnd = monthEndIndex > 12 ? this.#maxYear : this.#minYear

            for (var i = monthStartIndex + 1; i <= monthEndIndex - 1; i++) {
                $("span#month" + i).addClass("monthInterval");
            }

        } else if (this.#selectedMonth > 2) {
            this.ClearMonthInterval(inputElement)
            inputElement.attr("selected", "true");
        }
    }

    ClearMonthInterval(inputElement) {
        this.#selectedMonth = 0;
        $('.monthsDiv span[selected="selected"]').each((index, element) => {
            $(element).removeAttr("selected");
        });

        $(".monthsDiv span.monthInterval").each((index, element) => {
            $(element).removeClass("monthInterval");
        });
    }

    SubmitMonthPicker() {
        $.ajax({
            url: '/ForecastEntry/FilteredCustomers',
            datatype: 'html',
            method: "GET",
            data: { monthStart: this.#monthStart, monthEnd: this.#monthEnd, yearStart: this.#yearStart, yearEnd: this.#yearEnd, selectStatus: 4, selectedCommercial:'1' },
            success: function (res) {
                $("#customersTab").html('').html(res);
          initEventTableCustomer();
            }
        })
    }

}