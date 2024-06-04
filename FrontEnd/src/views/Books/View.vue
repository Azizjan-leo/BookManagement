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
             books: []
             
         }
     },
     mounted(){
        this.getBooks();
     },
     
     methods: {

        getBooks(){
            const filter = {
                Author: '',
                Title: '',
                GenreId: '',
                SortByYear: '',
                SortByAuthor: '',
                SortByTitle: '',
             };

            axios.get(this.$config.apiBaseUrl + '/Book', filter).then(res => {
                this.books = res.data;
            });
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