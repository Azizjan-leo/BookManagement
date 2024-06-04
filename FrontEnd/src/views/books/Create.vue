<template>

    <div class="container mt-5">
        <div class="card">
            <div class="card-header">
                <h4>Add Book</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="">Title</label>
                    <input type="text" v-model="model.book.title" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="">Year</label>
                    <input type="text" v-model="model.book.year" class="form-control" />
                </div>
                <div class="mb-3">
                    <label for="">Author</label>
                    <select v-model="model.book.authorId" class="form-control">
                        <option v-for="author in authors" :value="author.id">
                            {{ author.name }}
                        </option>
                    </select>
                </div>
                <div class="mb-3">
                    <label for="">Genre</label>
                    <select v-model="model.book.genreId" class="form-control">
                        <option v-for="genre in genres" :value="genre.id">
                            {{ genre.name }}
                        </option>
                    </select>
                </div>
                <div class="mb-3">
                    <button type="button" @click="saveBook" class="btn btn-primary">Save</button>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
import axios from 'axios';
import router from '@/router';

export default {
    name: 'bookCreate',
    data(){
        return{
            authors: [],
            genres: [],
            model: {
                book: {
                    title: '',
                    year: '',
                    authorId: '',
                    genreId: '',
                }
            }
        }
    },
    mounted(){
        axios.get(this.$config.apiBaseUrl + '/Author')
            .then(res => {
                this.authors = res.data;
            });
        
        axios.get(this.$config.apiBaseUrl + '/Genre')
            .then(res => {
                this.genres = res.data;
            });
    },
    methods: {
        saveBook(){
            axios.put(this.$config.apiBaseUrl + '/Book', this.model.book)
                .then(res => {
                    console.log(res);
                    alert(res.data.message);
                    if(res.status == 200)
                     router.push('/books');
                });
        }

    }
}
</script>