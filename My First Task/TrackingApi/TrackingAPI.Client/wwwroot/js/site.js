// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function getJSON(url, errorMsg = "Something went wrong") {
    return fetch(url).then(response => {
        if (!response.ok) throw new Error(`${errorMsg} (${response.status})`);
        return response.json();
    });
}

async function triggerRequest() {
    const hotelsContainer = document.querySelector(".grid_container");
    hotelsContainer.innerHTML = "";
    const input = document.querySelector(".searchTerm");
    const query = input.value;
    if (!query) return;
    const data = await getJSON(`${location.origin}/Home/Search/query?query=${query}`);
    console.log(data);
    const { hotels } = data;
    if (hotels.length > 0) return displayData(hotelsContainer, hotels);
    displayNoContent(hotelsContainer);
}

const displayData = function (el, data) {
    el.insertAdjacentHTML("beforeend", `<p>Hotels:</p>`);
    data.forEach((obj, i) => {
        const html = `<div class="parent_row" data-hotel-id="${obj.hotelId}">${obj.hotelName}
                <span class="collapse"></span>
                <ul>
                    ${GetRooms(obj.rooms)}
                </ul>
            </div>`;
        el.insertAdjacentHTML("beforeend", html);
    });
}

const GetRooms = function (data) {
    if (!Array.isArray(data) || !data.length > 0) return "";
    return data.map((room, i) =>
        `<li data-room-id="${room.roomId}">Room Name: ${room.roomName}, Occupancy: ${room.occupancy}, Status: ${room.status}</li>`
    ).join("<hr class='dotted'>");
}

const displayNoContent = function (el) {
    const html = `<p style="margin: 0px auto;">No result     😔😔<br /> Plz try anything else</p>`;
    el.insertAdjacentHTML("beforeend", html);
}
