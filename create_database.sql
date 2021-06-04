-- Database: TourPlanner

-- DROP DATABASE "TourPlanner";

CREATE DATABASE "TourPlanner"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'German_Germany.1252'
    LC_CTYPE = 'German_Germany.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- Table: public.Tours

-- DROP TABLE public."Tours";

CREATE TABLE public."Tours"
(
    name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    description character varying(255) COLLATE pg_catalog."default",
    distance numeric,
    tour_id integer NOT NULL DEFAULT nextval('"Tours_tourid_seq"'::regclass),
    start character varying(255) COLLATE pg_catalog."default",
    destination character varying(255) COLLATE pg_catalog."default",
    imagepath character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT "Tours_pkey" PRIMARY KEY (tour_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Tours"
    OWNER to postgres;

-- Table: public.Logs

-- DROP TABLE public."Logs";

CREATE TABLE public."Logs"
(
    date date,
    distance numeric,
    tot_time numeric,
    tour_id integer NOT NULL,
    report character varying(255) COLLATE pg_catalog."default",
    rating integer,
    alone boolean,
    vehicle character varying(255) COLLATE pg_catalog."default",
    weather character varying(255) COLLATE pg_catalog."default",
    traveller character varying(255) COLLATE pg_catalog."default",
    speed numeric,
    log_id integer NOT NULL DEFAULT nextval('"Logs_log_id_seq"'::regclass),
    name character varying(255) COLLATE pg_catalog."default",
    CONSTRAINT "Logs_pkey" PRIMARY KEY (log_id),
    CONSTRAINT tour_id FOREIGN KEY (tour_id)
        REFERENCES public."Tours" (tour_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Logs"
    OWNER to postgres;