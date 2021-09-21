import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { VideoDetails } from '../Models/videoDetails';

@Injectable({
  providedIn: 'root'
})
export class FavServiceService {

  favVideoDetails:any;

  constructor(private httpclient:HttpClient) { }

  addFavVideoEndpoint = "http://localhost:5001/api/favouriteVideos/add"
  //http://localhost:5001/api/favouriteVideos/add
  deleteFavVideoEndpoint = "http://localhost:5001/api/favouriteVideos/delete"
  listOfFavVideos = "http://localhost:5001/api/favouriteVideos/"

  public addVideos(videoDetails: VideoDetails){
    let videoData = {"userId": videoDetails.userId, "thumbnail":videoDetails.thumbnail,"videoTitle":videoDetails.videoTitle,"videoId":videoDetails.videoId,"channelTitle":videoDetails.channelTitle}
  console.log(videoData);
 this.favVideoDetails=videoData
  return this.httpclient.post( this.addFavVideoEndpoint,videoData,{responseType: 'text'});
  }

 public myfavVideos(uid:any){
   return this.httpclient.get(this.listOfFavVideos+uid)
 }

 public deleteFavVideos(videoDetails: VideoDetails){
  let videoData = {"userId": videoDetails.userId, "thumbnail":videoDetails.thumbnail,"videoTitle":videoDetails.videoTitle,"videoId":videoDetails.videoId,"channelTitle":videoDetails.channelTitle}
   return this.httpclient.post(this.deleteFavVideoEndpoint,videoData,{responseType: 'text'})
 }
}
