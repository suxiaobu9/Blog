<template>
  <div>
    <article v-for="simpleArticle in articleList" :key="simpleArticle.id">
      <router-link class="detail-link" to="/SomethingWrong">{{
        simpleArticle.title
      }}</router-link>
      <br />
      <span class="tag">{{ simpleArticle.createTime }}</span>
    </article>
  </div>
</template>

<script>
export default {
  name: "ArticleList",
  data() {
    return {
      articleList: [],
    };
  },
  props: {
    articleType: {
      type: String,
      default: "",
    },
  },
  mounted() {
    this.$http
      .get(
        `https://bu9note.azurewebsites.net/api/blog/GetArticleList?type=${this.articleType}&page=1&pagesize=20`
      )
      .then((result) => {
        this.articleList = result.data;
        console.log(this.articleList);
      })
      .catch((err) => {
        this.html = err;
      });
  },
};
</script>
