<template>
    <div class="container">
         <div class="card">
             <div class="card-header">
                 <h4>Books
                     <RouterLink to="/books/create" class="btn btn-primary float-end">
                         Add Book
                     </RouterLink>
                 </h4>
             </div>
             <div class="card-body">
                <table class="table table-bordered">
                    <thead>
                         <tr>
                            <th>Search Title</th>
                             <th>Search Author</th>
                             <th>Search Genre</th>
                             <th>Sort By</th>
                             <th></th>
                         </tr>
                     </thead>
                     <tbody>
                        <tr>
                            <td><input type="text" v-model="filter.Title" class="form-control" /></td>
                             <td>
                                <input type="text" v-model="filter.Author" class="form-control" />
                            </td>
                             <td> 
                                <select v-model="filter.GenreId" class="form-control">
                        <option v-for="genre in genres" :value="genre.id">
                            {{ genre.name }}
                        </option>
                    </select>
                             </td>
                             <td>
                                <select v-model="sortBy" class="form-control">
                                    <option v-for="field in sortFields" :value="field">
                                        {{ field }}
                                    </option>
                                </select>
                             </td>
                             <td>     
                                <button type="button" @click="getBooks()" class="btn btn-success">
                                    Filter
                                </button>
                            </td>
                         </tr>
                     </tbody>
                </table>
                 <table class="table table-bordered">
                     <thead>
                         <tr>
                            <th>Title</th>
                             <th>Author</th>
                             <th>Year</th>
                             <th></th>
                         </tr>
                     </thead>
                     <tbody>
                         <tr v-for="(book, index) in this.books" :key="index">
                            <td>{{ book.title }}</td>
                            <td>{{ book.author.name }}</td>
                            <td>{{ book.year }}</td>
                            <td>
                                <RouterLink :to="{path: '/books/' + book.id + '/edit'}" class="btn btn-success">
                                    Edit
                                </RouterLink>
                                <button type="button" @click="deleteBook(book.id)" class="btn btn-danger">
                                    Delete
                                </button>
                            </td>
                         </tr>
                     </tbody>
                 </table>
             </div>
         </div>
    </div>
 </template>
 
 <script>
 import axios from 'axios';
 
 
 export default{
     name: 'books',
     data(){
         return {
            genres: [],
            filter: {
                Author: '',
                Title: '',
                GenreId: '',
                SortByYear: false,
                SortByAuthor: false,
                SortByTitle: false,
             },
             sortFields: {
                SortByYear: 'SortByYear',
                SortByAuthor: 'SortByAuthor',
                SortByTitle: 'SortByTitle',
             },
             sortBy: '',
             books: []
         }
     },
     mounted(){
        this.getBooks();

        this.getGenres();
     },
     
     methods: {
        getGenres(){
            axios.get(this.$config.apiBaseUrl + '/Genre')
            .then(res => {
                this.genres = res.data;
            });
        },
        getBooks(){
            if(this.sortBy != undefined)
            {
                this.filter[this.sortBy] = true;
              //  alert(this.sortBy);
            }
            
            axios.get(this.$config.apiBaseUrl + '/Book', {
                params: this.filter
            }).then(res => {this.books = res.data;});

            this.filter.SortByAuthor = false;
            this.filter.SortByTitle = false;
            this.filter.SortByYear = false;
        },

        deleteBook(bookId){
            axios.delete(this.$config.apiBaseUrl + '/Book?id=' + bookId)
                .then(res => {
                    alert(res.data.message);
                    this.getBooks();
                });
        }
     }
 }
 </script>