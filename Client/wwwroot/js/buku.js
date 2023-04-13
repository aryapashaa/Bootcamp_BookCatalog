$(document).ready(function () {
    //initialisasi sekali saat HTML selesai di load
    $('#myTable').DataTable({
        dom: 'B<"clear">lfrtip',
        buttons: [
            { extend: 'copy', text: '<i class="fa fa-files-o"></i>', titleAttr: 'Copy', className: 'btn btn-outline-primary' },
            { extend: 'csv', text: '<i class="fa fa-file-text-o"></i>', titleAttr: 'CSV', className: 'btn btn-outline-success' },
            { extend: 'excel', text: '<i class="fa fa-file-excel-o"></i>', titleAttr: 'Excel', className: 'btn btn-outline-success' },
            { extend: 'pdf', text: '<i class="fa fa-file-pdf-o"></i>', titleAttr: 'PDF', className: 'btn btn-outline-danger' },
            { extend: 'print', text: '<i class="fa fa-print"></i>', titleAttr: 'Print', className: 'btn btn-outline-info' }
        ],
        ajax: {
            url: "https://localhost:7005/api/Books",
            type: "GET",//=> CORS
            dataSrc: "data",
            dataType: "JSON"
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { data: "title" },
            {
                data: "",
                render: function (data, type, row) {
                    return `
					<button class="btn btn-info dt-detail" onclick="detail(
                    '${row['id']}', 
                    '${row['isbn']}',
                    '${row['title']}',
                    '${row['releaseYear']}', 
                    '${row['synopsis']}',
                    '${row['pageNumber']}',
                    '${row['price']}',
                    '${row['genre']}',
                    '${row['pictureUrl']}',
                    '${row['tokopediaUrl']}',
                    '${row['shopeeUrl']}',
                    '${row['lazadaUrl']}',
                    '${row['rating']}',
                    '${row['publisherId']}',
                    '${row['authorId']}',
                    '${row['languageId']}'
                    )" data-bs-toggle="modal" data-bs-target="#modalDetail">
						<a data-bs-toggle="tooltip" data-bs-placement="top" title="Detail">
							<i class="fa fa-info-circle"></i>
						</a>
					</button>

					<button class="btn btn-warning dt-edit" onclick="edit(
					)" data-bs-toggle="modal" data-bs-target="#modalEdit">
						<a data-bs-toggle="tooltip" data-bs-placement="top" title="Edit">
							<i class="fa fa-edit"></i>
						</a>
					</button>

					<button class="btn btn-danger dt-delete" id="hapus" onclick="remove(${row['nik']}
					)" data-bs-toggle="modal" data-bs-target="#modalDelete">
						<a data-bs-toggle="tooltip" data-bs-placement="top" title="Delete">
							<i class="fa fa-remove"></i>
						</a>
					</button>
					`;
                }
            },
        ],
    });
    $("#plus").html(`<button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalInsert" onclick="create()">
    <i class="fas fa-plus"></i>
    <span aria-hidden="true"></span>
</button>`);
});

// Detail
function detail(id, isbn, title, releaseYear, synopsis, pageNumber, price, genre, pictureUrl, tokopediaUrl, shopeeUrl, lazadaUrl, rating, publisherId, authorId, languageId,) {
    let txt = `<li>ID              : ${id}</li>
               <li>ISBN       : ${isbn}</li>
               <li>Title    : ${title}</li>
               <li>Release Year   : ${releaseYear}</li>
               <li>Synopsis    : ${synopsis}</li>
               <li>Page Number    : ${pageNumber}</li>
               <li>Price           : ${price}</li>
               <li>Genre        : ${genre}</li>
               <li>Picture       : <img src="${pictureUrl}" class="card-img-top p-3"></li>
               <li>Tokopedia Url       : ${tokopediaUrl}</li>
               <li>Shopee Url       : ${shopeeUrl}</li>
               <li>Lazada Url       : ${lazadaUrl}</li>
               <li>Rating       : ${rating}</li>
               <li>Publisher ID       : ${publisherId}</li>
               <li>Author ID       : ${authorId}</li>
               <li>Language ID       : ${languageId}</li>
              `;
    $(".modal-body").html(txt);
}

