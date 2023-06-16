// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // lưu giá trị search hiện tại
    var currentSearchData = '';

    $('#searchInput').on('input', function ()
    {
        var searchData = $(this).val();
        if (searchData === '') {
            $('#searchList').empty();
        } else {

        $.ajax({
            url: '/Khoa/Search',
            type: 'GET',
            data: { searchData: searchData },
            success: function (searchResults) {

                if (searchData !== currentSearchData) {
                    $('#searchList').empty();
                    currentSearchData = searchData;
                }

                $.each(searchResults, function (index, result) {

                    var search = `<li><a href="/Khoa/CapNhat?makhoa=${result.maKhoa}&isUpdate=False"> ${ result.tenKhoa} ${result.sdt} </a></li>`
                    $('#searchList').append(search);
                });

            }
        })
        }

    })

})
