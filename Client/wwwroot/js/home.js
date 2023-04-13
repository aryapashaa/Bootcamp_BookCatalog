const bookCards = document.getElementById("book-cards");
const catalog = document.getElementById("catalog");

const fetchApi = async (url) => {
    return (await fetch(url)).json();
}

const showData = async (url) => {
    loader.classList.remove("d-none");
    const data = await fetchApi(url)
    const results = data.results;
    const resultsLength = results.length;
    const list = [];

    for (let i = 0; i < resultsLength; i++) {
        list.push(fetchApi(results[i].url))
    }

    Promise.all(list).then(data => {
        display(data)
    })
}

const display = async (data) => {
    try {
        for (let i = 0; i < data.length; i++) {
            const bookIsbn = data[i].isbn
            const bookName = data[i].title
            const bookImg = data[i].pictureUrl;

            bookCards.innerHTML += `
            <div class="card shadow-sm" onclick="selectCard(${bookIsbn})">
                <img src="${bookImg}" class="card-img-top p-3" alt="${bookName}">
                <div class="card-body px-0">
                    <h5 class="card-title text-center">${bookName}</h5>
                    <div class="card-text book-id">${bookId}</div>
                </div>
            </div>
            `
        }
    } catch (error) {
        console.log("Error", error)
    }
}

const selectCard = async (id) => {
    const link = `https://localhost:7005/api/Books${id}`;
    const res = await fetch(link);
    const book = await res.json();
    displayPopup(book);
}

const displayPopup = (book) => {
    const height = book.height * 0.1;
    const weight = book.weight * 0.1;
    const htmlString = `
    <div class="popup"">
        <button id="closeBtn" onclick="closePopup()">Close</button>
        <div class="bookCard">
            <img class="card-image" src="${book.pictureUrl}"/>
            <h2 class="card-title" style="text-align:center;">${book.name}</h2>
            <p>Height: ${height.toFixed(1)}m | Weight: ${weight.toFixed(1)}kg</p>
            <h5 class="ability-title" style="text-align:center;">Abilities</h5>
    </div>
    `;
    catalog.innerHTML += htmlString;
};

const closePopup = () => {
    const popup = document.querySelector('.popup');
    popup.parentElement.removeChild(popup);
}

showData(`https://localhost:7005/api/Books/`)