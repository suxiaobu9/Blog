<template>
  <div>
    <div v-if="loading">Loading...</div>
    <article
      v-else
      v-for="simpleArticle in articleList"
      :key="simpleArticle.id"
    >
      <router-link
        class="detail-link"
        :to="{ name: 'ArticleDisplay', params: { id: simpleArticle.id } }"
        >{{ simpleArticle.title }}</router-link
      >
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
      loading: true,
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
        `${process.env.VUE_APP_BASEAPIURL}/blog/GetArticleList?type=${this.articleType}&page=1&pagesize=20`
      )
      .then((result) => {
        this.articleList = result.data;
      })
      .catch((err) => {
        this.$toast.error(err);
      })
      .then(() => {
        this.loading = false;
      });
  },
};
</script>
