const movieList = document.getElementById('movie-list');
const movieForm = document.getElementById('movie-form');
const movieTitleInput = document.getElementById('movie-title');

let movies = [];

function renderMovies() {
    movieList.innerHTML = '';
    movies.forEach((movie, idx) => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${movie}</td>
            <td>
                <div style="display: flex; gap: 0.5rem; align-items: center;">
                    <a class="waves-effect waves-light btn-small blue" onclick="editMovie(${idx})" style="display: flex; align-items: center;">
                        <i class="material-icons left" style="margin-right: 0.3em;">edit</i>
                        <span style="display:inline-block; vertical-align:middle;">Edit</span>
                    </a>
                    <a class="waves-effect waves-light btn-small red delete" onclick="deleteMovie(${idx})" style="display: flex; align-items: center;">
                        <i class="material-icons left" style="margin-right: 0.3em;">delete</i>
                        <span style="display:inline-block; vertical-align:middle;">Delete</span>
                    </a>
                </div>
            </td>
        `;
        movieList.appendChild(tr);
    });
}

movieForm.onsubmit = function(e) {
    e.preventDefault();
    const title = movieTitleInput.value.trim();
    if (title) {
        if (movieForm.dataset.editIdx !== undefined) {
            movies[movieForm.dataset.editIdx] = title;
            delete movieForm.dataset.editIdx;
            movieForm.querySelector('button[type="submit"]').textContent = 'Add Movie';
        } else {
            movies.push(title);
        }
        movieTitleInput.value = '';
        renderMovies();
        M.updateTextFields();
    }
};

window.editMovie = function(idx) {
    movieTitleInput.value = movies[idx];
    movieForm.dataset.editIdx = idx;
    movieForm.querySelector('button[type="submit"]').textContent = 'Update Movie';
    M.updateTextFields();
};

window.deleteMovie = function(idx) {
    movies.splice(idx, 1);
    renderMovies();
    if (movieForm.dataset.editIdx == idx) {
        movieTitleInput.value = '';
        delete movieForm.dataset.editIdx;
        movieForm.querySelector('button[type="submit"]').textContent = 'Add Movie';
        M.updateTextFields();
    }
};

document.addEventListener('DOMContentLoaded', function() {
    M.updateTextFields();
});

renderMovies();
