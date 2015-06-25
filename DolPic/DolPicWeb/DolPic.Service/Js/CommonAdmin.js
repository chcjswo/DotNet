
var clareCalendar = {
    monthNamesShort: ['1월', '2월', '3월', '4월', '5월', '6월', '7월', '8월', '9월', '10월', '11월', '12월'],
    dayNamesMin: ['일', '월', '화', '수', '목', '금', '토'],
    weekHeader: 'Wk',
    dateFormat: 'yy-mm-dd', //형식(20120303)
    autoSize: false, //오토리사이즈(body등 상위태그의 설정에 따른다)
    changeMonth: true, //월변경가능
    changeYear: true, //년변경가능
    showMonthAfterYear: true, //년 뒤에 월 표시
    buttonText: '달력선택', //버튼 텍스트 표시
    yearRange: '2012:2020' //2012년부터 2020년까지
};

var Common = {
    //콘솔 창, alert 대신 사용
    log: function (log) {
        $("#divJavaScriptConsole").append("<div>" + log + "</div>");
    },
    // 메시지 창
    message: function (message, width, height) {
        $("#divMessage").dialog({
            width: width,
            height: height,
            draggable: false,
            resizable: false,
            modal: true,
            buttons: {
                "Close": function () {
                    $(this).dialog("close");
                }
            }
        }).empty().append(message);
    }
};

var LoadingBar = {
    none: function () {
        $("#divLoadingBar:ui-dialog").dialog("destroy");
    },
    block: function () {
        $("#divLoadingBar").dialog({
            width: 200,
            height: 80,
            draggable: false,
            resizable: false,
            modal: true
        });
        $("div[aria-labelledby = 'ui-dialog-title-divLoadingBar'] a.ui-dialog-titlebar-close").remove();
    }
};

$(function () {
    //Ajax 시작시 로딩바 보여 줌.
    $(document).ajaxStart(function () {
        LoadingBar.block();
    });

    //Ajax 완료시 로딩바 감춤.
    $(document).ajaxStop(function () {
        LoadingBar.none();
    });

    //$('input[placeholder], textarea[placeholder]').placeholder();

    $("#popup_color").attr("class", "popup_h popup_h_" + $("input[name='popup_color']").val());
    $("#popup_title").attr("class", "popup_t popup_t_" + $("input[name='popup_title']").val());

    $("#StartDate").datepicker(clareCalendar);
    $("#EndDate").datepicker(clareCalendar);
    $("img.ui-datepicker-trigger").attr("style", "margin-left:5px; vertical-align:middle; cursor:pointer;");
    $("#ui-datepicker-div").hide();
});

function fnViewLoadingBar() {
    LoadingBar.block();

    return true;
}

function fnViewCheck() {
    fnViewLoadingBar();
}

function fnValidUrl(str) {
    var pattern = new RegExp('^(http|https|market)\://?' + // 프로토콜
    '((([a-z\d](([a-z\d-]*[a-z\d])|([ㄱ-힣]))*)\.)+[a-z]{2,}|' + // 도메인명 <-이부분만 수정됨
    '((\\d{1,3}\\.){3}\\d{1,3}))' + // 아이피
    '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' + // 포트번호
    '(\\?[;&a-z\\d%_.~+=-]*)?' + // 쿼리스트링
    '(\\#[-a-z\\d_]*)?$', 'i'); // 해쉬테그들

    if (!pattern.test(str)) {
        return false;
    } else {
        return true;
    }
}