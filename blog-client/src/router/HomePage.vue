<template>
  <div>
    <ArticleList :articleType="articleType" />
  </div>
</template>

<script>
import ArticleList from "../components/ArticleList.vue";
export default {
  name: "HomePage",
  data() {
    return {
      articleType: "all",
    };
  },
  components: {
    ArticleList,
  },
};
</script>

<!--<template>
  <div>
    <markdown-it-vue class="md-body" :content="html" />
  </div>
</template>

<script>
export default {
  name: "HomePage",
  data() {
    return {
      html: "",
    };
  },
  mounted() {
    this.$http
      .get(
        `https://bu9note.azurewebsites.net/api/blog/getarticlelist?page=1&pagesize=20`
      )
      .then((result) => {
        this.html = result;
      })
      .catch((err) => {
        this.html = err;
      });
    this.$http
      .get(`https://bu9note.azurewebsites.net/api/blog/getarticle?id=1`)
      .then((result) => {
        this.html = result.data;
      })
      .catch((err) => {
        this.html = err;
      });
  },
};
</script>
-->
