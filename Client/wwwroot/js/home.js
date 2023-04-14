const bookCards = document.getElementById("book-cards");
const catalog = document.getElementById("catalog");

const fetchApi = async (url) => {
    return (await fetch(url)).json();
}

const showData = async (url) => {
    const results = await fetchApi(url)
    const data = results.data;
    display(data)
}

const display = async (data) => {
    try {
        for (let i = 0; i < data.length; i++) {
            const bookId = data[i].id;
            const bookName = data[i].title;
            const bookImg = data[i].pictureUrl;
            const bookRating = data[i].rating;
            if (bookRating == null) {
                rate = "Unrated";
            }
            else {
                rate = bookRating
            }

            bookCards.innerHTML += `
            <div class="card shadow-sm" onclick="detail('https://localhost:7005/api/Books/',${bookId})" data-bs-toggle="modal" data-bs-target="#modalBook">
                <img src="${bookImg}" class="card-img-top p-3" alt="${bookName}">
                <div class="card-body px-0">
                    <h5 class="card-title text-center">${bookName}</h5>
                    <div class="card-text book-rating text-center"><i class="bi-star-fill"></i> ${rate}</div>
                </div>
            </div>
            `
        }
    } catch (error) {
        console.log("Error", error)
    }
}

function detail(stringUrl, key) {
    $.ajax({
        url: stringUrl
    }).done((result) => {
        let text = "";
        const isbn = result.data[key - 1].isbn;
        const title = result.data[key-1].title;
        const releaseYear = result.data[key-1].releaseYear;
        const synopsis = result.data[key-1].synopsis;
        const pageNumber = result.data[key-1].pageNumber;
        const price = result.data[key-1].price;
        const genre = result.data[key-1].genre;
        const img = result.data[key-1].pictureUrl;
        const tokped = result.data[key-1].tokopediaUrl;
        const shopee = result.data[key-1].shopeeUrl;
        const lazada = result.data[key-1].lazadaUrl;
        const rating = result.data[key - 1].rating;
        if (rating == null) {
            rate = "Unrated";
        }
        else {
            rate = rating
        }
        text += `
               <img src="${img}" class="card-img p-3">

               <ul>
               <li>ISBN             : ${isbn}</li>
               <li>Title            : ${title}</li>
               <li>Release Year     : ${releaseYear}</li>
               <li>Rating           : ${rate}</li>
               <li>Synopsis         : ${synopsis}</li>
               <li>Page Number      : ${pageNumber}</li>
               <li>Genre            : ${genre}</li>
               <a href="${tokped}" target="_blank" ><img src="https://www.freepnglogos.com/uploads/logo-tokopedia-png/berita-tokopedia-info-berita-terbaru-tokopedia-6.png" width="100" /></a>
               <a href="${shopee}" target="_blank" ><img src="https://www.freepnglogos.com/uploads/shopee-logo-png/shopee-logo-shop-with-the-gentlemen-collection-and-win-the-shopee-0.png" width="100" /></a>
               <a href="${lazada}" target="_blank" ><img src="https://seeklogo.com/images/L/lazada-logo-D8D78A9569-seeklogo.com.png" width="100" /></a>
               </ul>
                `;
        $("h1#exampleModalLabel").html(title);
        $(".modal-body").html(text);
    });
}

const selectCard = async (id) => {
    const link = `https://localhost:7005/api/Books/${id}`;
    const res = await fetch(link);
    const book = await res.json();
    const data = book.data
    displayPopup(data);
}

const displayPopup = (data) => {
    const htmlString = `
    <div class="popup"">
        <button id="closeBtn" onclick="closePopup()">Close</button>
        <div class="bookCard">
            <img class="card-image" src="${data.pictureUrl}"/>
            <h2 class="card-title" style="text-align:center;">${data.title}</h2>
    </div>
    `;
    catalog.innerHTML += htmlString;
};

const closePopup = () => {
    const popup = document.querySelector('.popup');
    popup.parentElement.removeChild(popup);
}

showData(`https://localhost:7005/api/Books/`)