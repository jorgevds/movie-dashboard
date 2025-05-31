## Seeding local DB

You can seed your local docker container using the following script:

```bash
cat ./movies.sql | docker compose -f docker-compose.yml exec -T db psql -U course -d movies
```