// Insert
function create() {
    $("#modalLabelInsert").html("Create");
    $("#modalBodyInsert").html(`<form id="create" method="post">
                    <div class="form-group">
                        <label for="isbn">ISBN</label>
                        <input type="text" class="isbn" id="isbn" name="isbn" placeholder="ISBN">
                    </div>
                    <div class="form-group">
                        <label for="title">Title</label>
                        <input type="text" class="title" id="title" name="title" placeholder="Title">
                    </div>
                    <div class="form-group">
                        <label for="releaseYear">Release Year</label>
                        <input type="text" class="releaseYear" id="releaseYear" name="releaseYear" placeholder="Release Year">
                    </div>
                    <div class="form-group">
                        <label for="synopsis">Synopsis</label>
                        <input type="text" class="synopsis" id="synopsis" name="synopsis" placeholder="Synopsis">
                    </div>
                    <div class="form-group">
                        <label for="pageNumber">Page Number</label>
                        <input type="text" class="pageNumber" id="pageNumber" name="pageNumber" placeholder="Page Number">
                    </div>
                    <div class="form-group">
                        <label for="price">Price</label>
                        <input type="text" class="price" id="price" name="price" placeholder="Price">
                    </div>
                    <div class="form-group">
                        <label for="genre">Genre</label>
                        <input type="text" class="genre" id="genre" name="genre" placeholder="Genre">
                    </div>
                    <div class="form-group">
                        <label for="pictureUrl">Picture Url</label>
                        <input type="text" class="pictureUrl" id="pictureUrl" name="pictureUrl" placeholder="Picture Url">
                    </div>
                    <div class="form-group">
                        <label for="tokopediaUrl">Tokopedia Url</label>
                        <input type="text" class="tokopediaUrl" id="tokopediaUrl" name="tokopediaUrl" placeholder="Tokopedia Url">
                    </div>
                    <div class="form-group">
                        <label for="shopeeUrl">Shopee Url</label>
                        <input type="text" class="shopeeUrl" id="shopeeUrl" name="shopeeUrl" placeholder="Shopee Url">
                    </div>
                    <div class="form-group">
                        <label for="lazadaUrl">Lazada Url</label>
                        <input type="text" class="lazadaUrl" id="lazadaUrl" name="lazadaUrl" placeholder="Lazada Url">
                    </div>
                    <div class="form-group">
                        <label for="rating">Rating</label>
                        <input type="text" class="rating" id="rating" name="rating" placeholder="Rating">
                    </div>
                    <div class="form-group">
                        <label for="publisherId">Publisher ID</label>
                        <input type="text" class="publisherId" id="publisherId" name="publisherId" placeholder="Publisher ID">
                    </div>
                    <div class="form-group">
                        <label for="authorId">Author ID</label>
                        <input type="text" class="authorId" id="authorId" name="authorId" placeholder="Author ID">
                    </div>
                    <div class="form-group">
                        <label for="languageId">Language ID</label>
                        <input type="text" class="languageId" id="languageId" name="languageId" placeholder="Language ID">
                    </div>
                </form>
                `);

    $('#book').click(function (e) {
        e.preventDefault();
        let obj = {}; //sesuaikan sendiri nama objectnya dan beserta isinya
        //ini ngambil value dari tiap inputan di form nya
        obj.isbn = $("#isbn").val();
        obj.title = $("#title").val();
        obj.releaseYear = $("#releaseYear").val();
        obj.synopsis = $("#synopsis").val();
        obj.pageNumber = parseInt($("#pageNumber").val());
        obj.price = parseInt($("#price").val());
        obj.genre = $("#genre").val();
        obj.pictureUrl = $("pictureUrl").val();
        obj.tokopediaUrl = $("tokopediaUrl").val();
        obj.shopeeUrl = $("shopeeUrl").val();
        obj.lazadaUrl = $("lazadaUrl").val();
        obj.rating = $("rating").val();
        obj.publisherId = $("publisherId").val();
        obj.authorId = $("authorId").val();
        obj.languageId = $("languageId").val();

        //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=utf-8',
                'Access-Control-Allow-Origin': "*",
                "crossDomain": true,
            },
            url: "https://localhost:7055/api/Books",
            type: "POST",
            dataType: "json",
            data: JSON.stringify(obj) //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        }).done(() => {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            });
            $("#modalInsert").modal('hide');
            $('#myTable').DataTable().ajax.reload();
        }).fail(() => {
            //console.log(obj);
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!'
            });
        })
    })
}

// Remove
function remove(id) {
    console.log(id)
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success ml-2',
            cancelButton: 'btn btn-danger mr-2'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: `https://localhost:7205/api/Books?key=${nik}`,
                data: {}
            }).done((result) => {
                swalWithBootstrapButtons.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                ).then(function () {
                    $('#myTable').DataTable().ajax.reload();
                });
            });
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your file is safe :)',
                'error'
            ).then(function () {
                $('#myTable').DataTable().ajax.reload();
            });
        }
    });
}