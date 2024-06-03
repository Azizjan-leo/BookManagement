<template>
   <div>
        <div class="card">
            <div class="card-header">
                <h4>Books
                    <RouterLink to="/book/create" class="btn btn-primary float-end">
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
                        </tr>
                    </thead>
                    <tbody>
                        <tr>

                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
   </div>
</template>

<script>

export default{
    name: 'books',
    data(){
        return {
            books: []
        }
    },
    mounted(){

        console.log('i am here');
    }
}
</script>